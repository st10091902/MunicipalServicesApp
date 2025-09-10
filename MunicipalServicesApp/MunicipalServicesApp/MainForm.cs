using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            using (var dlg = new ReportIssueForm())
            dlg.ShowDialog(this);
        }
    }
}
