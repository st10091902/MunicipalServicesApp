using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class EventsForm : Form
    {
        // Track user search terms (latest on top)
        private readonly Stack<string> _searchHistory = new Stack<string>();

        public EventsForm()
        {
            InitializeComponent();

            Theme.Apply(this);

            this.Load += EventsForm_Load;
            this.btnSearch.Click += btnSearch_Click;
            this.btnNextAnnouncement.Click += btnNextAnnouncement_Click;
        }

        private void EventsForm_Load(object sender, EventArgs e)
        {
            InitUi();
            this.AcceptButton = btnSearch;
        }

        private void InitUi()
        {
            // Categories
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("(All)");
            foreach (var c in EventsRepository.Categories) cmbCategory.Items.Add(c);
            cmbCategory.SelectedIndex = 0;

            // Default date window
            dtpFrom.Value = DateTime.Today.AddDays(-1);
            dtpTo.Value = DateTime.Today.AddDays(30);

            // Clear and set up ListView columns (safety if designer didn’t add)
            if (lvResults.Columns.Count == 0)
            {
                lvResults.Columns.Add("Date", 100);
                lvResults.Columns.Add("Title", 220);
                lvResults.Columns.Add("Category", 110);
                lvResults.Columns.Add("Location", 140);
                lvResults.Columns.Add("Priority", 80);
            }

            BindAnnouncementsPreview();
            BindTopPriority();
            RefreshRecommendations();
            Theme.SetStatus(this, "Ready — seeded " + EventsRepository.Categories.Count + " categories");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string cat = cmbCategory.SelectedItem as string;
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date;
            string kw = (txtKeyword.Text ?? "").Trim();

            // Record keyword for recommendations
            if (kw.Length > 0)
            {
                _searchHistory.Push(kw);
                var parts = kw.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < parts.Length; i++)
                    EventsRepository.RecordSearchKeyword(parts[i]);
            }

            IEnumerable<EventItem> matches = Query(cat, from, to, kw);
            BindResults(matches);
            RefreshRecommendations();
        }

        private IEnumerable<EventItem> Query(string category, DateTime from, DateTime to, string keyword)
        {
            // Use the sorted dictionary to limit by date efficiently
            var results = new List<EventItem>();

            foreach (var kv in EventsRepository.ByDate)
            {
                if (kv.Key < from || kv.Key > to) continue;
                results.AddRange(kv.Value);
            }

            if (!string.IsNullOrEmpty(category) && category != "(All)")
                results = results.FindAll(e => string.Equals(e.Category, category, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(keyword))
                results = results.FindAll(e =>
                    (e.Title ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (e.Description ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (e.Location ?? "").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0);

            // Sort: date asc, then priority desc
            results.Sort(delegate (EventItem a, EventItem b)
            {
                int d = a.Date.Date.CompareTo(b.Date.Date);
                if (d != 0) return d;
                return b.Priority.CompareTo(a.Priority);
            });

            return results;
        }

        private void BindResults(IEnumerable<EventItem> items)
        {
            lvResults.BeginUpdate();
            lvResults.Items.Clear();

            int count = 0;
            foreach (var e in items)
            {
                var li = new ListViewItem(e.Date.ToString("yyyy-MM-dd"));
                li.SubItems.Add(e.Title);
                li.SubItems.Add(e.Category ?? "General");
                li.SubItems.Add(e.Location ?? "-");
                li.SubItems.Add(e.Priority.ToString());
                li.Tag = e;
                lvResults.Items.Add(li);
                count++;
            }
            lvResults.EndUpdate();

            // auto-size columns for neatness
            for (int i = 0; i < lvResults.Columns.Count; i++)
                lvResults.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);

            Theme.SetStatus(this, count + " item(s) found");
        }


        private void BindAnnouncementsPreview()
        {
            lstAnnouncements.Items.Clear();
            foreach (var a in EventsRepository.Announcements)
                lstAnnouncements.Items.Add(a.Title + " — " + a.Date.ToString("yyyy-MM-dd"));
        }

        private void btnNextAnnouncement_Click(object sender, EventArgs e)
        {
            if (EventsRepository.Announcements.Count == 0)
            {
                MessageBox.Show("No more announcements.", "Info");
                return;
            }
            EventItem next = EventsRepository.Announcements.Dequeue();
            MessageBox.Show(next.Title + "\n\n" + next.Description, "Announcement");
            BindAnnouncementsPreview();
        }

        private void BindTopPriority()
        {
            // Show top 3 priority events in recommendations as a starter
            lstRecommended.Items.Clear();
            foreach (var e in EventsRepository.GetTopPriority(3))
                lstRecommended.Items.Add("[Priority] " + e.Title);
        }

        private void RefreshRecommendations()
        {
            // Recommend items based on most frequent search keywords
            var top = EventsRepository.SearchKeywordCounts
                .OrderByDescending(kv => kv.Value)
                .Take(3)
                .Select(kv => kv.Key)
                .ToList();

            foreach (var word in top)
            {
                var suggestions = Query("(All)", DateTime.Today.AddDays(-7), DateTime.Today.AddDays(30), word).Take(2);
                foreach (var s in suggestions)
                    lstRecommended.Items.Add("Because you searched \"" + word + "\": " + s.Title);
            }
        }
    }
}
