namespace nppreg
{
    partial class FormReg
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
            this.btnReg = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.tbShow = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnReg
            // 
            this.btnReg.AutoSize = true;
            this.btnReg.Location = new System.Drawing.Point(52, 70);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(100, 22);
            this.btnReg.TabIndex = 0;
            this.btnReg.Text = "注册";
            this.btnReg.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            this.btnDel.AutoSize = true;
            this.btnDel.Location = new System.Drawing.Point(52, 120);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(100, 22);
            this.btnDel.TabIndex = 0;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // tbShow
            // 
            this.tbShow.Location = new System.Drawing.Point(52, 21);
            this.tbShow.Name = "tbShow";
            this.tbShow.Size = new System.Drawing.Size(100, 21);
            this.tbShow.TabIndex = 1;
            this.tbShow.Text = "Notepad++";
            this.tbShow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 173);
            this.Controls.Add(this.tbShow);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnReg);
            this.Name = "FormReg";
            this.Text = "Notepad++右键菜单管理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.TextBox tbShow;
    }
}