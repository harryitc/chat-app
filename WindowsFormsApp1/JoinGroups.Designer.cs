namespace WindowsFormsApp1
{
    partial class JoinGroups
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
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnJoin = new System.Windows.Forms.Button();
            this.txtGroupID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGroupNames = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.txtNote.Location = new System.Drawing.Point(29, 230);
            this.txtNote.Margin = new System.Windows.Forms.Padding(4);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(193, 26);
            this.txtNote.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic);
            this.label4.Location = new System.Drawing.Point(28, 208);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 19);
            this.label4.TabIndex = 13;
            this.label4.Text = "Miêu tả (tùy chọn)";
            // 
            // btnJoin
            // 
            this.btnJoin.BackColor = System.Drawing.Color.RosyBrown;
            this.btnJoin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJoin.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnJoin.ForeColor = System.Drawing.Color.Maroon;
            this.btnJoin.Location = new System.Drawing.Point(33, 299);
            this.btnJoin.Margin = new System.Windows.Forms.Padding(4);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(195, 28);
            this.btnJoin.TabIndex = 9;
            this.btnJoin.Text = "Join Group";
            this.btnJoin.UseVisualStyleBackColor = false;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // txtGroupID
            // 
            this.txtGroupID.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.txtGroupID.Location = new System.Drawing.Point(29, 78);
            this.txtGroupID.Margin = new System.Windows.Forms.Padding(4);
            this.txtGroupID.Name = "txtGroupID";
            this.txtGroupID.Size = new System.Drawing.Size(193, 26);
            this.txtGroupID.TabIndex = 8;
            this.txtGroupID.TextChanged += new System.EventHandler(this.txtGroupID_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic);
            this.label2.Location = new System.Drawing.Point(29, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Group ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(29, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 28);
            this.label1.TabIndex = 10;
            this.label1.Text = "Join Group";
            // 
            // txtGroupNames
            // 
            this.txtGroupNames.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.txtGroupNames.Location = new System.Drawing.Point(29, 157);
            this.txtGroupNames.Margin = new System.Windows.Forms.Padding(4);
            this.txtGroupNames.Name = "txtGroupNames";
            this.txtGroupNames.Size = new System.Drawing.Size(193, 26);
            this.txtGroupNames.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic);
            this.label3.Location = new System.Drawing.Point(29, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 19);
            this.label3.TabIndex = 15;
            this.label3.Text = "Group Name";
            // 
            // JoinGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 364);
            this.Controls.Add(this.txtGroupNames);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.txtGroupID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "JoinGroups";
            this.Text = "JoinGroups";
            this.Load += new System.EventHandler(this.JoinGroups_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.TextBox txtGroupID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGroupNames;
        private System.Windows.Forms.Label label3;
    }
}