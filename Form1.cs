using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source = REDMIBOOKPRO15\SQLEXPRESS; Initial Catalog = WorldSkills_1; Integrated Security = True";
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            LoadData();
        }

        private DataTable dataTable;

        private void LoadData()
        {
            string query = "Select * From InsuranseComp";
            string connectionString = @"Data Source = REDMIBOOKPRO15\SQLEXPRESS; Initial Catalog = WorldSkills_1; Integrated Security = True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DGcomp.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = REDMIBOOKPRO15\SQLEXPRESS;Initial Catalog=WorldSkills_1; Integrated Security=True";
            con.Open();
            SqlCommand datacomand = new SqlCommand();
            datacomand.Connection = con;
            datacomand.CommandText = "INSERT INTO InsuranseComp (NameCompany, Addres, INN, PayAccount, BIK) VALUES (@red1, @red2, @red3, @red4, @red5)\r\n";
            datacomand.Parameters.AddWithValue("@red1", textBox1.Text);
            datacomand.Parameters.AddWithValue("@red2", textBox2.Text);
            datacomand.Parameters.AddWithValue("@red3", textBox3.Text);
            datacomand.Parameters.AddWithValue("@red4", textBox4.Text);
            datacomand.Parameters.AddWithValue("@red5", textBox5.Text);
            datacomand.ExecuteNonQuery();
            con.Close();
            SqlCommand comand = new SqlCommand();
            comand.Connection = con;
            comand.CommandText = "Select * from InsuranseComp";
            SqlDataAdapter dataadapter = new SqlDataAdapter();
            dataadapter.SelectCommand = comand;
            DataTable table2 = new DataTable();
            dataadapter.Fill(table2);
            DGcomp.DataSource = table2;
        }
        */
        private void toolStripTextBox1_Click_1(object sender, EventArgs e)
        {
            // Создаем экземпляр второй формы
            Form2 form2 = new Form2();

            // Открываем вторую форму
            form2.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {

            if (DGcomp.DataSource is DataTable dataTable)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM InsuranseComp", connection))
                {
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                    try
                    {
                        adapter.Update(dataTable);
                        LoadData();
                        MessageBox.Show("Изменения сохранены успешно!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка сохранения: {ex.Message}");
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (DGcomp.CurrentRow != null)
            {
                int id = Convert.ToInt32(DGcomp.CurrentRow.Cells["ID"].Value);

                string query = "DELETE FROM InsuranseComp WHERE ID = @ID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                LoadData();
            }
        }
    }
}
        






