namespace Main
{
    partial class Form_Subjects
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
            this.names = new System.Windows.Forms.RichTextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancleBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // names
            // 
            this.names.Location = new System.Drawing.Point(12, 12);
            this.names.Name = "names";
            this.names.Size = new System.Drawing.Size(413, 218);
            this.names.TabIndex = 1;
            this.names.Text = "";
            this.names.TextChanged += new System.EventHandler(this.names_TextChanged);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(210, 236);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(92, 23);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.save_Click);
            // 
            // cancleBtn
            // 
            this.cancleBtn.Location = new System.Drawing.Point(326, 236);
            this.cancleBtn.Name = "cancleBtn";
            this.cancleBtn.Size = new System.Drawing.Size(99, 23);
            this.cancleBtn.TabIndex = 2;
            this.cancleBtn.Text = "Отменить";
            this.cancleBtn.UseVisualStyleBackColor = true;
            this.cancleBtn.Click += new System.EventHandler(this.cancleBtn_Click);
            // 
            // Form_Subjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 271);
            this.Controls.Add(this.cancleBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.names);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_Subjects";
            this.Text = "Предметы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Closing);
            this.Load += new System.EventHandler(this.Form_Subjects_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox names;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancleBtn;
    }
}