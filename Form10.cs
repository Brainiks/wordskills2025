//using AuthorizationApp;
//using BioMaterialApp;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace WindowsFormsApp3
{
    public partial class Form10 : Form
    {
        string connectionString = @"Data Source = REDMIBOOKPRO15/SQLEXPRESS; Intial catalog = WorldSkils_1; Integrated Security = True";
        public Form10()
        {
            InitializeComponent();
        }

        private void entry_Click(object sender, EventArgs e)
        {
            string Login = login.Text;
            string Password = password.Text;
            if (Validate(Login, Password))
            {
                showuser(Login);
                openmain(Login);
            }
        }
        private bool Validate(string Login, string Password)
        {
            string query = @"Select ID,PostID,Login,Password,FIO,LastEntry Where Login = @Login AND Password = @Password";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Login", Login);
            command.Parameters.AddWithValue("@Password", Password);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Program.CurrentUser = new User
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Login = reader["Login"].ToString(),
                    Password = reader["Password"].ToString(),
                    FIO = reader["FIO"].ToString(),
                    Role = reader["Role"].ToString(),
                    PhotoPath = reader["PhotoPath"].ToString()
                };
                return true;
            }
            return false;

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void show_CheckedChanged(object sender, EventArgs e)
        {
            password.PasswordChar = show.Checked ? '\0' : '*';
        }
        public class User
        {
            public int Id { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public string FIO { get; set; }
            public string Role { get; set; }
            public string PhotoPath { get; set; }
        }
        private void showuser(string login)
        {
            photo.Image = Image.FromFile(Program.CurrentUser.PhotoPath);
            label1.Text = $"{Program.CurrentUser.FIO}";
            label2.Text = $"Роль: {Program.CurrentUser.Role}";
            photo.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
        }

        private void openmain(string login)
        {
            Form7 mainForm = new Form7();
            mainForm.FormClosed += (s, ev) => this.Show();
            mainForm.Show();
            this.Hide();
        }

        public static class Program
        {
            public static User CurrentUser { get; set; }

            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form10());
            }
        }
    }
}

    /*private void ShowUserInfo(string login)
    {
        picUserPhoto.Image = Image.FromFile(Program.CurrentUser.PhotoPath);
        lblUserName.Text = $"{Program.CurrentUser.LastName} {Program.CurrentUser.Name}";
        lblUserRole.Text = $"Роль: {Program.CurrentUser.Role}";

        picUserPhoto.Visible = true;
        lblUserName.Visible = true;
        lblUserRole.Visible = true;
    }

    private void OpenMainForm(string login)
    {
        MainForm mainForm = new MainForm();
        mainForm.FormClosed += (s, ev) => this.Show();
        mainForm.Show();
        this.Hide();
    }
}

public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
    public string PhotoPath { get; set; }
}*/






