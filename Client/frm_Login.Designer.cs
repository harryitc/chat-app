using System.Windows.Forms;

namespace Client
{
    partial class frm_Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogin = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLoginUsername = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLogin.Location = new System.Drawing.Point(85, 339);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(105, 34);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Location = new System.Drawing.Point(52, 100);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(168, 30);
            this.label11.TabIndex = 40;
            this.label11.Text = "Client Chat-app";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(80, 52);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 50);
            this.label10.TabIndex = 39;
            this.label10.Text = "Login";
            // 
            // txtLoginUsername
            // 
            this.txtLoginUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.txtLoginUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoginUsername.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginUsername.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtLoginUsername.Location = new System.Drawing.Point(15, 183);
            this.txtLoginUsername.Margin = new System.Windows.Forms.Padding(2);
            this.txtLoginUsername.Name = "txtLoginUsername";
            this.txtLoginUsername.Size = new System.Drawing.Size(244, 32);
            this.txtLoginUsername.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(11, 157);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 25);
            this.label8.TabIndex = 43;
            this.label8.Text = "Username";
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.txtLoginPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoginPassword.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginPassword.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtLoginPassword.Location = new System.Drawing.Point(15, 257);
            this.txtLoginPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.Size = new System.Drawing.Size(244, 32);
            this.txtLoginPassword.TabIndex = 2;
            this.txtLoginPassword.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(11, 231);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 25);
            this.label7.TabIndex = 42;
            this.label7.Text = "Password";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.lblLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLogin.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblLogin.Location = new System.Drawing.Point(66, 375);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(140, 17);
            this.lblLogin.TabIndex = 4;
            this.lblLogin.Text = "Don’t have an account?";
            this.lblLogin.Click += new System.EventHandler(this.lblSignin_Click);
            this.lblLogin.MouseLeave += new System.EventHandler(this.lblLogin_MouseLeave);
            this.lblLogin.MouseHover += new System.EventHandler(this.lblLogin_MouseHover);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Controls.Add(this.picLogo);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 38);
            this.panel1.TabIndex = 44;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbTitle.Location = new System.Drawing.Point(43, 7);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(118, 25);
            this.lbTitle.TabIndex = 40;
            this.lbTitle.Text = "AESoftWare";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogo.Image = global::Client.Properties.Resources.finalLogo;
            this.picLogo.Location = new System.Drawing.Point(2, 0);
            this.picLogo.Margin = new System.Windows.Forms.Padding(2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(36, 36);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 39;
            this.picLogo.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = global::Client.Properties.Resources.Close;
            this.btnClose.Location = new System.Drawing.Point(516, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 36);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 38;
            this.btnClose.TabStop = false;
            this.btnClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseClick);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            this.btnClose.MouseHover += new System.EventHandler(this.btnClose_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Client.Properties.Resources.finalLogo;
            this.pictureBox1.Location = new System.Drawing.Point(181, 7);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(429, 391);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(554, 402);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtLoginPassword);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtLoginUsername);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Login_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnLogin;
        private Label label11;
        private Label label10;
        private TextBox txtLoginUsername;
        private Label label8;
        private TextBox txtLoginPassword;
        private Label label7;
        private Label lblLogin;
        private Panel panel1;
        private PictureBox btnClose;
        private PictureBox picLogo;
        private Label lbTitle;
        private PictureBox pictureBox1;
    }
}