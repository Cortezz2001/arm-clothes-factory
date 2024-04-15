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

namespace АРМ_Швейная_фабрика
{
    public partial class AddProductForm : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\D диск\АРМ швейная фабрика\АРМ Швейная фабрика\DB.mdf;Integrated Security=True";
        private MainForm f;
        public AddProductForm(MainForm form)
        {
            InitializeComponent();
            f = form;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            string productName = productTB.Text;
            // Создаем новое подключение к базе данных
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO product (name) VALUES (@name)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", productName);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Изделие успешно добавлено.");
                        }
                        else
                        {
                            MessageBox.Show("Не удалось добавить запись.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении записи: " + ex.Message);
                }
            }
            productTB.Clear();
            f.treeView.Nodes.Clear();
            f.TreeFill(f.treeView);
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            this.Text = "Добавление изделия";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }

        private void CloseFormBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
