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
    public partial class Form9 : Form
    {
        string connectionString = @"Data Source = REDMIBOOKPRO15\SQLEXPRESS; Initial Catalog = WorldSkills_1; Integrated Security = True";
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = @"SELECT 
                    o.OrderDate,
                    s.Name AS ServiceName,
                    COUNT(pso.ID_услуги) AS ServiceCount,
                    COUNT(DISTINCT o.ID_пациента) AS PatientCount
                FROM Orders o
                JOIN PackageServicesInOrder pso ON o.ID = pso.ID_заказа
                JOIN Services s ON pso.ID_услуги = s.ID
                WHERE o.OrderDate BETWEEN @StartDate AND @EndDate
                GROUP BY o.OrderDate, s.Name
                ORDER BY o.OrderDate;";
            SqlConnection connection = new SqlConnection(connectionString);

        }
    }
}

