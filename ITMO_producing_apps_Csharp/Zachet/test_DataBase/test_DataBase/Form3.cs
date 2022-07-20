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
    public partial class Form3 : Form
    {
        DataBase database = new DataBase();

        public Form3()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.openConnection();
           
            var ID_customer= textBox1.Text;
            var Address=textBox2.Text;
            var Order_amount = textBox3.Text;
            var ID_executor=textBox4.Text;
            var addQuery= $"insert into MainTable (ID_customer,Address,Order_amount,ID_executor) values ('{ID_customer}','{Address}','{Order_amount}','{ID_executor}') ";
            var command = new SqlCommand(addQuery, database.getConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("запись создана");

        }
    }
}
