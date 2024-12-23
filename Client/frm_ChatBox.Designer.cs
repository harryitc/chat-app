using System.Windows.Forms;

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
            this.dgvGroups = new System.Windows.Forms.DataGridView();
            this.rtbDialog = new System.Windows.Forms.RichTextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.btnCreateGroup = new System.Windows.Forms.Button();
            this.btnJoinGroup = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.btnCry = new System.Windows.Forms.PictureBox();
            this.btnLaugh = new System.Windows.Forms.PictureBox();
            this.btnLove = new System.Windows.Forms.PictureBox();
            this.btnLike = new System.Windows.Forms.PictureBox();
            this.btnPicture = new System.Windows.Forms.PictureBox();
            this.txtSearchGroup = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchGroup = new System.Windows.Forms.Button();
            this.btnSearchText = new System.Windows.Forms.Button();
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
            this.dgvFriends.Location = new System.Drawing.Point(17, 86);
            this.dgvFriends.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvFriends.Name = "dgvFriends";
            this.dgvFriends.ReadOnly = true;
            this.dgvFriends.RowHeadersWidth = 51;
            this.dgvFriends.RowTemplate.Height = 25;
            this.dgvFriends.Size = new System.Drawing.Size(380, 287);
            this.dgvFriends.TabIndex = 4;
            // 
            // dgvGroups
            // 
            this.dgvGroups.AllowUserToAddRows = false;
            this.dgvGroups.AllowUserToDeleteRows = false;
            this.dgvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroups.Location = new System.Drawing.Point(19, 378);
            this.dgvGroups.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvGroups.Name = "dgvGroups";
            this.dgvGroups.ReadOnly = true;
            this.dgvGroups.RowHeadersWidth = 51;
            this.dgvGroups.RowTemplate.Height = 25;
            this.dgvGroups.Size = new System.Drawing.Size(379, 271);
            this.dgvGroups.TabIndex = 3;
            this.dgvGroups.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroups_CellClick);
            this.dgvGroups.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroups_CellContentClick);
            // 
            // rtbDialog
            // 
            this.rtbDialog.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDialog.Location = new System.Drawing.Point(405, 89);
            this.rtbDialog.Margin = new System.Windows.Forms.Padding(5);
            this.rtbDialog.Name = "rtbDialog";
            this.rtbDialog.Size = new System.Drawing.Size(923, 518);
            this.rtbDialog.TabIndex = 2;
            this.rtbDialog.Text = "";
            // 
            // txtMessage
            // 
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(449, 654);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(5);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(835, 34);
            this.txtMessage.TabIndex = 1;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblWelcome.Location = new System.Drawing.Point(57, 50);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(126, 32);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "Username";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearchText
            // 
            this.txtSearchText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchText.Location = new System.Drawing.Point(1007, 54);
            this.txtSearchText.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(155, 32);
            this.txtSearchText.TabIndex = 0;
            // 
            // btnCreateGroup
            // 
            this.btnCreateGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnCreateGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateGroup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateGroup.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCreateGroup.Location = new System.Drawing.Point(19, 652);
            this.btnCreateGroup.Margin = new System.Windows.Forms.Padding(5);
            this.btnCreateGroup.Name = "btnCreateGroup";
            this.btnCreateGroup.Size = new System.Drawing.Size(143, 34);
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
            this.btnJoinGroup.Location = new System.Drawing.Point(255, 652);
            this.btnJoinGroup.Margin = new System.Windows.Forms.Padding(5);
            this.btnJoinGroup.Name = "btnJoinGroup";
            this.btnJoinGroup.Size = new System.Drawing.Size(143, 34);
            this.btnJoinGroup.TabIndex = 32;
            this.btnJoinGroup.Text = "Join Group";
            this.btnJoinGroup.UseVisualStyleBackColor = false;
            this.btnJoinGroup.Click += new System.EventHandler(this.btnJoinGroup_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Controls.Add(this.picLogo);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnLogOut);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1347, 44);
            this.panel1.TabIndex = 33;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbTitle.Location = new System.Drawing.Point(55, 2);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(186, 41);
            this.lbTitle.TabIndex = 35;
            this.lbTitle.Text = "AESoftWare";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            this.picLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogo.Image = global::Client.Properties.Resources.finalLogo;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(48, 44);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 35;
            this.picLogo.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = global::Client.Properties.Resources.Close;
            this.btnClose.Location = new System.Drawing.Point(1299, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(48, 44);
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
            this.btnLogOut.Location = new System.Drawing.Point(1245, 0);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(48, 44);
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
            this.lbGroupName.Location = new System.Drawing.Point(491, 50);
            this.lbGroupName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbGroupName.Name = "lbGroupName";
            this.lbGroupName.Size = new System.Drawing.Size(150, 32);
            this.lbGroupName.TabIndex = 34;
            this.lbGroupName.Text = "GroupName";
            this.lbGroupName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picGroup
            // 
            this.picGroup.Image = global::Client.Properties.Resources.default_avatar_profile_icon_social_media_user_image_gray_avatar_icon_blank_profile_silhouette_vector_illustration_561158_3467;
            this.picGroup.Location = new System.Drawing.Point(657, 50);
            this.picGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picGroup.Name = "picGroup";
            this.picGroup.Size = new System.Drawing.Size(36, 33);
            this.picGroup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGroup.TabIndex = 35;
            this.picGroup.TabStop = false;
            // 
            // btnNoti
            // 
            this.btnNoti.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNoti.Image = ((System.Drawing.Image)(resources.GetObject("btnNoti.Image")));
            this.btnNoti.Location = new System.Drawing.Point(447, 50);
            this.btnNoti.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNoti.Name = "btnNoti";
            this.btnNoti.Size = new System.Drawing.Size(36, 33);
            this.btnNoti.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnNoti.TabIndex = 31;
            this.btnNoti.TabStop = false;
            this.btnNoti.Click += new System.EventHandler(this.btnNoti_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(405, 50);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 33);
            this.btnAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAdd.TabIndex = 30;
            this.btnAdd.TabStop = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pic_User
            // 
            this.pic_User.Image = global::Client.Properties.Resources.default_avatar_profile_icon_social_media_user_image_gray_avatar_icon_blank_profile_silhouette_vector_illustration_561158_3467;
            this.pic_User.Location = new System.Drawing.Point(17, 48);
            this.pic_User.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic_User.Name = "pic_User";
            this.pic_User.Size = new System.Drawing.Size(36, 33);
            this.pic_User.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_User.TabIndex = 30;
            this.pic_User.TabStop = false;
            this.pic_User.Click += new System.EventHandler(this.pic_User_Click);
            // 
            // btnSend
            // 
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(1293, 652);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(36, 33);
            this.btnSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSend.TabIndex = 2;
            this.btnSend.TabStop = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnDevil
            // 
            this.btnDevil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDevil.Image = ((System.Drawing.Image)(resources.GetObject("btnDevil.Image")));
            this.btnDevil.Location = new System.Drawing.Point(449, 615);
            this.btnDevil.Margin = new System.Windows.Forms.Padding(5);
            this.btnDevil.Name = "btnDevil";
            this.btnDevil.Size = new System.Drawing.Size(40, 33);
            this.btnDevil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDevil.TabIndex = 2;
            this.btnDevil.TabStop = false;
            // 
            // btnCry
            // 
            this.btnCry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCry.Image = ((System.Drawing.Image)(resources.GetObject("btnCry.Image")));
            this.btnCry.Location = new System.Drawing.Point(539, 615);
            this.btnCry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCry.Name = "btnCry";
            this.btnCry.Size = new System.Drawing.Size(36, 33);
            this.btnCry.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCry.TabIndex = 2;
            this.btnCry.TabStop = false;
            // 
            // btnLaugh
            // 
            this.btnLaugh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLaugh.Image = ((System.Drawing.Image)(resources.GetObject("btnLaugh.Image")));
            this.btnLaugh.Location = new System.Drawing.Point(497, 615);
            this.btnLaugh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLaugh.Name = "btnLaugh";
            this.btnLaugh.Size = new System.Drawing.Size(36, 33);
            this.btnLaugh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnLaugh.TabIndex = 2;
            this.btnLaugh.TabStop = false;
            // 
            // btnLove
            // 
            this.btnLove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLove.Image = ((System.Drawing.Image)(resources.GetObject("btnLove.Image")));
            this.btnLove.Location = new System.Drawing.Point(405, 615);
            this.btnLove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLove.Name = "btnLove";
            this.btnLove.Size = new System.Drawing.Size(36, 33);
            this.btnLove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnLove.TabIndex = 2;
            this.btnLove.TabStop = false;
            this.btnLove.Click += new System.EventHandler(this.btnLove_Click);
            // 
            // btnLike
            // 
            this.btnLike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLike.Image = ((System.Drawing.Image)(resources.GetObject("btnLike.Image")));
            this.btnLike.Location = new System.Drawing.Point(580, 615);
            this.btnLike.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(36, 33);
            this.btnLike.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnLike.TabIndex = 2;
            this.btnLike.TabStop = false;
            // 
            // btnPicture
            // 
            this.btnPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPicture.Image = ((System.Drawing.Image)(resources.GetObject("btnPicture.Image")));
            this.btnPicture.Location = new System.Drawing.Point(405, 654);
            this.btnPicture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.Size = new System.Drawing.Size(36, 33);
            this.btnPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnPicture.TabIndex = 2;
            this.btnPicture.TabStop = false;
            this.btnPicture.Click += new System.EventHandler(this.btnPicture_Click);
            // 
            // txtSearchGroup
            // 
            this.txtSearchGroup.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtSearchGroup.Location = new System.Drawing.Point(190, 48);
            this.txtSearchGroup.Name = "txtSearchGroup";
            this.txtSearchGroup.Size = new System.Drawing.Size(117, 32);
            this.txtSearchGroup.TabIndex = 36;
            this.txtSearchGroup.TextChanged += new System.EventHandler(this.txtSearchGroup_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(911, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 32);
            this.label1.TabIndex = 37;
            this.label1.Text = "Search";
            // 
            // btnSearchGroup
            // 
            this.btnSearchGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnSearchGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchGroup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchGroup.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearchGroup.Location = new System.Drawing.Point(315, 48);
            this.btnSearchGroup.Margin = new System.Windows.Forms.Padding(5);
            this.btnSearchGroup.Name = "btnSearchGroup";
            this.btnSearchGroup.Size = new System.Drawing.Size(83, 34);
            this.btnSearchGroup.TabIndex = 38;
            this.btnSearchGroup.Text = "Search";
            this.btnSearchGroup.UseVisualStyleBackColor = false;
            this.btnSearchGroup.Click += new System.EventHandler(this.btnSearchText_Click_1);
            // 
            // btnSearchText
            // 
            this.btnSearchText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnSearchText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchText.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearchText.Location = new System.Drawing.Point(1172, 54);
            this.btnSearchText.Margin = new System.Windows.Forms.Padding(5);
            this.btnSearchText.Name = "btnSearchText";
            this.btnSearchText.Size = new System.Drawing.Size(83, 34);
            this.btnSearchText.TabIndex = 39;
            this.btnSearchText.Text = "Search";
            this.btnSearchText.UseVisualStyleBackColor = false;
            this.btnSearchText.Click += new System.EventHandler(this.button1_Click);
            // 
            // frm_ChatBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(1347, 695);
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
            this.Margin = new System.Windows.Forms.Padding(5);
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
        private TextBox txtSearchGroup;
        private Label label1;
        private Button btnSearchGroup;
        private Button btnSearchText;
    }
}