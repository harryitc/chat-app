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
            ((System.ComponentModel.ISupportInitialize)(this.pic_IMG)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(116, 445);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(197, 45);
            this.btnCreate.TabIndex = 30;
            this.btnCreate.Text = "Choose";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // pic_IMG
            // 
            this.pic_IMG.Location = new System.Drawing.Point(14, 13);
            this.pic_IMG.Name = "pic_IMG";
            this.pic_IMG.Size = new System.Drawing.Size(400, 400);
            this.pic_IMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_IMG.TabIndex = 0;
            this.pic_IMG.TabStop = false;
            // 
            // frm_ImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(430, 507);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.pic_IMG);
            this.Name = "frm_ImageView";
            this.Text = "Image View";
            this.Load += new System.EventHandler(this.frm_ImageView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_IMG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pic_IMG;
        private Button btnCreate;
    }
}