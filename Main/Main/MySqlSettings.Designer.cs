namespace Main
{
    partial class MySqlSettings
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
            this.Cancel = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SqlName = new System.Windows.Forms.TextBox();
            this.SqlIp = new System.Windows.Forms.TextBox();
            this.SqlUserName = new System.Windows.Forms.TextBox();
            this.SqlUserPass = new System.Windows.Forms.TextBox();
            this.SqlAuto = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(178, 141);
            this.Cancel.Name = "Cancel";
            this.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Cancel.Size = new System.Drawing.Size(80, 23);
            this.Cancel.TabIndex = 11;
            this.Cancel.Text = "Отменить";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(30, 141);
            this.Save.Name = "Save";
            this.Save.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Save.Size = new System.Drawing.Size(80, 23);
            this.Save.TabIndex = 12;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(196, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Имя пользователя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "IP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Имя БД";
            // 
            // SqlName
            // 
            this.SqlName.Location = new System.Drawing.Point(12, 34);
            this.SqlName.Name = "SqlName";
            this.SqlName.Size = new System.Drawing.Size(135, 20);
            this.SqlName.TabIndex = 3;
            // 
            // SqlIp
            // 
            this.SqlIp.Location = new System.Drawing.Point(158, 34);
            this.SqlIp.Name = "SqlIp";
            this.SqlIp.Size = new System.Drawing.Size(135, 20);
            this.SqlIp.TabIndex = 4;
            // 
            // SqlUserName
            // 
            this.SqlUserName.Location = new System.Drawing.Point(12, 81);
            this.SqlUserName.Name = "SqlUserName";
            this.SqlUserName.Size = new System.Drawing.Size(135, 20);
            this.SqlUserName.TabIndex = 5;
            // 
            // SqlUserPass
            // 
            this.SqlUserPass.Location = new System.Drawing.Point(158, 81);
            this.SqlUserPass.Name = "SqlUserPass";
            this.SqlUserPass.Size = new System.Drawing.Size(135, 20);
            this.SqlUserPass.TabIndex = 6;
            // 
            // SqlAuto
            // 
            this.SqlAuto.AutoSize = true;
            this.SqlAuto.Location = new System.Drawing.Point(13, 118);
            this.SqlAuto.Name = "SqlAuto";
            this.SqlAuto.Size = new System.Drawing.Size(165, 17);
            this.SqlAuto.TabIndex = 13;
            this.SqlAuto.Text = "Подключаться при запуске";
            this.SqlAuto.UseVisualStyleBackColor = true;
            // 
            // MySqlSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 188);
            this.Controls.Add(this.SqlAuto);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SqlName);
            this.Controls.Add(this.SqlIp);
            this.Controls.Add(this.SqlUserName);
            this.Controls.Add(this.SqlUserPass);
            this.Name = "MySqlSettings";
            this.Text = "MySqlSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SqlName;
        private System.Windows.Forms.TextBox SqlIp;
        private System.Windows.Forms.TextBox SqlUserName;
        private System.Windows.Forms.TextBox SqlUserPass;
        private System.Windows.Forms.CheckBox SqlAuto;
    }
}