﻿using System.Windows.Forms;

namespace Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChatBox));
            this.dgvFriends = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvGroups = new System.Windows.Forms.DataGridView();
            this.rtbDialog = new System.Windows.Forms.RichTextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.btnCreateGroup = new System.Windows.Forms.Button();
            this.btnJoinGroup = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbSbSOTP = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.btnLogOut = new System.Windows.Forms.PictureBox();
            this.lbGroupName = new System.Windows.Forms.Label();
            this.picGroup = new System.Windows.Forms.PictureBox();
            this.btnNoti = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.PictureBox();
            this.pic_User = new System.Windows.Forms.PictureBox();
            this.btnSend = new System.Windows.Forms.PictureBox();
            this.btnDevil = new System.Windows.Forms.PictureBox();
            this.txtReceiver = new System.Windows.Forms.TextBox();
            this.btnCry = new System.Windows.Forms.PictureBox();
            this.btnLaugh = new System.Windows.Forms.PictureBox();
            this.btnLove = new System.Windows.Forms.PictureBox();
            this.btnLike = new System.Windows.Forms.PictureBox();
            this.btnPicture = new System.Windows.Forms.PictureBox();
            this.lbNoti = new System.Windows.Forms.Label();
            this.txtSearchGroup = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchGroup = new System.Windows.Forms.Button();
            this.btnSearchText = new System.Windows.Forms.Button();
            this.btn_Report = new System.Windows.Forms.Button();
            this.GroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFriends)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNoti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_User)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDevil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLaugh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLike)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFriends
            // 
            this.dgvFriends.AllowUserToAddRows = false;
            this.dgvFriends.AllowUserToDeleteRows = false;
            this.dgvFriends.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFriends.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgvFriends.Location = new System.Drawing.Point(13, 70);
            this.dgvFriends.Margin = new System.Windows.Forms.Padding(2);
            this.dgvFriends.Name = "dgvFriends";
            this.dgvFriends.ReadOnly = true;
            this.dgvFriends.RowHeadersWidth = 51;
            this.dgvFriends.RowTemplate.Height = 25;
            this.dgvFriends.Size = new System.Drawing.Size(285, 233);
            this.dgvFriends.TabIndex = 4;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "ID";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            this.Column5.Width = 40;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Name";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.HeaderText = "Status";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // dgvGroups
            // 
            this.dgvGroups.AllowUserToAddRows = false;
            this.dgvGroups.AllowUserToDeleteRows = false;
            this.dgvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupID,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvGroups.Location = new System.Drawing.Point(14, 340);
            this.dgvGroups.Margin = new System.Windows.Forms.Padding(2);
            this.dgvGroups.Name = "dgvGroups";
            this.dgvGroups.ReadOnly = true;
            this.dgvGroups.RowHeadersWidth = 51;
            this.dgvGroups.RowTemplate.Height = 25;
            this.dgvGroups.Size = new System.Drawing.Size(284, 187);
            this.dgvGroups.TabIndex = 3;
            this.dgvGroups.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroups_CellClick);
            // 
            // rtbDialog
            // 
            this.rtbDialog.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDialog.Location = new System.Drawing.Point(304, 72);
            this.rtbDialog.Margin = new System.Windows.Forms.Padding(4);
            this.rtbDialog.Name = "rtbDialog";
            this.rtbDialog.Size = new System.Drawing.Size(693, 422);
            this.rtbDialog.TabIndex = 2;
            this.rtbDialog.Text = "";
            // 
            // txtMessage
            // 
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(337, 531);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(627, 29);
            this.txtMessage.TabIndex = 1;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblWelcome.Location = new System.Drawing.Point(43, 41);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(101, 25);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "Username";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearchText
            // 
            this.txtSearchText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchText.Location = new System.Drawing.Point(810, 41);
            this.txtSearchText.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(117, 27);
            this.txtSearchText.TabIndex = 0;
            // 
            // btnCreateGroup
            // 
            this.btnCreateGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnCreateGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateGroup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateGroup.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCreateGroup.Location = new System.Drawing.Point(14, 530);
            this.btnCreateGroup.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateGroup.Name = "btnCreateGroup";
            this.btnCreateGroup.Size = new System.Drawing.Size(107, 28);
            this.btnCreateGroup.TabIndex = 5;
            this.btnCreateGroup.Text = "Create Group";
            this.btnCreateGroup.UseVisualStyleBackColor = false;
            this.btnCreateGroup.Click += new System.EventHandler(this.btnCreateGroup_Click);
            // 
            // btnJoinGroup
            // 
            this.btnJoinGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnJoinGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJoinGroup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJoinGroup.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnJoinGroup.Location = new System.Drawing.Point(191, 530);
            this.btnJoinGroup.Margin = new System.Windows.Forms.Padding(4);
            this.btnJoinGroup.Name = "btnJoinGroup";
            this.btnJoinGroup.Size = new System.Drawing.Size(107, 28);
            this.btnJoinGroup.TabIndex = 32;
            this.btnJoinGroup.Text = "Join Group";
            this.btnJoinGroup.UseVisualStyleBackColor = false;
            this.btnJoinGroup.Click += new System.EventHandler(this.btnJoinGroup_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbSbSOTP);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Controls.Add(this.picLogo);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnLogOut);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 36);
            this.panel1.TabIndex = 33;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // lbSbSOTP
            // 
            this.lbSbSOTP.AutoSize = true;
            this.lbSbSOTP.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSbSOTP.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbSbSOTP.Location = new System.Drawing.Point(195, 8);
            this.lbSbSOTP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSbSOTP.Name = "lbSbSOTP";
            this.lbSbSOTP.Size = new System.Drawing.Size(159, 25);
            this.lbSbSOTP.TabIndex = 40;
            this.lbSbSOTP.Text = "Step by step OTP";
            this.lbSbSOTP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSbSOTP.Click += new System.EventHandler(this.lbSbSOTP_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbTitle.Location = new System.Drawing.Point(41, 2);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(149, 32);
            this.lbTitle.TabIndex = 35;
            this.lbTitle.Text = "AESoftWare";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // picLogo
            // 
            this.picLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogo.Image = global::Client.Properties.Resources.finalLogo;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Margin = new System.Windows.Forms.Padding(2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(36, 36);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 35;
            this.picLogo.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = global::Client.Properties.Resources.Close;
            this.btnClose.Location = new System.Drawing.Point(974, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 36);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 37;
            this.btnClose.TabStop = false;
            this.btnClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseClick);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            this.btnClose.MouseHover += new System.EventHandler(this.btnClose_MouseHover);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogOut.Image = global::Client.Properties.Resources.logout;
            this.btnLogOut.Location = new System.Drawing.Point(934, 0);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(36, 36);
            this.btnLogOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnLogOut.TabIndex = 34;
            this.btnLogOut.TabStop = false;
            this.btnLogOut.Click += new System.EventHandler(this.btn_LogOut_Click);
            // 
            // lbGroupName
            // 
            this.lbGroupName.AutoSize = true;
            this.lbGroupName.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGroupName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbGroupName.Location = new System.Drawing.Point(368, 41);
            this.lbGroupName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbGroupName.Name = "lbGroupName";
            this.lbGroupName.Size = new System.Drawing.Size(119, 25);
            this.lbGroupName.TabIndex = 34;
            this.lbGroupName.Text = "GroupName";
            this.lbGroupName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picGroup
            // 
            this.picGroup.Image = global::Client.Properties.Resources.default_avatar_profile_icon_social_media_user_image_gray_avatar_icon_blank_profile_silhouette_vector_illustration_561158_3467;
            this.picGroup.Location = new System.Drawing.Point(493, 41);
            this.picGroup.Margin = new System.Windows.Forms.Padding(2);
            this.picGroup.Name = "picGroup";
            this.picGroup.Size = new System.Drawing.Size(27, 27);
            this.picGroup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGroup.TabIndex = 35;
            this.picGroup.TabStop = false;
            this.picGroup.Click += new System.EventHandler(this.picGroup_Click);
            // 
            // btnNoti
            // 
            this.btnNoti.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNoti.Image = ((System.Drawing.Image)(resources.GetObject("btnNoti.Image")));
            this.btnNoti.Location = new System.Drawing.Point(335, 41);
            this.btnNoti.Margin = new System.Windows.Forms.Padding(2);
            this.btnNoti.Name = "btnNoti";
            this.btnNoti.Size = new System.Drawing.Size(27, 27);
            this.btnNoti.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnNoti.TabIndex = 31;
            this.btnNoti.TabStop = false;
            this.btnNoti.Click += new System.EventHandler(this.btnNoti_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(304, 41);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(27, 27);
            this.btnAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAdd.TabIndex = 30;
            this.btnAdd.TabStop = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pic_User
            // 
            this.pic_User.Image = global::Client.Properties.Resources.default_avatar_profile_icon_social_media_user_image_gray_avatar_icon_blank_profile_silhouette_vector_illustration_561158_3467;
            this.pic_User.Location = new System.Drawing.Point(13, 39);
            this.pic_User.Margin = new System.Windows.Forms.Padding(2);
            this.pic_User.Name = "pic_User";
            this.pic_User.Size = new System.Drawing.Size(27, 27);
            this.pic_User.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_User.TabIndex = 30;
            this.pic_User.TabStop = false;
            this.pic_User.Click += new System.EventHandler(this.pic_User_Click);
            // 
            // btnSend
            // 
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(970, 530);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(27, 27);
            this.btnSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSend.TabIndex = 2;
            this.btnSend.TabStop = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnDevil
            // 
            this.btnDevil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDevil.Image = ((System.Drawing.Image)(resources.GetObject("btnDevil.Image")));
            this.btnDevil.Location = new System.Drawing.Point(337, 500);
            this.btnDevil.Margin = new System.Windows.Forms.Padding(4);
            this.btnDevil.Name = "btnDevil";
            this.btnDevil.Size = new System.Drawing.Size(30, 27);
            this.btnDevil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDevil.TabIndex = 2;
            this.btnDevil.TabStop = false;
            this.btnDevil.Click += new System.EventHandler(this.btnDevil_Click);
            // 
            // txtReceiver
            // 
            this.txtReceiver.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiver.Location = new System.Drawing.Point(143, 39);
            this.txtReceiver.Margin = new System.Windows.Forms.Padding(5);
            this.txtReceiver.Name = "txtReceiver";
            this.txtReceiver.Size = new System.Drawing.Size(155, 27);
            this.txtReceiver.TabIndex = 0;
            // 
            // btnCry
            // 
            this.btnCry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCry.Image = ((System.Drawing.Image)(resources.GetObject("btnCry.Image")));
            this.btnCry.Location = new System.Drawing.Point(404, 500);
            this.btnCry.Margin = new System.Windows.Forms.Padding(2);
            this.btnCry.Name = "btnCry";
            this.btnCry.Size = new System.Drawing.Size(27, 27);
            this.btnCry.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCry.TabIndex = 2;
            this.btnCry.TabStop = false;
            this.btnCry.Click += new System.EventHandler(this.btnCry_Click);
            // 
            // btnLaugh
            // 
            this.btnLaugh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLaugh.Image = ((System.Drawing.Image)(resources.GetObject("btnLaugh.Image")));
            this.btnLaugh.Location = new System.Drawing.Point(373, 500);
            this.btnLaugh.Margin = new System.Windows.Forms.Padding(2);
            this.btnLaugh.Name = "btnLaugh";
            this.btnLaugh.Size = new System.Drawing.Size(27, 27);
            this.btnLaugh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnLaugh.TabIndex = 2;
            this.btnLaugh.TabStop = false;
            this.btnLaugh.Click += new System.EventHandler(this.btnLaugh_Click);
            // 
            // btnLove
            // 
            this.btnLove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLove.Image = ((System.Drawing.Image)(resources.GetObject("btnLove.Image")));
            this.btnLove.Location = new System.Drawing.Point(304, 500);
            this.btnLove.Margin = new System.Windows.Forms.Padding(2);
            this.btnLove.Name = "btnLove";
            this.btnLove.Size = new System.Drawing.Size(27, 27);
            this.btnLove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnLove.TabIndex = 2;
            this.btnLove.TabStop = false;
            this.btnLove.Click += new System.EventHandler(this.btnLove_Click);
            // 
            // btnLike
            // 
            this.btnLike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLike.Image = ((System.Drawing.Image)(resources.GetObject("btnLike.Image")));
            this.btnLike.Location = new System.Drawing.Point(435, 500);
            this.btnLike.Margin = new System.Windows.Forms.Padding(2);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(27, 27);
            this.btnLike.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnLike.TabIndex = 2;
            this.btnLike.TabStop = false;
            this.btnLike.Click += new System.EventHandler(this.btnLike_Click);
            // 
            // btnPicture
            // 
            this.btnPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPicture.Image = ((System.Drawing.Image)(resources.GetObject("btnPicture.Image")));
            this.btnPicture.Location = new System.Drawing.Point(304, 531);
            this.btnPicture.Margin = new System.Windows.Forms.Padding(2);
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.Size = new System.Drawing.Size(27, 27);
            this.btnPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnPicture.TabIndex = 2;
            this.btnPicture.TabStop = false;
            this.btnPicture.Click += new System.EventHandler(this.btnPicture_Click);
            // 
            // lbNoti
            // 
            this.lbNoti.AutoSize = true;
            this.lbNoti.BackColor = System.Drawing.Color.White;
            this.lbNoti.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoti.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbNoti.Location = new System.Drawing.Point(352, 39);
            this.lbNoti.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNoti.Name = "lbNoti";
            this.lbNoti.Size = new System.Drawing.Size(14, 13);
            this.lbNoti.TabIndex = 36;
            this.lbNoti.Text = "0";
            // 
            // txtSearchGroup
            // 
            this.txtSearchGroup.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtSearchGroup.Location = new System.Drawing.Point(140, 309);
            this.txtSearchGroup.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchGroup.Name = "txtSearchGroup";
            this.txtSearchGroup.Size = new System.Drawing.Size(89, 27);
            this.txtSearchGroup.TabIndex = 36;
            this.txtSearchGroup.TextChanged += new System.EventHandler(this.txtSearchGroup_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(738, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 25);
            this.label1.TabIndex = 37;
            this.label1.Text = "Search";
            // 
            // btnSearchGroup
            // 
            this.btnSearchGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnSearchGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchGroup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchGroup.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearchGroup.Location = new System.Drawing.Point(234, 309);
            this.btnSearchGroup.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchGroup.Name = "btnSearchGroup";
            this.btnSearchGroup.Size = new System.Drawing.Size(62, 28);
            this.btnSearchGroup.TabIndex = 38;
            this.btnSearchGroup.Text = "Search";
            this.btnSearchGroup.UseVisualStyleBackColor = false;
            this.btnSearchGroup.Click += new System.EventHandler(this.btnSearchGroup_Click);
            // 
            // btnSearchText
            // 
            this.btnSearchText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnSearchText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchText.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearchText.Location = new System.Drawing.Point(934, 41);
            this.btnSearchText.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchText.Name = "btnSearchText";
            this.btnSearchText.Size = new System.Drawing.Size(62, 28);
            this.btnSearchText.TabIndex = 39;
            this.btnSearchText.Text = "Search";
            this.btnSearchText.UseVisualStyleBackColor = false;
            this.btnSearchText.Click += new System.EventHandler(this.btnSearchText_Click);
            // 
            // btn_Report
            // 
            this.btn_Report.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btn_Report.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Report.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Report.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Report.Location = new System.Drawing.Point(667, 38);
            this.btn_Report.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Report.Name = "btn_Report";
            this.btn_Report.Size = new System.Drawing.Size(67, 30);
            this.btn_Report.TabIndex = 40;
            this.btn_Report.Text = "Export";
            this.btn_Report.UseVisualStyleBackColor = false;
            this.btn_Report.Click += new System.EventHandler(this.btn_Report_Click);
            // 
            // GroupID
            // 
            this.GroupID.HeaderText = "GroupID";
            this.GroupID.Name = "GroupID";
            this.GroupID.ReadOnly = true;
            this.GroupID.Visible = false;
            this.GroupID.Width = 40;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "GroupName";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Role";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 75;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Sl";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // frm_ChatBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(1010, 565);
            this.Controls.Add(this.btn_Report);
            this.Controls.Add(this.lbNoti);
            this.Controls.Add(this.btnSearchText);
            this.Controls.Add(this.btnSearchGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearchGroup);
            this.Controls.Add(this.picGroup);
            this.Controls.Add(this.lbGroupName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnJoinGroup);
            this.Controls.Add(this.btnNoti);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCreateGroup);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.pic_User);
            this.Controls.Add(this.txtReceiver);
            this.Controls.Add(this.txtSearchText);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnDevil);
            this.Controls.Add(this.btnCry);
            this.Controls.Add(this.btnLaugh);
            this.Controls.Add(this.btnLove);
            this.Controls.Add(this.btnLike);
            this.Controls.Add(this.btnPicture);
            this.Controls.Add(this.rtbDialog);
            this.Controls.Add(this.dgvGroups);
            this.Controls.Add(this.dgvFriends);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_ChatBox";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = resources.GetString("$this.Text");
            this.Load += new System.EventHandler(this.frm_ChatBox_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_ChatBox_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFriends)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNoti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_User)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDevil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLaugh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLike)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvFriends;
        private DataGridView dgvGroups;
        private RichTextBox rtbDialog;
        private PictureBox btnPicture;
        private TextBox txtMessage;
        private PictureBox btnSend;
        private Label lblWelcome;
        private TextBox txtSearchText;
        private Button btnCreateGroup;
        private DataGridViewButtonColumn Online;
        private PictureBox btnLike;
        private PictureBox btnLove;
        private PictureBox btnLaugh;
        private PictureBox btnCry;
        private PictureBox btnDevil;
        private PictureBox btnAdd;
        private PictureBox btnNoti;
        private PictureBox pic_User;
        private Button btnJoinGroup;
        private Panel panel1;
        private PictureBox btnLogOut;
        private PictureBox btnClose;
        private PictureBox picLogo;
        private Label lbTitle;
        private Label lbGroupName;
        private PictureBox picGroup;
        private Label lbNoti;
        private TextBox txtSearchGroup;
        private Label label1;
        private TextBox txtReceiver;
        private Button btnSearchGroup;
        private Button btnSearchText;
        private Button btn_Report;
        private Label lbSbSOTP;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn GroupID;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
    }
}