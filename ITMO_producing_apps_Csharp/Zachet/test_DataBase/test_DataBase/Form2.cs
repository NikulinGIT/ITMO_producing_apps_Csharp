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
    enum RowState
    { Existed,New,Modified,ModifiedNew,Deleted }
    public partial class Form2 : Form
    {
        DataBase database = new DataBase();
        public Form2()
        {
            InitializeComponent();
        }
        private void deleteRow()
        { 
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[index].Visible = false;
            if (dataGridView1.Rows[index].Cells[0].Value.ToString()==String.Empty)
            { dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted; }

        }
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("ID_customer", "ID заказчика");
            dataGridView1.Columns.Add("Address", "Адрес");
            dataGridView1.Columns.Add("Order_amount", "Стоимость заказа");
            dataGridView1.Columns.Add("ID_executor", "ID исполнителя");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {  dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetString(2), record.GetString(3), record.GetInt32(4),RowState.ModifiedNew); }
        private void RefreshDataGrid(DataGridView dgw)
        { 
            dgw.Rows.Clear();
            string querystring = $"select * from MainTable ";
            SqlCommand command = new SqlCommand(querystring, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {ReadSingleRow(dgw, reader); }
             reader.Close();
        }          
        private void Form2_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int selectedRow;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if(e.RowIndex>=0)
            { 
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 newform3 = new Form3();
            newform3.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deleteRow();
        }
        private void Update()
        { database.openConnection();
            for (int index=0; index <= 5; index++)
            { 
                var rowState =(RowState)dataGridView1.Rows[index].Cells[5].Value;
                if (rowState==RowState.Existed)
                { continue; }
                if (rowState==RowState.Deleted)
                { 
                    var ID=Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from MainTable where ID='{ID}'";
                    var command = new SqlCommand(deleteQuery, database.getConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var ID = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var ID_customer = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var Address = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var Order_amount = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var ID_executor = dataGridView1.Rows[index].Cells[4].Value.ToString();

                    var changeQuery = $"update MainTable set ID='{ID}',ID_customer='{ID_customer}',Address='{Address}',Order_amount='{Order_amount}',ID_executor='{ID_executor}'";
                    var command=new SqlCommand(changeQuery, database.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            database.closeConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Change();
        }
        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            var ID_customer = textBox1.Text;
            var Address = textBox2.Text;
            var Order_amount = textBox3.Text;
            var ID_executor = textBox4.Text;
            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() !=String.Empty)
            { 
                dataGridView1.Rows[selectedRowIndex].SetValues( ID_customer, Address, Order_amount, ID_executor);
                dataGridView1.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }
    }
}
