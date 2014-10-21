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
    public partial class MySqlSettings : Form
    {
        public static MySqlSettings form;
        public MySqlSettings()
        {
            InitializeComponent();
            form = this;
            Load();
            if (SqlAuto.Checked)
                MessageBox.Show(MySql.connet());
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SQL_BName = SqlName.Text;
            Properties.Settings.Default.SQL_IP = SqlIp.Text;
            Properties.Settings.Default.SQL_UserName = SqlUserName.Text;
            Properties.Settings.Default.SQL_PassWord = SqlUserPass.Text;
            Properties.Settings.Default.SQL_Auto = SqlAuto.Checked;
            Properties.Settings.Default.Save();
            this.Hide();
            MessageBox.Show(MySql.connet());

        }

        private void Load()
        {
            SqlName.Text = Properties.Settings.Default.SQL_BName;
            SqlIp.Text = Properties.Settings.Default.SQL_IP;
            SqlUserName.Text = Properties.Settings.Default.SQL_UserName;
            SqlUserPass.Text = Properties.Settings.Default.SQL_PassWord;
            SqlAuto.Checked = Properties.Settings.Default.SQL_Auto;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public static string ToString()
        {
            return "Database=" + form.SqlName.Text + ";Data Source=" + form.SqlIp + ";User Id=" + form.SqlUserName + ";Password=" + form.SqlUserPass;
        }
    }
}
