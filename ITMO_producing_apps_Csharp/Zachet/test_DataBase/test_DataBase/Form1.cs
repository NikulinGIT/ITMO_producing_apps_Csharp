using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace test_DataBase
{
       public partial class Form1 : Form
       {
        DataBase database = new DataBase();
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginUser = textBox1.Text;
            var passUser = textBox2.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select id_user, login_user, password_user from register where login_user='{loginUser}'and password_user='{passUser}' ";
            SqlCommand command= new SqlCommand(querystring, database.getConnection());
            adapter.SelectCommand= command;
            adapter.Fill(table);
            if (table.Rows.Count==1)
            {
               MessageBox.Show("вы успешно вошли");
               Form2 newform = new Form2();
                this.Hide();
                newform.ShowDialog();

            }

        }
    }
}
