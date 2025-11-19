using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Theme.Apply(this);

            // Part 2: enable Local Events & Announcements and wire the click
            btnEvents.Enabled = true;
            btnEvents.Click += new System.EventHandler(this.btnEvents_Click);
            btnStatus.Enabled = true;
            btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            using (var dlg = new ReportIssueForm())
            {
                dlg.ShowDialog(this);
            }
        }

        // NEW: Events button handler
        private void btnEvents_Click(object sender, EventArgs e)
        {
            
            Seed.Load();

            using (var dlg = new EventsForm())
            {
                dlg.ShowDialog(this);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }
      
        private void btnStatus_Click(object sender, EventArgs e)
        {
            Seed.Load();
            Seed.LoadRequests();
            using (var dlg = new StatusForm())
            {
                dlg.ShowDialog(this);
            }
        }
    }
}
