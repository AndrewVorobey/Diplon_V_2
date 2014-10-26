using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Main
{
    public partial class Form_Main : Form
    {
        public static Form_Main form;

        public delegate void simple_delegate();
        public delegate void string_simple_delegate(string s);
        public delegate void TeachersList_simple_delegate(TeachersList t);
        public delegate void int_Strin_Bool_delegate(int N, string s, bool e);

        public TeachersList_simple_delegate end_read_del;
        public int_Strin_Bool_delegate progress_bar_del;
        public simple_delegate showB1;
        public simple_delegate showB2;
        public int minHeight = 360;
        public int maxHeight;

        public Form_Main()
        {
            InitializeComponent();

            form = this;
            dataGridView.RowCount = 5;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
                dataGridView.Rows[i].Height = 40;
            for (int i = 0; i < dataGridView.Columns.Count; i++)
                dataGridView.Columns[i].Width = 187;

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                dataGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            dataGridView.MultiSelect = false;

            progressBarText.Text = "";
            StatusGroup.Hide();

            //delegates//
            progress_bar_del = new int_Strin_Bool_delegate(setStatus);
            end_read_del = new TeachersList_simple_delegate(endOfReading);
            showB1 = new simple_delegate(button1.Show);
            showB2 = new simple_delegate(button2.Show);
            button2.Hide();
            button1.Hide();
            maxHeight = this.Size.Height;
            ShowHide_Click(null, null);

            MySqlSettings.form = new MySqlSettings();
        }

        public void setStatus(int progress, string text, bool enable)
        {
            if (enable)
            {
                StatusGroup.Show();
                progressBar1.Value = progress;
                progressBarText.Text = progress + "%  " + text;
            }
            else
            {
                StatusGroup.Hide();
            }
        }

        private void endOfReading(TeachersList file)
        {
            Data.FilesData.Add(file);
            Form_Main.form.Invoke(Form_Main.form.showB1);
        }
        private void endWritting()
        {
            Form_Main.form.Invoke(Form_Main.form.showB2);
        }

        private void DataGridView1_CellMouseDown(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView.SelectedCells[0].RowIndex;
            int j = dataGridView.SelectedCells[0].ColumnIndex;
            if (FileNameCombo.Items.Count == 0)
                return;
            Pair toTable = new Pair(Data.FilesData[FileNameCombo.SelectedIndex].Teachers[TeacherNameCombo.SelectedIndex].pairs[j, i]);
            Form_Pair.form = new Form_Pair();
            Form_Pair.setPair(toTable);
            Form_Pair.form.ShowDialog();
            setTable();
        }

        private void считатьИзКарточекToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dataGridView.Hide();
                StatusGroup.Text = "Чтение из Doc";
                StatusGroup.Show();
                menu.Enabled = false;
                Thread ThreadwriteDoc = new Thread(read_doc);
                ThreadwriteDoc.Start();
            }
        }

        private void read_doc()
        {
            endOfReading(OLE.ReadCards(openFileDialog1.FileName));
        }

        private void setTable()
        {
            if (FileNameCombo.Items.Count == 0)
                return;
            TeacherPirs toTable = Data.FilesData[FileNameCombo.SelectedIndex].Teachers[TeacherNameCombo.SelectedIndex];

            for (int k = 0; k < 5; k++)
                for (int j = 0; j < 5; j++)
                {
                    dataGridView.Rows[j].Cells[k].Value = "<" + toTable.pairs[k,j].date[0].Burden() + ">  " + toTable.pairs[k, j].originSring;
                    if (toTable.pairs[k, j].isErrors == true)
                        dataGridView.Rows[j].Cells[k].Style.BackColor = System.Drawing.Color.Red;
                    else
                        dataGridView.Rows[j].Cells[k].Style.BackColor = System.Drawing.Color.White;
                }
        }
        private void setTeacherComboBox()
        {
            TeacherNameCombo.Items.Clear();
            List<TeacherPirs> teachers = Data.FilesData[FileNameCombo.Items.Count - 1].Teachers;
            for (int i = 0; i < teachers.Count; i++)
                TeacherNameCombo.Items.Add(teachers[i].name);


        }

        private void TeacherNameCombo_Click(object sender, EventArgs e)
        {
            setTable();
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Form_About()).ShowDialog(this);
        }

        private void создатьСеместровоеРасписаниеПреподавателейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dataGridView.Hide();
                StatusGroup.Text = "Запись в Doc";
                StatusGroup.Show();
                menu.Enabled = false;
                Thread ThreadwriteDoc = new Thread(() => write_doc(FileNameCombo.SelectedIndex));
                ThreadwriteDoc.Start();
            }
        }

        private void write_doc(int N)
        {
            OLE.CreateWordDoc(saveFileDialog1.FileName, N);
            endWritting();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            Data.FilesData[FileNameCombo.Items.Count].objectName = Data.FilesData.Count.ToString() + " Файл";
            FileNameCombo.Items.Add(Data.FilesData[FileNameCombo.Items.Count].objectName);
            FileNameCombo.SelectedIndex = FileNameCombo.Items.Count - 1;
            setTeacherComboBox();
            TeacherNameCombo.SelectedIndex = 0;
            setTable();
            dataGridView.Enabled = true;
            StatusGroup.Hide();
            menu.Enabled = true;
            dataGridView.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Hide();
            dataGridView.Enabled = true;
            StatusGroup.Hide();
            menu.Enabled = true;
            dataGridView.Show();
        }

        private void учетнаяЗаписьБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlSettings.form.ShowDialog();
        }

        private void считатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.FilesData.Add(MySql.read());
            Data.FilesData[FileNameCombo.Items.Count].objectName = Data.FilesData.Count.ToString() + " Файл";
            FileNameCombo.Items.Add(Data.FilesData[FileNameCombo.Items.Count].objectName);
            setTeacherComboBox();
            FileNameCombo.SelectedIndex = FileNameCombo.Items.Count - 1;
            TeacherNameCombo.SelectedIndex = 0;
            setTable();
        }

        private void записатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySql.SetSchedule(Data.FilesData[FileNameCombo.SelectedIndex].Teachers[FileNameCombo.SelectedIndex]);
        }

        private void обновитьРасписаниеВсехПреподавателейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Data.FilesData[FileNameCombo.SelectedIndex].Teachers.Count; i++)
                MySql.SetSchedule(Data.FilesData[FileNameCombo.SelectedIndex].Teachers[i]);
        }

        private void предметыСинонимыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Form_Subjects()).ShowDialog(this);
        }

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
             if (saveFileDialog_Reports.ShowDialog() == DialogResult.OK)
             {
                Reports.createSimpleTxtReport(saveFileDialog_Reports.FileName);
             }
        }

        private void считатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Enabled = false;
                BurdenData.inicializationFromWord(openFileDialog1.FileName);
                this.Enabled = true;
                BurdenData.values.ToArray();
                foreach(var i in BurdenData.values){
                    string str = i.Key + ":" + i.Value.ToString();
                 //   listView1.Items.Add(str);
                }
            }
        }

        private void FirstKurs_Click(object sender, EventArgs e)
        {

        }

        private void ShowHide_Click(object sender, EventArgs e)
        {
            if (ShowHide.Text == "▲")
            {
                ShowHide.Text = "▼";
                this.Height = minHeight;
            }
            else
            {
                ShowHide.Text = "▲";
                this.Height = maxHeight;
            }
        }

    }
}
