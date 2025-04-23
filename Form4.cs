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
    public partial class Form4 : Form
    {
        private int yPosition = 45; // Стартовая позиция Y для новых элементов
        public Form4()
        {
            InitializeComponent();
            // Устанавливаем подсказку для поля ввода
            // В конструкторе формы или методе InitializeComponent:
            // Установите фокус на другой элемент (например, на саму форму)
            
            textBox1.Text = GetNextTubeCode().ToString();
            textBox1.ForeColor = SystemColors.GrayText;


            //textBox1.Enter += textBox1_Enter;
            //textBox1.Leave += textBox1_Leave;

        }
        private int GetNextTubeCode()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=REDMIBOOKPRO15\SQLEXPRESS;Initial Catalog=WorldSkills_1;Integrated Security=True"))
            {
                con.Open();
                string query = "SELECT MAX(TubCode) FROM Orders";
                SqlCommand command = new SqlCommand(query, con);
                var result = command.ExecuteScalar();

                // Если таблица пустая, начинаем с 1
                return result == DBNull.Value ? 1 : Convert.ToInt32(result) + 1;
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string code = textBox1.Text;
                if (!unique(code))
                {
                    MessageBox.Show("Код пробирки уже существует.");
                    return;
                }
                else
                {
                    MessageBox.Show("Код пробирки принят");
                    safecode(int.Parse(code));
                }
            }
        }

        private void safecode(int x)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=REDMIBOOKPRO15\SQLEXPRESS; Initial Catalog = WorldSkills_1; Integrated Security = True"))
            {
                connection.Open();
                string query = "Insert Into Orders (TubCode, TimeReady) Values(@Code, @CreatedDate)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Code", x);
                command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

                command.ExecuteNonQuery();
            }
        }
        /*
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите текст...")
            {
                textBox1.Text = "";
                textBox1.ForeColor = SystemColors.WindowText;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Введите текст...";
                textBox1.ForeColor = SystemColors.GrayText;
            }
        }
        */

        private bool unique(string x)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source =REDMIBOOKPRO15\SQLEXPRESS;Initial Catalog = WorldSkills_1;Integrated Security = True";
            con.Open();
            string query = "SELECT COUNT(*) FROM Orders WHERE TubCode = @TubCode";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@TubCode", x);
            int count = (int)com.ExecuteScalar();
            return count == 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void add_Click(object sender, EventArgs e)
        {
            // Создаем новое поле ввода
            TextBox newTextBox = new TextBox
            {
                Location = new Point(13, yPosition),
                Width = 128,
                Text = "Поле " + (scrollPanel.Controls.Count + 1)
            };

            // Создаем кнопку удаления
            Button deleteButton = new Button
            {
                Text = "Удалить",
                Location = new Point(170, yPosition),
                Tag = newTextBox // Связываем кнопку с TextBox
            };
            deleteButton.Click += (s, args) =>
            {
                scrollPanel.Controls.Remove((Control)((Button)s).Tag);
                scrollPanel.Controls.Remove((Button)s);
                ReorderElements(); // Переупорядочиваем оставшиеся элементы
            };

            // Добавляем элементы на Panel
            scrollPanel.Controls.Add(newTextBox);
            scrollPanel.Controls.Add(deleteButton);

            yPosition += 30; // Увеличиваем позицию для следующего элемента

            // Автоматически прокручиваем вниз при добавлении
            scrollPanel.ScrollControlIntoView(newTextBox);
        }

        private void ReorderElements()
        {
            yPosition = 10;
            foreach (Control control in scrollPanel.Controls)
            {
                if (control is TextBox)
                {
                    control.Location = new Point(10, yPosition);
                    yPosition += 30;
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            bool x = RecordExists(boxFIO.Text);
            if(x == true)
            {

            }
            else
            {
                Form6 form6 = new Form6();
                form6.Show();
            }
        }
        public bool RecordExists(string FIO)
        {
            string connectionString = @"Data Source =REDMIBOOKPRO15\SQLEXPRESS;Initial Catalog = WorldSkills_1;Integrated Security = True";
            string query = $"SELECT COUNT(1) FROM Patients WHERE FIO = @FIO";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FIO", FIO);
                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }
    }
}
