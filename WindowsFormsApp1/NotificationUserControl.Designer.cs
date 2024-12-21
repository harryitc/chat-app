namespace WindowsFormsApp1
{
    partial class NotificationUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lbUser = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.btnAccepted = new System.Windows.Forms.Button();
            this.btnDenied = new System.Windows.Forms.Button();
            this.lbID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Location = new System.Drawing.Point(81, 41);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(70, 16);
            this.lbUser.TabIndex = 0;
            this.lbUser.Text = "Username";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(202, 41);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(44, 16);
            this.lbStatus.TabIndex = 1;
            this.lbStatus.Text = "Status";
            // 
            // btnAccepted
            // 
            this.btnAccepted.BackColor = System.Drawing.Color.Lime;
            this.btnAccepted.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccepted.Location = new System.Drawing.Point(312, 33);
            this.btnAccepted.Name = "btnAccepted";
            this.btnAccepted.Size = new System.Drawing.Size(140, 32);
            this.btnAccepted.TabIndex = 2;
            this.btnAccepted.Text = "Accepted";
            this.btnAccepted.UseVisualStyleBackColor = false;
            // 
            // btnDenied
            // 
            this.btnDenied.BackColor = System.Drawing.Color.Red;
            this.btnDenied.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDenied.Location = new System.Drawing.Point(476, 33);
            this.btnDenied.Name = "btnDenied";
            this.btnDenied.Size = new System.Drawing.Size(140, 32);
            this.btnDenied.TabIndex = 3;
            this.btnDenied.Text = "Denied";
            this.btnDenied.UseVisualStyleBackColor = false;
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(18, 41);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(0, 16);
            this.lbID.TabIndex = 4;
            // 
            // NotificationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbID);
            this.Controls.Add(this.btnDenied);
            this.Controls.Add(this.btnAccepted);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.lbUser);
            this.Name = "NotificationUserControl";
            this.Size = new System.Drawing.Size(640, 96);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.Label lbUser;
        public System.Windows.Forms.Label lbStatus;
        public System.Windows.Forms.Button btnAccepted;
        public System.Windows.Forms.Button btnDenied;
        public System.Windows.Forms.Label lbID;
    }
}
