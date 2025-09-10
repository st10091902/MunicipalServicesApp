using System;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ReportIssueForm : Form
    {
        private readonly Issue _draft = new Issue();

        public ReportIssueForm()
        {
            InitializeComponent();

            // Populate categories
            cmbCategory.DataSource = Enum.GetValues(typeof(IssueCategory));

            // Initial state for progress
            progressBar.Minimum = 0;
            progressBar.Maximum = 3; // Location, Category, Description
            progressBar.Value = 0;
            lblMicrocopy.Text = "Start by telling us where the issue is.";
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            _draft.Location = txtLocation.Text.Trim();
            UpdateProgress();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedItem is IssueCategory cat)
                _draft.Category = cat;
            else
                _draft.Category = null;

            UpdateProgress();
        }

        private void rtbDescription_TextChanged(object sender, EventArgs e)
        {
            _draft.Description = rtbDescription.Text.Trim();
            UpdateProgress();
        }

        private void btnAddAttachment_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog
            {
                Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp|All files|*.*",
                Multiselect = true,
                Title = "Select image(s) or files to attach"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (var path in ofd.FileNames)
                    {
                        bool exists = _draft.Attachments.Exists(a =>
                            string.Equals(a.FilePath, path, StringComparison.OrdinalIgnoreCase));
                        if (!exists)
                            _draft.Attachments.Add(new Attachment { FilePath = path });
                    }
                    RefreshAttachmentList();
                    UpdateProgress();
                }
            }
        }


        private void RefreshAttachmentList()
        {
            lstAttachments.Items.Clear();
            foreach (var a in _draft.Attachments)
                lstAttachments.Items.Add(a.FileName);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateIssue(_draft))
            {
                MessageBox.Show(
                    "Please complete Location, Category, and a brief Description.",
                    "Missing information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            IssueRepository.Add(_draft);

            progressBar.Value = progressBar.Maximum;
            lblMicrocopy.Text = "Thanks—your report was submitted. This helps improve services in your area.";

            MessageBox.Show("Issue submitted successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Close after submit for Part 1
            Close();
        }

        private bool ValidateIssue(Issue i)
        {
            return !string.IsNullOrWhiteSpace(i?.Location)
                && !string.IsNullOrWhiteSpace(i?.Description)
                && i?.Category != null;
        }

        private void UpdateProgress()
        {
            int done = 0;
            if (!string.IsNullOrWhiteSpace(_draft.Location)) done++;
            if (_draft.Category != null) done++;
            if (!string.IsNullOrWhiteSpace(_draft.Description)) done++;

            progressBar.Minimum = 0;
            progressBar.Maximum = 3;
            progressBar.Value = done;

            if (done == 0)
                lblMicrocopy.Text = "Start by telling us where the issue is.";
            else if (done == 1)
                lblMicrocopy.Text = "Great—add a short description so teams know what to fix.";
            else if (done == 2)
                lblMicrocopy.Text = "Almost there—choose a category to help route your request.";
            else
                lblMicrocopy.Text = "Ready to submit—attachments help but are optional.";
        }


        private void btnBack_Click(object sender, EventArgs e) => Close();
    }
}
