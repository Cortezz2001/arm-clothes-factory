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
    public partial class AddTechRouteForm : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\D диск\АРМ швейная фабрика\АРМ Швейная фабрика\DB.mdf;Integrated Security=True";
        private MainForm f;
        public AddTechRouteForm(MainForm form)
        {
            InitializeComponent();
            f = form;
        }

        private void CloseFormBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            int selectedProductId = Convert.ToInt32(productCB.SelectedValue); // получаем выбранный id из комбобокса
            string technologyName = technologyTB.Text;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); // Открываем подключение к базе данных
                string query = "INSERT INTO technological_route (product_id, name) VALUES (@product_id, @name)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@product_id", selectedProductId);
                    command.Parameters.AddWithValue("@name", technologyName);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Технология успешно добавлена!");
                    }
                    else
                    {
                        MessageBox.Show("Не удалось добавить запись.");
                    }
                }
            }
            technologyTB.Clear();
            f.treeView.Nodes.Clear();
            f.TreeFill(f.treeView);
        }

        private void AddTechRouteForm_Load(object sender, EventArgs e)
        {
            this.Text = "Добавление технологии";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT product_ID, name FROM product";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        productCB.DisplayMember = "name";
                        productCB.ValueMember = "product_ID";
                        productCB.DataSource = dt;
                    }
                }
            }
        }
    }
}
