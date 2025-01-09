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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // report_group
            // 
            this.report_group.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.report_group.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.report_group.LocalReport.ReportEmbeddedResource = "Client.Report2.rdlc";
            this.report_group.Location = new System.Drawing.Point(0, 47);
            this.report_group.Name = "report_group";
            this.report_group.ServerReport.BearerToken = null;
            this.report_group.Size = new System.Drawing.Size(717, 306);
            this.report_group.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Controls.Add(this.picLogo);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(717, 47);
            this.panel1.TabIndex = 69;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbTitle.Location = new System.Drawing.Point(52, 9);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(88, 32);
            this.lbTitle.TabIndex = 69;
            this.lbTitle.Text = "Report";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // picLogo
            // 
            this.picLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogo.Image = global::Client.Properties.Resources.finalLogo1;
            this.picLogo.Location = new System.Drawing.Point(0, 2);
            this.picLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(48, 44);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 69;
            this.picLogo.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = global::Client.Properties.Resources.Close;
            this.btnClose.Location = new System.Drawing.Point(666, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(48, 44);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 39;
            this.btnClose.TabStop = false;
            this.btnClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseClick);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            this.btnClose.MouseHover += new System.EventHandler(this.btnClose_MouseHover);
            // 
            // frm_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(717, 353);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.report_group);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Report";
            this.Text = "frm_Report";
            this.Load += new System.EventHandler(this.frm_Report_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer report_group;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.PictureBox btnClose;
    }
}