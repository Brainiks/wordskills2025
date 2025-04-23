using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con  = new SqlConnection();
            con.ConnectionString = @"Data Source = REDMIBOOKPRO15\SQLEXPRESS;Initial Catalog=WorldSkills_1; Integrated Security=True";
            con.Open();
            string query = "Select * from Patients";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            con.Close();
            data.DataSource = table.DefaultView; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = REDMIBOOKPRO15\SQLEXPRESS;Initial Catalog=WorldSkills_1; Integrated Security=True";
            con.Open();
            SqlCommand datacom = new SqlCommand();
            datacom.Connection = con;
            datacom.CommandText = "Insert Into Patients(Login, Password, FIO, Birthday, SeriesPas, NumberPas, Telephone, Email, NumberPolis) Values (@rd1,@rd2,@rd3,@rd4,@rd5,@rd6,@rd7,@rd8,@rd9)";
            datacom.Parameters.AddWithValue("@rd1", textBox1.Text);
            datacom.Parameters.AddWithValue("@rd2", textBox2.Text);
            datacom.Parameters.AddWithValue("@rd3", textBox3.Text);
            datacom.Parameters.AddWithValue("@rd4", textBox4.Text);
            datacom.Parameters.AddWithValue("@rd5", textBox5.Text);
            datacom.Parameters.AddWithValue("@rd6", textBox6.Text);
            datacom.Parameters.AddWithValue("@rd7", textBox7.Text);
            datacom.Parameters.AddWithValue("@rd8", textBox8.Text);
            datacom.Parameters.AddWithValue("@rd9", textBox9.Text);
            datacom.ExecuteNonQuery();
            con.Close();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "Select * from Patients";
            SqlDataAdapter adap = new SqlDataAdapter();
            adap.SelectCommand = com;
            DataTable table1 = new DataTable();
            adap.Fill(table1);
            data.DataSource = table1.DefaultView;
        }
    }
}
