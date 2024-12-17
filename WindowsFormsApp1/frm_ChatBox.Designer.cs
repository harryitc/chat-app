﻿using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class frm_ChatBox
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
            this.tblUser = new System.Windows.Forms.DataGridView();
            this.Online = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tblGroup = new System.Windows.Forms.DataGridView();
            this.Group = new System.Windows.Forms.DataGridViewButtonColumn();
            this.rtbDialog = new System.Windows.Forms.RichTextBox();
            this.btnPicture = new System.Windows.Forms.PictureBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.PictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.txtReceiver = new System.Windows.Forms.TextBox();
            this.btnCreateGroup = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLike = new System.Windows.Forms.PictureBox();
            this.btnLove = new System.Windows.Forms.PictureBox();
            this.btnLaugh = new System.Windows.Forms.PictureBox();
            this.btnCry = new System.Windows.Forms.PictureBox();
            this.btnDevil = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tblUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLike)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLaugh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDevil)).BeginInit();
            this.SuspendLayout();
            // 
            // tblUser
            // 
            this.tblUser.AllowUserToAddRows = false;
            this.tblUser.AllowUserToDeleteRows = false;
            this.tblUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Online});
            this.tblUser.Location = new System.Drawing.Point(10, 37);
            this.tblUser.Name = "tblUser";
            this.tblUser.ReadOnly = true;
            this.tblUser.RowTemplate.Height = 25;
            this.tblUser.Size = new System.Drawing.Size(130, 174);
            this.tblUser.TabIndex = 4;
            // 
            // Online
            // 
            this.Online.HeaderText = "Online";
            this.Online.Name = "Online";
            this.Online.ReadOnly = true;
            this.Online.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Online.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Online.Width = 120;
            // 
            // tblGroup
            // 
            this.tblGroup.AllowUserToAddRows = false;
            this.tblGroup.AllowUserToDeleteRows = false;
            this.tblGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Group});
            this.tblGroup.Location = new System.Drawing.Point(10, 217);
            this.tblGroup.Name = "tblGroup";
            this.tblGroup.ReadOnly = true;
            this.tblGroup.RowTemplate.Height = 25;
            this.tblGroup.Size = new System.Drawing.Size(130, 174);
            this.tblGroup.TabIndex = 3;
            // 
            // Group
            // 
            this.Group.HeaderText = "Group";
            this.Group.Name = "Group";
            this.Group.ReadOnly = true;
            this.Group.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Group.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Group.Width = 120;
            // 
            // rtbDialog
            // 
            this.rtbDialog.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.rtbDialog.Location = new System.Drawing.Point(153, 37);
            this.rtbDialog.Name = "rtbDialog";
            this.rtbDialog.Size = new System.Drawing.Size(523, 323);
            this.rtbDialog.TabIndex = 2;
            this.rtbDialog.Text = "";
            // 
            // btnPicture
            // 
            this.btnPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPicture.Location = new System.Drawing.Point(153, 396);
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.Size = new System.Drawing.Size(26, 26);
            this.btnPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnPicture.TabIndex = 2;
            this.btnPicture.TabStop = false;
            // 
            // txtMessage
            // 
            this.txtMessage.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtMessage.Location = new System.Drawing.Point(184, 397);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(462, 29);
            this.txtMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.Location = new System.Drawing.Point(651, 396);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(26, 26);
            this.btnSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSend.TabIndex = 2;
            this.btnSend.TabStop = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblWelcome.ForeColor = System.Drawing.Color.Maroon;
            this.lblWelcome.Location = new System.Drawing.Point(10, 8);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(106, 22);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "Welcome, ...";
            // 
            // txtReceiver
            // 
            this.txtReceiver.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtReceiver.Location = new System.Drawing.Point(153, 6);
            this.txtReceiver.Name = "txtReceiver";
            this.txtReceiver.Size = new System.Drawing.Size(96, 29);
            this.txtReceiver.TabIndex = 0;
            // 
            // btnCreateGroup
            // 
            this.btnCreateGroup.BackColor = System.Drawing.Color.RosyBrown;
            this.btnCreateGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateGroup.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnCreateGroup.ForeColor = System.Drawing.Color.Maroon;
            this.btnCreateGroup.Location = new System.Drawing.Point(10, 397);
            this.btnCreateGroup.Name = "btnCreateGroup";
            this.btnCreateGroup.Size = new System.Drawing.Size(130, 25);
            this.btnCreateGroup.TabIndex = 5;
            this.btnCreateGroup.Text = "Create Group";
            this.btnCreateGroup.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkRed;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.LightCoral;
            this.button1.Location = new System.Drawing.Point(601, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 29;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnLike
            // 
            this.btnLike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLike.Location = new System.Drawing.Point(153, 365);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(26, 26);
            this.btnLike.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnLike.TabIndex = 2;
            this.btnLike.TabStop = false;
            // 
            // btnLove
            // 
            this.btnLove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLove.Location = new System.Drawing.Point(196, 365);
            this.btnLove.Name = "btnLove";
            this.btnLove.Size = new System.Drawing.Size(26, 26);
            this.btnLove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnLove.TabIndex = 2;
            this.btnLove.TabStop = false;
            // 
            // btnLaugh
            // 
            this.btnLaugh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLaugh.Location = new System.Drawing.Point(239, 365);
            this.btnLaugh.Name = "btnLaugh";
            this.btnLaugh.Size = new System.Drawing.Size(26, 26);
            this.btnLaugh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnLaugh.TabIndex = 2;
            this.btnLaugh.TabStop = false;
            // 
            // btnCry
            // 
            this.btnCry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCry.Location = new System.Drawing.Point(282, 365);
            this.btnCry.Name = "btnCry";
            this.btnCry.Size = new System.Drawing.Size(26, 26);
            this.btnCry.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCry.TabIndex = 2;
            this.btnCry.TabStop = false;
            // 
            // btnDevil
            // 
            this.btnDevil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDevil.Location = new System.Drawing.Point(325, 365);
            this.btnDevil.Name = "btnDevil";
            this.btnDevil.Size = new System.Drawing.Size(26, 26);
            this.btnDevil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDevil.TabIndex = 2;
            this.btnDevil.TabStop = false;
            // 
            // frm_ChatBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 431);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCreateGroup);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.txtReceiver);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnDevil);
            this.Controls.Add(this.btnCry);
            this.Controls.Add(this.btnLaugh);
            this.Controls.Add(this.btnLove);
            this.Controls.Add(this.btnLike);
            this.Controls.Add(this.btnPicture);
            this.Controls.Add(this.rtbDialog);
            this.Controls.Add(this.tblGroup);
            this.Controls.Add(this.tblUser);
            this.Name = "frm_ChatBox";
            this.Text = "frm_ChatBox";
            ((System.ComponentModel.ISupportInitialize)(this.tblUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLike)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLaugh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDevil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView tblUser;
        private DataGridView tblGroup;
        private RichTextBox rtbDialog;
        private PictureBox btnPicture;
        private TextBox txtMessage;
        private PictureBox btnSend;
        private Label lblWelcome;
        private TextBox txtReceiver;
        private Button btnCreateGroup;
        private Button button1;
        private DataGridViewButtonColumn Online;
        private DataGridViewButtonColumn Group;
        private PictureBox btnLike;
        private PictureBox btnLove;
        private PictureBox btnLaugh;
        private PictureBox btnCry;
        private PictureBox btnDevil;
    }
}