using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class StatusForm : Form
    {
        private BindingSource _bs = new BindingSource();

        public StatusForm()
        {
            InitializeComponent();
            Theme.Apply(this);

            this.Load += StatusForm_Load;
            this.btnFind.Click += BtnFind_Click;
            this.btnAdvanceStatus.Click += BtnAdvanceStatus_Click;
            this.btnSuggest.Click += BtnSuggest_Click;
            this.btnNearestDepot.Click += BtnNearestDepot_Click;
            this.btnMst.Click += BtnMst_Click;

            this.AcceptButton = btnFind;

            FitButtonsToText();
        }

        private void FitButtonsToText()
        {
            void Fit(Button b)
            {
                var sz = TextRenderer.MeasureText(
                    b.Text, b.Font, new System.Drawing.Size(int.MaxValue, int.MaxValue),
                    TextFormatFlags.SingleLine);

                // + padding so nothing clips at 125–150% DPI
                b.Width = Math.Max(b.Width, sz.Width + 24);
                b.Height = Math.Max(b.Height, sz.Height + 14);
                b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                b.AutoSize = false; // we control size explicitly
            }

            Fit(btnFind);
            Fit(btnAdvanceStatus);
            Fit(btnSuggest);
            Fit(btnNearestDepot);
            Fit(btnMst);
        }

        private void StatusForm_Load(object sender, EventArgs e)
        {
            BindGrid(RequestRepository.All());
        }

        private void BindGrid(IEnumerable<ServiceRequest> data)
        {
            var rows = data.Select(r => new
            {
                r.RequestNo,
                r.Title,
                r.Category,
                r.Ward,
                r.Priority,
                ETA = r.EtaMinutes + " min",
                r.Status,
                Created = r.Created.ToString("yyyy-MM-dd HH:mm")
            }).ToList();

            _bs.DataSource = rows;
            grid.DataSource = _bs;
            Theme.SetStatus(this, rows.Count + " request(s)");
        }

        // Find by RequestNo OR keyword via AVL index
        private void BtnFind_Click(object sender, EventArgs e)
        {
            string q = (txtSearch.Text ?? "").Trim();
            if (q.Length == 0) { BindGrid(RequestRepository.All()); return; }

            int no;
            if (int.TryParse(q, out no))
            {
                var r = RequestRepository.Bst.Find(no);
                BindGrid(r != null ? new[] { r } : new ServiceRequest[0]);
                return;
            }

            // keyword: AVL → set of request numbers
            var nos = new HashSet<int>(RequestRepository.Avl.Find(q));
            var matches = RequestRepository.All().Where(r => nos.Contains(r.RequestNo));
            BindGrid(matches);
        }

        // Advance status for the selected row
        private void BtnAdvanceStatus_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null) { MessageBox.Show("Select a request first."); return; }
            int reqNo = (int)grid.CurrentRow.Cells["RequestNo"].Value;
            var r = RequestRepository.ByNo[reqNo];

            if (r.Status == IssueStatus.Received) r.Status = IssueStatus.InQueue;
            else if (r.Status == IssueStatus.InQueue) r.Status = IssueStatus.Assigned;
            else if (r.Status == IssueStatus.Assigned) r.Status = IssueStatus.Resolved;
            r.History.Add(new StatusEntry { When = DateTime.Now, Status = r.Status, Notes = "Advanced" });

            BindGrid(RequestRepository.All());
        }

        // Suggest the next assignment: min-heap (ETA, then priority)
        private void BtnSuggest_Click(object sender, EventArgs e)
        {
            var pick = RequestRepository.Heap.Pop();
            if (pick == null) { MessageBox.Show("No pending requests in heap."); return; }
            MessageBox.Show("Suggested next: #" + pick.RequestNo + " (" + pick.Title + "), ETA " + pick.EtaMinutes + " min, Priority " + pick.Priority, "Scheduler");
        }

        // Nearest depot by BFS on the ward graph
        private void BtnNearestDepot_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null) { MessageBox.Show("Select a request first."); return; }
            int reqNo = (int)grid.CurrentRow.Cells["RequestNo"].Value;
            var r = RequestRepository.ByNo[reqNo];

            string depot = CityGraph.Map.Nearest(r.Ward, CityGraph.Depots);
            MessageBox.Show("Nearest depot to " + r.Ward + " is: " + (depot ?? "N/A"), "Nearest Depot");
        }

        // Show MST weight across the ward network (Prim)
        private void BtnMst_Click(object sender, EventArgs e)
        {
            int w = CityGraph.Map.PrimMstWeight("Depot A");
            MessageBox.Show("MST total weight for service network: " + w, "Minimum Spanning Tree");
        }
    }
}
