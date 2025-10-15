namespace MunicipalServicesApp
{
    partial class MainForm
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
            this.btnReportIssues = new System.Windows.Forms.Button();
            this.btnEvents = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.lblComingSoon = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnReportIssues
            // 
            this.btnReportIssues.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportIssues.Location = new System.Drawing.Point(290, 93);
            this.btnReportIssues.Name = "btnReportIssues";
            this.btnReportIssues.Size = new System.Drawing.Size(160, 44);
            this.btnReportIssues.TabIndex = 0;
            this.btnReportIssues.Text = "Report Issues";
            this.btnReportIssues.UseVisualStyleBackColor = true;
            this.btnReportIssues.Click += new System.EventHandler(this.btnReportIssues_Click);
            // 
            // btnEvents
            // 
            this.btnEvents.Enabled = false;
            this.btnEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvents.Location = new System.Drawing.Point(290, 164);
            this.btnEvents.Name = "btnEvents";
            this.btnEvents.Size = new System.Drawing.Size(160, 44);
            this.btnEvents.TabIndex = 1;
            this.btnEvents.Text = "Local Events and Announcements";
            this.btnEvents.UseVisualStyleBackColor = true;
            // 
            // btnStatus
            // 
            this.btnStatus.Enabled = false;
            this.btnStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatus.Location = new System.Drawing.Point(290, 235);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(160, 44);
            this.btnStatus.TabIndex = 2;
            this.btnStatus.Text = "Service Request Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            // 
            // lblComingSoon
            // 
            this.lblComingSoon.AutoSize = true;
            this.lblComingSoon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComingSoon.Location = new System.Drawing.Point(265, 317);
            this.lblComingSoon.Name = "lblComingSoon";
            this.lblComingSoon.Size = new System.Drawing.Size(213, 18);
            this.lblComingSoon.TabIndex = 3;
            this.lblComingSoon.Text = "Other features coming in Part 3";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblComingSoon);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.btnEvents);
            this.Controls.Add(this.btnReportIssues);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Municipal Services";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReportIssues;
        private System.Windows.Forms.Button btnEvents;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Label lblComingSoon;
    }
}

