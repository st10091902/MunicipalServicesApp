namespace MunicipalServicesApp
{
    partial class EventsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.lvResults = new System.Windows.Forms.ListView();
            this.grpRecs = new System.Windows.Forms.GroupBox();
            this.lstRecommended = new System.Windows.Forms.ListBox();
            this.grpAnnouncements = new System.Windows.Forms.GroupBox();
            this.lstAnnouncements = new System.Windows.Forms.ListBox();
            this.btnNextAnnouncement = new System.Windows.Forms.Button();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblKeyword = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Category = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Location = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Priority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.grpRecs.SuspendLayout();
            this.grpAnnouncements.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.lvResults);
            this.splitMain.Panel1.Controls.Add(this.grpSearch);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.grpAnnouncements);
            this.splitMain.Panel2.Controls.Add(this.grpRecs);
            this.splitMain.Size = new System.Drawing.Size(800, 450);
            this.splitMain.SplitterDistance = 580;
            this.splitMain.TabIndex = 1;
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.txtKeyword);
            this.grpSearch.Controls.Add(this.lblKeyword);
            this.grpSearch.Controls.Add(this.dtpTo);
            this.grpSearch.Controls.Add(this.lblTo);
            this.grpSearch.Controls.Add(this.dtpFrom);
            this.grpSearch.Controls.Add(this.lblFrom);
            this.grpSearch.Controls.Add(this.cmbCategory);
            this.grpSearch.Controls.Add(this.lblCategory);
            this.grpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSearch.Location = new System.Drawing.Point(0, 0);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(580, 120);
            this.grpSearch.TabIndex = 0;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Search";
            // 
            // lvResults
            // 
            this.lvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Date,
            this.Title,
            this.Category,
            this.Location,
            this.Priority});
            this.lvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvResults.FullRowSelect = true;
            this.lvResults.GridLines = true;
            this.lvResults.HideSelection = false;
            this.lvResults.Location = new System.Drawing.Point(0, 120);
            this.lvResults.Name = "lvResults";
            this.lvResults.Size = new System.Drawing.Size(580, 330);
            this.lvResults.TabIndex = 1;
            this.lvResults.UseCompatibleStateImageBehavior = false;
            this.lvResults.View = System.Windows.Forms.View.Details;
            // 
            // grpRecs
            // 
            this.grpRecs.Controls.Add(this.lstRecommended);
            this.grpRecs.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRecs.Location = new System.Drawing.Point(0, 0);
            this.grpRecs.Name = "grpRecs";
            this.grpRecs.Size = new System.Drawing.Size(216, 180);
            this.grpRecs.TabIndex = 0;
            this.grpRecs.TabStop = false;
            this.grpRecs.Text = "Recommended";
            // 
            // lstRecommended
            // 
            this.lstRecommended.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRecommended.FormattingEnabled = true;
            this.lstRecommended.Location = new System.Drawing.Point(3, 16);
            this.lstRecommended.Name = "lstRecommended";
            this.lstRecommended.Size = new System.Drawing.Size(210, 161);
            this.lstRecommended.TabIndex = 0;
            // 
            // grpAnnouncements
            // 
            this.grpAnnouncements.Controls.Add(this.btnNextAnnouncement);
            this.grpAnnouncements.Controls.Add(this.lstAnnouncements);
            this.grpAnnouncements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAnnouncements.Location = new System.Drawing.Point(0, 180);
            this.grpAnnouncements.Name = "grpAnnouncements";
            this.grpAnnouncements.Size = new System.Drawing.Size(216, 270);
            this.grpAnnouncements.TabIndex = 1;
            this.grpAnnouncements.TabStop = false;
            this.grpAnnouncements.Text = "Announcements";
            // 
            // lstAnnouncements
            // 
            this.lstAnnouncements.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstAnnouncements.FormattingEnabled = true;
            this.lstAnnouncements.Location = new System.Drawing.Point(3, 16);
            this.lstAnnouncements.Name = "lstAnnouncements";
            this.lstAnnouncements.Size = new System.Drawing.Size(210, 212);
            this.lstAnnouncements.TabIndex = 0;
            // 
            // btnNextAnnouncement
            // 
            this.btnNextAnnouncement.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnNextAnnouncement.Location = new System.Drawing.Point(3, 235);
            this.btnNextAnnouncement.Name = "btnNextAnnouncement";
            this.btnNextAnnouncement.Size = new System.Drawing.Size(210, 32);
            this.btnNextAnnouncement.TabIndex = 1;
            this.btnNextAnnouncement.Text = "Show Next";
            this.btnNextAnnouncement.UseVisualStyleBackColor = true;
            this.btnNextAnnouncement.Click += new System.EventHandler(this.btnNextAnnouncement_Click);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(13, 20);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(52, 13);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Category:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(16, 39);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(160, 21);
            this.cmbCategory.TabIndex = 1;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(186, 20);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 3;
            this.lblFrom.Text = "From:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(189, 40);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(96, 20);
            this.dtpFrom.TabIndex = 4;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(292, 20);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 5;
            this.lblTo.Text = "To:";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(295, 40);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(95, 20);
            this.dtpTo.TabIndex = 6;
            // 
            // lblKeyword
            // 
            this.lblKeyword.AutoSize = true;
            this.lblKeyword.Location = new System.Drawing.Point(397, 20);
            this.lblKeyword.Name = "lblKeyword";
            this.lblKeyword.Size = new System.Drawing.Size(51, 13);
            this.lblKeyword.TabIndex = 7;
            this.lblKeyword.Text = "Keyword:";
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(400, 40);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(140, 20);
            this.txtKeyword.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(189, 78);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(201, 36);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 100;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 220;
            // 
            // Category
            // 
            this.Category.Text = "Category";
            this.Category.Width = 110;
            // 
            // Location
            // 
            this.Location.Text = "Location";
            this.Location.Width = 140;
            // 
            // Priority
            // 
            this.Priority.Text = "Priority";
            this.Priority.Width = 80;
            // 
            // EventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EventsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Local Events & Announcements";
            this.Load += new System.EventHandler(this.EventsForm_Load);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpRecs.ResumeLayout(false);
            this.grpAnnouncements.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.ListView lvResults;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.GroupBox grpAnnouncements;
        private System.Windows.Forms.ListBox lstAnnouncements;
        private System.Windows.Forms.GroupBox grpRecs;
        private System.Windows.Forms.ListBox lstRecommended;
        private System.Windows.Forms.Label lblKeyword;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Button btnNextAnnouncement;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Category;
        private System.Windows.Forms.ColumnHeader Location;
        private System.Windows.Forms.ColumnHeader Priority;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtKeyword;
    }
}