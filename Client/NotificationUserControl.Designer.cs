namespace Client
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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbUser.Location = new System.Drawing.Point(75, 0);
            this.lbUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(81, 21);
            this.lbUser.TabIndex = 0;
            this.lbUser.Text = "Username";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbStatus.Location = new System.Drawing.Point(160, 0);
            this.lbStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(52, 21);
            this.lbStatus.TabIndex = 1;
            this.lbStatus.Text = "Status";
            // 
            // btnAccepted
            // 
            this.btnAccepted.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAccepted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccepted.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccepted.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAccepted.Location = new System.Drawing.Point(115, 23);
            this.btnAccepted.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccepted.Name = "btnAccepted";
            this.btnAccepted.Size = new System.Drawing.Size(105, 26);
            this.btnAccepted.TabIndex = 2;
            this.btnAccepted.Text = "Accepted";
            this.btnAccepted.UseVisualStyleBackColor = false;
            // 
            // btnDenied
            // 
            this.btnDenied.BackColor = System.Drawing.Color.Red;
            this.btnDenied.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDenied.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDenied.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDenied.Location = new System.Drawing.Point(6, 23);
            this.btnDenied.Margin = new System.Windows.Forms.Padding(2);
            this.btnDenied.Name = "btnDenied";
            this.btnDenied.Size = new System.Drawing.Size(105, 26);
            this.btnDenied.TabIndex = 3;
            this.btnDenied.Text = "Denied";
            this.btnDenied.UseVisualStyleBackColor = false;
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(14, 8);
            this.lbID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(0, 13);
            this.lbID.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Request:";
            // 
            // NotificationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbID);
            this.Controls.Add(this.btnDenied);
            this.Controls.Add(this.btnAccepted);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.lbUser);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NotificationUserControl";
            this.Size = new System.Drawing.Size(226, 59);
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
        public System.Windows.Forms.Label label1;
    }
}
