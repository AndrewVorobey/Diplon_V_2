namespace Main
{
    partial class Form_Main
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.файлыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.распознатьКарточкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.считатьИзКарточекToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьСеместровоеРасписаниеПреподавателейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mySQLToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.считатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.записатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьРасписаниеВсехПреподавателейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNameCombo = new System.Windows.Forms.ToolStripComboBox();
            this.TeacherNameCombo = new System.Windows.Forms.ToolStripComboBox();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.учетнаяЗаписьБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.предметыСинонимыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расчетНагрузкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расчетНагрузкиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.считатьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.FirstKurs = new System.Windows.Forms.ToolStripTextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Mon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.StatusGroup = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBarText = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.saveFileDialog_Reports = new System.Windows.Forms.SaveFileDialog();
            this.ShowHide = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.создатьФайлСНагрузкойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.StatusGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлыToolStripMenuItem,
            this.FileNameCombo,
            this.TeacherNameCombo,
            this.настройкиToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.расчетНагрузкиToolStripMenuItem1,
            this.FirstKurs});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menu.Size = new System.Drawing.Size(977, 27);
            this.menu.TabIndex = 1;
            // 
            // файлыToolStripMenuItem
            // 
            this.файлыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.распознатьКарточкиToolStripMenuItem,
            this.mySQLToolStripMenuItem1,
            this.отчетToolStripMenuItem});
            this.файлыToolStripMenuItem.Name = "файлыToolStripMenuItem";
            this.файлыToolStripMenuItem.Size = new System.Drawing.Size(48, 23);
            this.файлыToolStripMenuItem.Text = "Файл";
            // 
            // распознатьКарточкиToolStripMenuItem
            // 
            this.распознатьКарточкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.считатьИзКарточекToolStripMenuItem,
            this.создатьСеместровоеРасписаниеПреподавателейToolStripMenuItem,
            this.создатьФайлСНагрузкойToolStripMenuItem});
            this.распознатьКарточкиToolStripMenuItem.Name = "распознатьКарточкиToolStripMenuItem";
            this.распознатьКарточкиToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.распознатьКарточкиToolStripMenuItem.Text = "Word";
            // 
            // считатьИзКарточекToolStripMenuItem
            // 
            this.считатьИзКарточекToolStripMenuItem.Name = "считатьИзКарточекToolStripMenuItem";
            this.считатьИзКарточекToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.считатьИзКарточекToolStripMenuItem.Text = "Считать карточки";
            this.считатьИзКарточекToolStripMenuItem.Click += new System.EventHandler(this.считатьИзКарточекToolStripMenuItem_Click);
            // 
            // создатьСеместровоеРасписаниеПреподавателейToolStripMenuItem
            // 
            this.создатьСеместровоеРасписаниеПреподавателейToolStripMenuItem.Name = "создатьСеместровоеРасписаниеПреподавателейToolStripMenuItem";
            this.создатьСеместровоеРасписаниеПреподавателейToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.создатьСеместровоеРасписаниеПреподавателейToolStripMenuItem.Text = "Создать семестровое расписание преподавателей";
            this.создатьСеместровоеРасписаниеПреподавателейToolStripMenuItem.Click += new System.EventHandler(this.создатьСеместровоеРасписаниеПреподавателейToolStripMenuItem_Click);
            // 
            // mySQLToolStripMenuItem1
            // 
            this.mySQLToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.считатьToolStripMenuItem,
            this.записатьToolStripMenuItem,
            this.обновитьРасписаниеВсехПреподавателейToolStripMenuItem});
            this.mySQLToolStripMenuItem1.Name = "mySQLToolStripMenuItem1";
            this.mySQLToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.mySQLToolStripMenuItem1.Text = "MySQL";
            // 
            // считатьToolStripMenuItem
            // 
            this.считатьToolStripMenuItem.Name = "считатьToolStripMenuItem";
            this.считатьToolStripMenuItem.Size = new System.Drawing.Size(314, 22);
            this.считатьToolStripMenuItem.Text = "Считать ";
            this.считатьToolStripMenuItem.Click += new System.EventHandler(this.считатьToolStripMenuItem_Click);
            // 
            // записатьToolStripMenuItem
            // 
            this.записатьToolStripMenuItem.Name = "записатьToolStripMenuItem";
            this.записатьToolStripMenuItem.Size = new System.Drawing.Size(314, 22);
            this.записатьToolStripMenuItem.Text = "Обновить текущую таблицу";
            this.записатьToolStripMenuItem.Click += new System.EventHandler(this.записатьToolStripMenuItem_Click);
            // 
            // обновитьРасписаниеВсехПреподавателейToolStripMenuItem
            // 
            this.обновитьРасписаниеВсехПреподавателейToolStripMenuItem.Name = "обновитьРасписаниеВсехПреподавателейToolStripMenuItem";
            this.обновитьРасписаниеВсехПреподавателейToolStripMenuItem.Size = new System.Drawing.Size(314, 22);
            this.обновитьРасписаниеВсехПреподавателейToolStripMenuItem.Text = "Обновить расписание всех преподавателей";
            this.обновитьРасписаниеВсехПреподавателейToolStripMenuItem.Click += new System.EventHandler(this.обновитьРасписаниеВсехПреподавателейToolStripMenuItem_Click);
            // 
            // отчетToolStripMenuItem
            // 
            this.отчетToolStripMenuItem.Name = "отчетToolStripMenuItem";
            this.отчетToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.отчетToolStripMenuItem.Text = "Отчет";
            this.отчетToolStripMenuItem.Click += new System.EventHandler(this.отчетToolStripMenuItem_Click);
            // 
            // FileNameCombo
            // 
            this.FileNameCombo.Name = "FileNameCombo";
            this.FileNameCombo.Size = new System.Drawing.Size(121, 23);
            // 
            // TeacherNameCombo
            // 
            this.TeacherNameCombo.Name = "TeacherNameCombo";
            this.TeacherNameCombo.Size = new System.Drawing.Size(121, 23);
            this.TeacherNameCombo.SelectedIndexChanged += new System.EventHandler(this.TeacherNameCombo_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.учетнаяЗаписьБДToolStripMenuItem,
            this.предметыСинонимыToolStripMenuItem,
            this.расчетНагрузкиToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 23);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // учетнаяЗаписьБДToolStripMenuItem
            // 
            this.учетнаяЗаписьБДToolStripMenuItem.Name = "учетнаяЗаписьБДToolStripMenuItem";
            this.учетнаяЗаписьБДToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.учетнаяЗаписьБДToolStripMenuItem.Text = "MySQL";
            this.учетнаяЗаписьБДToolStripMenuItem.Click += new System.EventHandler(this.учетнаяЗаписьБДToolStripMenuItem_Click);
            // 
            // предметыСинонимыToolStripMenuItem
            // 
            this.предметыСинонимыToolStripMenuItem.Name = "предметыСинонимыToolStripMenuItem";
            this.предметыСинонимыToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.предметыСинонимыToolStripMenuItem.Text = "Название предметов";
            this.предметыСинонимыToolStripMenuItem.Click += new System.EventHandler(this.предметыСинонимыToolStripMenuItem_Click);
            // 
            // расчетНагрузкиToolStripMenuItem
            // 
            this.расчетНагрузкиToolStripMenuItem.Enabled = false;
            this.расчетНагрузкиToolStripMenuItem.Name = "расчетНагрузкиToolStripMenuItem";
            this.расчетНагрузкиToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.расчетНагрузкиToolStripMenuItem.Text = "Расчет нагрузки";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 23);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // расчетНагрузкиToolStripMenuItem1
            // 
            this.расчетНагрузкиToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.считатьToolStripMenuItem1});
            this.расчетНагрузкиToolStripMenuItem1.Name = "расчетНагрузкиToolStripMenuItem1";
            this.расчетНагрузкиToolStripMenuItem1.Size = new System.Drawing.Size(108, 23);
            this.расчетНагрузкиToolStripMenuItem1.Text = "Расчет нагрузки";
            // 
            // считатьToolStripMenuItem1
            // 
            this.считатьToolStripMenuItem1.Name = "считатьToolStripMenuItem1";
            this.считатьToolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
            this.считатьToolStripMenuItem1.Text = "Считать ";
            this.считатьToolStripMenuItem1.Click += new System.EventHandler(this.считатьToolStripMenuItem1_Click);
            // 
            // FirstKurs
            // 
            this.FirstKurs.Name = "FirstKurs";
            this.FirstKurs.Size = new System.Drawing.Size(100, 23);
            this.FirstKurs.Text = "14";
            this.FirstKurs.Click += new System.EventHandler(this.FirstKurs_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mon,
            this.Tue,
            this.Wed,
            this.Thu,
            this.Fri});
            this.dataGridView.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dataGridView.Location = new System.Drawing.Point(12, 40);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView.RowHeadersWidth = 43;
            this.dataGridView.RowTemplate.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(957, 227);
            this.dataGridView.TabIndex = 5;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellMouseDown);
            // 
            // Mon
            // 
            this.Mon.Frozen = true;
            this.Mon.HeaderText = "Понедельник";
            this.Mon.Name = "Mon";
            // 
            // Tue
            // 
            this.Tue.Frozen = true;
            this.Tue.HeaderText = "Вторник";
            this.Tue.Name = "Tue";
            // 
            // Wed
            // 
            this.Wed.Frozen = true;
            this.Wed.HeaderText = "Среда";
            this.Wed.Name = "Wed";
            // 
            // Thu
            // 
            this.Thu.Frozen = true;
            this.Thu.HeaderText = "Четверг";
            this.Thu.Name = "Thu";
            // 
            // Fri
            // 
            this.Fri.Frozen = true;
            this.Fri.HeaderText = "Пятница";
            this.Fri.Name = "Fri";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            // 
            // StatusGroup
            // 
            this.StatusGroup.Controls.Add(this.button2);
            this.StatusGroup.Controls.Add(this.button1);
            this.StatusGroup.Controls.Add(this.progressBarText);
            this.StatusGroup.Controls.Add(this.progressBar1);
            this.StatusGroup.Location = new System.Drawing.Point(12, 88);
            this.StatusGroup.Name = "StatusGroup";
            this.StatusGroup.Size = new System.Drawing.Size(957, 134);
            this.StatusGroup.TabIndex = 6;
            this.StatusGroup.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(251, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(331, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Запись завершена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(251, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(331, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Отобразить файл";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBarText
            // 
            this.progressBarText.AutoSize = true;
            this.progressBarText.Location = new System.Drawing.Point(384, 30);
            this.progressBarText.Name = "progressBarText";
            this.progressBarText.Size = new System.Drawing.Size(35, 13);
            this.progressBarText.TabIndex = 1;
            this.progressBarText.Text = "label1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(31, 23);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(885, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // ShowHide
            // 
            this.ShowHide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowHide.Location = new System.Drawing.Point(0, 287);
            this.ShowHide.Name = "ShowHide";
            this.ShowHide.Size = new System.Drawing.Size(977, 19);
            this.ShowHide.TabIndex = 7;
            this.ShowHide.Text = "▲";
            this.ShowHide.UseVisualStyleBackColor = true;
            this.ShowHide.Click += new System.EventHandler(this.ShowHide_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 322);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(245, 185);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // создатьФайлСНагрузкойToolStripMenuItem
            // 
            this.создатьФайлСНагрузкойToolStripMenuItem.Name = "создатьФайлСНагрузкойToolStripMenuItem";
            this.создатьФайлСНагрузкойToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            this.создатьФайлСНагрузкойToolStripMenuItem.Text = "Создать файл с нагрузкой";
            this.создатьФайлСНагрузкойToolStripMenuItem.Click += new System.EventHandler(this.создатьФайлСНагрузкойToolStripMenuItem_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(977, 560);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.ShowHide);
            this.Controls.Add(this.StatusGroup);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menu;
            this.MinimumSize = new System.Drawing.Size(997, 361);
            this.Name = "Form_Main";
            this.Text = "Обработка расписания";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.StatusGroup.ResumeLayout(false);
            this.StatusGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem файлыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem учетнаяЗаписьБДToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem распознатьКарточкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem считатьИзКарточекToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьСеместровоеРасписаниеПреподавателейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mySQLToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem предметыСинонимыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem считатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem записатьToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fri;
        private System.Windows.Forms.ToolStripMenuItem расчетНагрузкиToolStripMenuItem;
        public System.Windows.Forms.DataGridView dataGridView;
        public System.Windows.Forms.ToolStripComboBox FileNameCombo;
        public System.Windows.Forms.ToolStripComboBox TeacherNameCombo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox StatusGroup;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label progressBarText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem обновитьРасписаниеВсехПреподавателейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_Reports;
        private System.Windows.Forms.ToolStripMenuItem расчетНагрузкиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem считатьToolStripMenuItem1;
        public System.Windows.Forms.ToolStripTextBox FirstKurs;
        private System.Windows.Forms.Button ShowHide;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem создатьФайлСНагрузкойToolStripMenuItem;
    }
}

