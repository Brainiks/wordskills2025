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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source =REDMIBOOKPRO15\SQLEXPRESS;Initial Catalog = WorldSkills_1;Integrated Security = True";
            con.Open();
            string query = @"Select * from Post";
            SqlCommand command = new SqlCommand(query,con);
            SqlDataAdapter adap = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adap.Fill(table);
            table1.DataSource = table.DefaultView;
        }
        





        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source =REDMIBOOKPRO15\SQLEXPRESS;Initial Catalog = WorldSkills_1;Integrated Security = True";
            con.Open();
            SqlCommand query = new SqlCommand();
            query.CommandText = @"Insert Into Post(NamePost) Values (@rd1)";
            query.Connection = con;
            query.Parameters.AddWithValue("rd1", textBox1.Text);
            query.ExecuteNonQuery();
            con.Close();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = @"Select * from Post";
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = com;
            DataTable tab = new DataTable();
            ad.Fill(tab);
            table1.DataSource = tab;

            


        }
    }
}
