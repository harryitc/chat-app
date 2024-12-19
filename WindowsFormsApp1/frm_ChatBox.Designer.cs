using System.Windows.Forms;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChatBox));
            this.dgvFriends = new System.Windows.Forms.DataGridView();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvGroups = new System.Windows.Forms.DataGridView();
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
            this.btnAdd = new System.Windows.Forms.PictureBox();
            this.btnNoti = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFriends)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLike)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLaugh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDevil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNoti)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFriends
            // 
            this.dgvFriends.AllowUserToAddRows = false;
            this.dgvFriends.AllowUserToDeleteRows = false;
            this.dgvFriends.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFriends.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.username,
            this.status});
            this.dgvFriends.Location = new System.Drawing.Point(10, 37);
            this.dgvFriends.Name = "dgvFriends";
            this.dgvFriends.ReadOnly = true;
            this.dgvFriends.RowHeadersWidth = 51;
            this.dgvFriends.RowTemplate.Height = 25;
            this.dgvFriends.Size = new System.Drawing.Size(130, 174);
            this.dgvFriends.TabIndex = 4;
            // 
            // username
            // 
            this.username.HeaderText = "User";
            this.username.MinimumWidth = 6;
            this.username.Name = "username";
            this.username.ReadOnly = true;
            this.username.Width = 125;
            // 
            // status
            // 
            this.status.HeaderText = "status";
            this.status.MinimumWidth = 6;
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 125;
            // 
            // dgvGroups
            // 
            this.dgvGroups.AllowUserToAddRows = false;
            this.dgvGroups.AllowUserToDeleteRows = false;
            this.dgvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Group});
            this.dgvGroups.Location = new System.Drawing.Point(10, 217);
            this.dgvGroups.Name = "dgvGroups";
            this.dgvGroups.ReadOnly = true;
            this.dgvGroups.RowHeadersWidth = 51;
            this.dgvGroups.RowTemplate.Height = 25;
            this.dgvGroups.Size = new System.Drawing.Size(130, 174);
            this.dgvGroups.TabIndex = 3;
            this.dgvGroups.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroups_CellClick);
            // 
            // Group
            // 
            this.Group.HeaderText = "Group";
            this.Group.MinimumWidth = 6;
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
            this.btnPicture.Image = ((System.Drawing.Image)(resources.GetObject("btnPicture.Image")));
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
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(651, 396);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(26, 26);
            this.btnSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSend.TabIndex = 2;
            this.btnSend.TabStop = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
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
            this.txtReceiver.Location = new System.Drawing.Point(239, 6);
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
            this.btnCreateGroup.Click += new System.EventHandler(this.btnCreateGroup_Click);
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
            this.btnLike.Image = ((System.Drawing.Image)(resources.GetObject("btnLike.Image")));
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
            this.btnLove.Image = ((System.Drawing.Image)(resources.GetObject("btnLove.Image")));
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
            this.btnLaugh.Image = ((System.Drawing.Image)(resources.GetObject("btnLaugh.Image")));
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
            this.btnCry.Image = ((System.Drawing.Image)(resources.GetObject("btnCry.Image")));
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
            this.btnDevil.Image = ((System.Drawing.Image)(resources.GetObject("btnDevil.Image")));
            this.btnDevil.Location = new System.Drawing.Point(325, 365);
            this.btnDevil.Name = "btnDevil";
            this.btnDevil.Size = new System.Drawing.Size(26, 26);
            this.btnDevil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDevil.TabIndex = 2;
            this.btnDevil.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(340, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(26, 26);
            this.btnAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAdd.TabIndex = 30;
            this.btnAdd.TabStop = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnNoti
            // 
            this.btnNoti.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNoti.Image = ((System.Drawing.Image)(resources.GetObject("btnNoti.Image")));
            this.btnNoti.Location = new System.Drawing.Point(153, 8);
            this.btnNoti.Name = "btnNoti";
            this.btnNoti.Size = new System.Drawing.Size(26, 26);
            this.btnNoti.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnNoti.TabIndex = 31;
            this.btnNoti.TabStop = false;
            // 
            // frm_ChatBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 431);
            this.Controls.Add(this.btnNoti);
            this.Controls.Add(this.btnAdd);
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
            this.Controls.Add(this.dgvGroups);
            this.Controls.Add(this.dgvFriends);
            this.Name = "frm_ChatBox";
            this.ShowIcon = false;
            this.Text = "frm_ChatBox";
            this.Load += new System.EventHandler(this.frm_ChatBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFriends)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLike)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLaugh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDevil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNoti)).EndInit();
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
        private TextBox txtReceiver;
        private Button btnCreateGroup;
        private Button button1;
        private DataGridViewButtonColumn Group;
        private PictureBox btnLike;
        private PictureBox btnLove;
        private PictureBox btnLaugh;
        private PictureBox btnCry;
        private PictureBox btnDevil;
        private DataGridViewTextBoxColumn username;
        private DataGridViewTextBoxColumn status;
        private PictureBox btnAdd;
        private PictureBox btnNoti;
    }
}