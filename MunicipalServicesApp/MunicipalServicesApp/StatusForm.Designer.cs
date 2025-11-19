namespace MunicipalServicesApp
{
    partial class StatusForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnAdvanceStatus;
        private System.Windows.Forms.Button btnSuggest;
        private System.Windows.Forms.Button btnNearestDepot;
        private System.Windows.Forms.Button btnMst;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label lblSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnAdvanceStatus = new System.Windows.Forms.Button();
            this.btnSuggest = new System.Windows.Forms.Button();
            this.btnNearestDepot = new System.Windows.Forms.Button();
            this.btnMst = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.lblSearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(15, 41);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(180, 20);
            this.txtSearch.TabIndex = 6;
            // 
            // btnFind
            // 
            this.btnFind.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFind.Location = new System.Drawing.Point(241, 15);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(80, 30);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Find";
            // 
            // btnAdvanceStatus
            // 
            this.btnAdvanceStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdvanceStatus.Location = new System.Drawing.Point(354, 15);
            this.btnAdvanceStatus.Name = "btnAdvanceStatus";
            this.btnAdvanceStatus.Size = new System.Drawing.Size(110, 30);
            this.btnAdvanceStatus.TabIndex = 4;
            this.btnAdvanceStatus.Text = "Advance Status";
            // 
            // btnSuggest
            // 
            this.btnSuggest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSuggest.Location = new System.Drawing.Point(497, 15);
            this.btnSuggest.Name = "btnSuggest";
            this.btnSuggest.Size = new System.Drawing.Size(140, 30);
            this.btnSuggest.TabIndex = 3;
            this.btnSuggest.Text = "Suggest Assignment";
            // 
            // btnNearestDepot
            // 
            this.btnNearestDepot.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnNearestDepot.Location = new System.Drawing.Point(669, 15);
            this.btnNearestDepot.Name = "btnNearestDepot";
            this.btnNearestDepot.Size = new System.Drawing.Size(110, 30);
            this.btnNearestDepot.TabIndex = 2;
            this.btnNearestDepot.Text = "Nearest Depot";
            // 
            // btnMst
            // 
            this.btnMst.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMst.Location = new System.Drawing.Point(815, 15);
            this.btnMst.Name = "btnMst";
            this.btnMst.Size = new System.Drawing.Size(100, 30);
            this.btnMst.TabIndex = 1;
            this.btnMst.Text = "MST Weight";
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.Location = new System.Drawing.Point(15, 98);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(937, 420);
            this.grid.TabIndex = 0;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 15);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(112, 13);
            this.lblSearch.TabIndex = 7;
            this.lblSearch.Text = "Request # / Keyword:";
            // 
            // StatusForm
            // 
            this.ClientSize = new System.Drawing.Size(964, 541);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnMst);
            this.Controls.Add(this.btnNearestDepot);
            this.Controls.Add(this.btnSuggest);
            this.Controls.Add(this.btnAdvanceStatus);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Service Request Status";
            this.Load += new System.EventHandler(this.StatusForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
