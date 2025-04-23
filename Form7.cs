using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WindowsFormsApp3
{
    public partial class Form7 : Form
    {
        String connectionString = @"Data Source = REDMIBOOKPRO15\SQLEXPRESS; Initial Catalog = WorldSkills_1; Integrated Security = True";
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        /*@"SELECT p.ID, p.Login, p.Password, p.FIO, p.Birthday, 
                    p.SeriesPas, p.NumberPas, p.Telephone, p.Email, p.NumberPolis,
                    it.Name AS InsuranceTypeName, ic.Name AS InsuranceCompanyName,
                    p.InsuranceTypeId, p.InsuranceCompanyId
                    FROM Patients p
                    LEFT JOIN InsuranceTypes it ON p.InsuranceTypeId = it.ID
                    LEFT JOIN InsuranceCompanies ic ON p.InsuranceCompanyId = ic.ID";
        */


        private void LoadData()
        {
            // Основные данные пациентов
            string query = @"
            SELECT 
            ID, Login, Password, FIO, Birthday, 
            SeriesPas, NumberPas, Telephone, Email, NumberPolis,
            CompanyID, TypePolisID
            FROM Patients p";

            DataTable patientsTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(patientsTable);

            // Очищаем существующие данные в DataGridView
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();

            // Привязываем данные к DataGridView
            dataGrid.DataSource = patientsTable;

            // 3. Заменяем обычные столбцы на ComboBox (после загрузки данных)
            AddComboBoxColumns();
        }

        private void AddComboBoxColumns()
        {
            // Удаляем стандартные столбцы для ID (если не нужны)
            if (dataGrid.Columns.Contains("TypePolisID"))
                dataGrid.Columns.Remove("TypePolisID");

            if (dataGrid.Columns.Contains("CompanyID"))
                dataGrid.Columns.Remove("CompanyID");

            // Добавляем ComboBox для типа полиса
            DataGridViewComboBoxColumn typeColumn = new DataGridViewComboBoxColumn();
            typeColumn.Name = "TypePolisColumn";
            typeColumn.DataPropertyName = "TypePolisID"; // Связь с исходными данными
            typeColumn.DataSource = LoadInsuranceTypes();
            typeColumn.DisplayMember = "Type";
            typeColumn.ValueMember = "Id";
            dataGrid.Columns.Add(typeColumn);

            // Добавляем ComboBox для страховой компании
            DataGridViewComboBoxColumn companyColumn = new DataGridViewComboBoxColumn();
            companyColumn.Name = "CompanyColumn";
            companyColumn.DataPropertyName = "CompanyID";
            companyColumn.DataSource = LoadInsuranceCompanies();
            companyColumn.DisplayMember = "NameCompany";
            companyColumn.ValueMember = "Id";
            dataGrid.Columns.Add(companyColumn);
        }



        // Загрузка типов страховых полисов
        private DataTable LoadInsuranceTypes()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Type FROM TypePolis";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(table);
            }
            return table;
        }

        // Загрузка страховых компаний
        private DataTable LoadInsuranceCompanies()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, NameCompany FROM InsuranseComp";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(table);
            }
            return table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        

        
         private void button2_Click(object sender, EventArgs e)
         {
             if (dataGrid.DataSource is DataTable datatable)
             {
                 string query = "Select * from Patients";
                 SqlConnection connection = new SqlConnection(connectionString);
                 SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                 SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                 adapter.Update(datatable);
                 //LoadData();
             }
         }
        private void button4_Click(object sender, EventArgs e)
        {
            // Получаем ID заказа из текстового поля
            if (int.TryParse(textBoxOrderId.Text, out int orderId))
            {
                try
                {
                    // Вызываем функцию для получения данных о заказе
                    DataTable orderData = GetOrderFromDatabase(orderId);
                    // Выводим данные в консоль для отладки
                    foreach (DataRow row in orderData.Rows)
                    {
                        Console.WriteLine($"ID: {row["ID"]}, TimeReady: {row["TimeReady"]}, PatientName: {row["PatientName"]}, BirthDate: {row["BirthDate"]}, NumberPolis: {row["NumberPolis"]}, TubCode: {row["TubCode"]}, Service: {row["Service"]}, Price: {row["Price"]}");
                    }
                    // Проверяем, есть ли данные в DataTable
                    if (orderData.Rows.Count > 0)
                    {
                        // Выводим данные в консоль для отладки
                        foreach (DataRow row in orderData.Rows)
                        {
                            Console.WriteLine($"ID: {row["ID"]}, TimeReady: {row["TimeReady"]}, PatientName: {row["PatientName"]}, BirthDate: {row["BirthDate"]}, NumberPolis: {row["NumberPolis"]}, TubCode: {row["TubCode"]}, Service: {row["Service"]}, Price: {row["Price"]}");
                        }

                        // Генерируем PDF
                        string pdfFilePath = $@"C:\Orders\Order_{orderId}.pdf";
                        GeneratePdf(orderData, pdfFilePath);

                        // Сообщение о успешной генерации PDF
                        MessageBox.Show($"PDF-файл успешно создан: {pdfFilePath}", "Успех");
                    }
                    else
                    {
                        MessageBox.Show("Заказ с указанным ID не найден.", "Информация");
                    }
                    // Проверяем, есть ли данные в DataTable
                    if (orderData.Rows.Count > 0)
                    {
                        // Генерируем PDF
                        string pdfFilePath = $@"C:\Orders\Order_{orderId}.pdf";
                        GeneratePdf(orderData, pdfFilePath);

                        // Сообщение о успешной генерации PDF
                        MessageBox.Show($"PDF-файл успешно создан: {pdfFilePath}", "Успех");
                    }
                    else
                    {
                        MessageBox.Show("Заказ с указанным ID не найден.", "Информация");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Введите корректный ID заказа.", "Ошибка");
            }
        }

        public DataTable GetOrderFromDatabase(int orderId)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                    @"SELECT 
                        ID,
                        TimeReady,
                        FIO,
                        Birthday,
                        NumberPolis,
                        TubCode,
                        Service,
                        Price
                     FROM OrderDetailsView1
                     WHERE ID = @OrderID",
                    connection))
                {
                    command.Parameters.AddWithValue("@OrderID", orderId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

        private void GeneratePdf(DataTable orderData, string filePath)
        {
            // Создаем документ PDF
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            // Получаем первую строку для общих данных о заказе
            DataRow firstRow = orderData.Rows[0];

            // Добавляем информацию о заказе
            document.Add(new Paragraph($"ID заказа: {firstRow["ID"]}"));
            document.Add(new Paragraph($"Дата заказа: {firstRow["TimeReady"]}")); // Убедитесь, что TimeReady правильно форматирован
            document.Add(new Paragraph($"ФИО пациента: {firstRow["PatientName"]}"));
            document.Add(new Paragraph($"Дата рождения: {firstRow["BirthDate"]}"));
            document.Add(new Paragraph($"Номер страхового полиса: {firstRow["NumberPolis"]}"));
            document.Add(new Paragraph($"Код пробирки: {firstRow["TubCode"]}"));

            // Таблица для услуг
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;

            // Добавляем заголовки столбцов
            table.AddCell(new PdfPCell(new Phrase("Услуга")) { HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase("Стоимость")) { HorizontalAlignment = Element.ALIGN_CENTER });

            // Проходим по всем строкам для получения услуг
            foreach (DataRow row in orderData.Rows)
            {
                table.AddCell(row["Service"].ToString());
                table.AddCell(row["Price"].ToString());
            }

            // Добавляем таблицу в документ
            document.Add(table);

            // Закрываем документ
            document.Close();
        }
    }

    /*
private void button3_Click(object sender, EventArgs e)
{
LoadData();
}

private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
{

}

private void button1_Click(object sender, EventArgs e)
{
if (dataGrid.CurrentRow != null)
{
    int id = Convert.ToInt32(dataGrid.CurrentRow.Cells["ID"].Value);
    string query = "Delete From Patients Where ID = @ID";
    SqlConnection connection = new SqlConnection(connectionString);
    SqlCommand command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue("@ID", id);
    connection.Open();
    command.ExecuteNonQuery();
}
}







/*private void button3_Click(object sender, EventArgs e)
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
}*/
}




