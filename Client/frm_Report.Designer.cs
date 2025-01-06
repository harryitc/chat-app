namespace Client
{
    partial class frm_Report
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
            this.report_group = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // report_group
            // 
            this.report_group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.report_group.LocalReport.ReportEmbeddedResource = "Client.Report2.rdlc";
            this.report_group.Location = new System.Drawing.Point(0, 0);
            this.report_group.Name = "report_group";
            this.report_group.ServerReport.BearerToken = null;
            this.report_group.Size = new System.Drawing.Size(717, 353);
            this.report_group.TabIndex = 0;
            // 
            // frm_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 353);
            this.Controls.Add(this.report_group);
            this.Name = "frm_Report";
            this.Text = "frm_Report";
            this.Load += new System.EventHandler(this.frm_Report_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer report_group;
    }
}