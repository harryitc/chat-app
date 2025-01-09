using System.Windows.Forms;

namespace Client
{
    partial class frm_ImageView
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.pic_IMG = new System.Windows.Forms.PictureBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_IMG)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Close)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.Green;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(11, 368);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(131, 37);
            this.btnCreate.TabIndex = 30;
            this.btnCreate.Text = "Choose";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // pic_IMG
            // 
            this.pic_IMG.Location = new System.Drawing.Point(11, 32);
            this.pic_IMG.Margin = new System.Windows.Forms.Padding(2);
            this.pic_IMG.Name = "pic_IMG";
            this.pic_IMG.Size = new System.Drawing.Size(300, 325);
            this.pic_IMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_IMG.TabIndex = 0;
            this.pic_IMG.TabStop = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(180, 368);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(131, 37);
            this.btnSubmit.TabIndex = 31;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_Close);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(322, 27);
            this.panel2.TabIndex = 41;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // btn_Close
            // 
            this.btn_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Close.Image = global::Client.Properties.Resources.Close;
            this.btn_Close.Location = new System.Drawing.Point(294, 1);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(26, 26);
            this.btn_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_Close.TabIndex = 39;
            this.btn_Close.TabStop = false;
            this.btn_Close.Click += new System.EventHandler(this.btnClose_Click);
            this.btn_Close.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            this.btn_Close.MouseHover += new System.EventHandler(this.btnClose_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Image View";
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // frm_ImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(322, 416);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.pic_IMG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_ImageView";
            this.Text = "Image View";
            this.Load += new System.EventHandler(this.frm_ImageView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_IMG)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Close)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pic_IMG;
        private Button btnCreate;
        private Button btnSubmit;
        private Panel panel2;
        private PictureBox btn_Close;
        private Label label3;
    }
}