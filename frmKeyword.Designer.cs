namespace WatchNyan
{
    partial class frmKeyword
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
            this.lblCaption1 = new System.Windows.Forms.Label();
            this.lblCaption2 = new System.Windows.Forms.Label();
            this.txtKeyword1 = new System.Windows.Forms.TextBox();
            this.txtKeyword2 = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkShowFullLine = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblCaption1
            // 
            this.lblCaption1.Location = new System.Drawing.Point(14, 15);
            this.lblCaption1.Name = "lblCaption1";
            this.lblCaption1.Size = new System.Drawing.Size(78, 16);
            this.lblCaption1.TabIndex = 0;
            this.lblCaption1.Text = "关键字：";
            this.lblCaption1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCaption2
            // 
            this.lblCaption2.Location = new System.Drawing.Point(14, 40);
            this.lblCaption2.Name = "lblCaption2";
            this.lblCaption2.Size = new System.Drawing.Size(78, 16);
            this.lblCaption2.TabIndex = 1;
            this.lblCaption2.Text = "配合关键字：";
            this.lblCaption2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtKeyword1
            // 
            this.txtKeyword1.Location = new System.Drawing.Point(92, 12);
            this.txtKeyword1.Name = "txtKeyword1";
            this.txtKeyword1.Size = new System.Drawing.Size(200, 21);
            this.txtKeyword1.TabIndex = 2;
            // 
            // txtKeyword2
            // 
            this.txtKeyword2.Location = new System.Drawing.Point(92, 39);
            this.txtKeyword2.Name = "txtKeyword2";
            this.txtKeyword2.Size = new System.Drawing.Size(200, 21);
            this.txtKeyword2.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(92, 87);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(192, 87);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "　显示整行：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkShowFullLine
            // 
            this.chkShowFullLine.AutoSize = true;
            this.chkShowFullLine.Location = new System.Drawing.Point(92, 65);
            this.chkShowFullLine.Name = "chkShowFullLine";
            this.chkShowFullLine.Size = new System.Drawing.Size(192, 16);
            this.chkShowFullLine.TabIndex = 7;
            this.chkShowFullLine.Text = "提示关键字时，显示整行的内容";
            this.chkShowFullLine.UseVisualStyleBackColor = true;
            // 
            // frmKeyword
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 117);
            this.Controls.Add(this.chkShowFullLine);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtKeyword2);
            this.Controls.Add(this.txtKeyword1);
            this.Controls.Add(this.lblCaption2);
            this.Controls.Add(this.lblCaption1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmKeyword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmKeyword";
            this.Load += new System.EventHandler(this.frmKeyword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaption1;
        private System.Windows.Forms.Label lblCaption2;
        private System.Windows.Forms.TextBox txtKeyword1;
        private System.Windows.Forms.TextBox txtKeyword2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkShowFullLine;
    }
}