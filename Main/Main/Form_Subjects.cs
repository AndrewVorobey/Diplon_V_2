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
    public partial class Form_Subjects : Form
    {
        bool isChanged = false;
        public Form_Subjects()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form_Subjects_Load(object sender, EventArgs e)
        {
        }

        private void save()
        {
            if (isChanged)
                Text = Text.Replace("*","");
            isChanged = false;
        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
            if (!isChanged)
                return;
            string caption = "Закрытие";
            string message = "Вы хотите закрыть окно. Не сохраненные данные будут потеряны. \nСохранить?";
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            if (result == DialogResult.Yes)
            {
                save();
                return;
            }

            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

        }

        private void save_Click(object sender, EventArgs e)
        {
            save();
        }
        

        private void cancleBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void names_TextChanged(object sender, EventArgs e)
        {
            if (!isChanged)
                Text += "*";
            isChanged = true;
            int startPos = names.SelectionStart;
            for(int i = 0; i< names.Text.Length;i++)
                if (names.Text[i] == '*')
                {
                    names.SelectionStart = i;
                    for (int j = 0; j + i < names.Text.Length; j++)
                    {
                        names.SelectionLength = j+1;
                        if (names.Text[j+i] == '\n')
                            break;
                    }
                    names.SelectionColor = Color.Green;
                    names.SelectionLength = 0;
                }
            names.SelectionStart = startPos;
        }
    }
}
