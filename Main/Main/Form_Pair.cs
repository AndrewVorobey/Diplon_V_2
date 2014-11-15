using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class Form_Pair : Form
    {
        public static Pair date;
        public static Form_Pair form;
        public Form_Pair()
        {
            InitializeComponent();
            form = this;
            form.groupBox3.Enabled = false;
        }


        public static void setPair(Pair toTable)
        {
            int stage = 0;
            date = toTable;
            if (form.textBox1.Text.Length == 0)
                form.textBox1.Text = date.ToString();
            form.checkBox2.Checked = date.isSame;

            form.TGroap.Text = date.date[stage].group;
            form.TSubject.Text = date.date[stage].subject;
            form.TRoom.Text = date.date[stage].room;
            if (!form.checkBox2.Checked)
                stage++;
            form.TGroap2.Text = date.date[stage].group;
            form.TSubject2.Text = date.date[stage].subject;
            form.TRoom2.Text = date.date[stage].room;
        }

        static bool changing = false;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!changing)
            {
                changing = true;
                if (textBox1.Enabled)
                {//TODO запретить изменяь строку. Только парсить или сохранять её местоположение. 
                    String S = textBox1.Text;
                    int pos = textBox1.SelectionStart;
                    date.parsing(textBox1.Text);
                    setPair(date);
                    date.isErrors = false;
                    date.originSring = textBox1.Text;
                    textBox1.Text = S;
                    textBox1.SelectionStart = pos;
                }
                changing = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox3.Enabled = this.checkBox1.Checked;
            if (this.groupBox3.Enabled)
                this.groupBox2.Enabled = !this.checkBox2.Checked;

            textBox1.Enabled = !this.groupBox3.Enabled;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox2.Enabled = !this.checkBox2.Checked;
            date.isSame = !this.groupBox2.Enabled;
            textBox1.Text = date.ToString();
        }

        private void TGroap_TextChanged(object sender, EventArgs e)
        {
            date.date[0].group = TGroap.Text;
            textBox1.Text = date.ToString();
        }

        private void TGroap2_TextChanged(object sender, EventArgs e)
        {
            date.date[1].group = TGroap2.Text;
            textBox1.Text = date.ToString();
        }

        private void TSubject_TextChanged(object sender, EventArgs e)
        {
            date.date[0].subject = TSubject.Text;
            textBox1.Text = date.ToString();
        }

        private void TSubject2_TextChanged(object sender, EventArgs e)
        {
            date.date[1].subject = TSubject2.Text;
            textBox1.Text = date.ToString();
        }

        private void TRoom_TextChanged(object sender, EventArgs e)
        {
            date.date[0].room = TRoom.Text;
            textBox1.Text = date.ToString();
        }

        private void TRoom2_TextChanged(object sender, EventArgs e)
        {
            date.date[1].room = TRoom2.Text;
            textBox1.Text = date.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = Form_Main.form.dataGridView.SelectedCells[0].RowIndex;
            int j = Form_Main.form.dataGridView.SelectedCells[0].ColumnIndex;
            Data.FilesData[Form_Main.form.FileNameCombo.SelectedIndex].Teachers[Form_Main.form.TeacherNameCombo.SelectedIndex].pairs[j, i] = date;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
