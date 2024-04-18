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
    public partial class AddAdditionalMaterialForm : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\D диск\АРМ швейная фабрика\АРМ Швейная фабрика\DB.mdf;Integrated Security=True";
        private MainForm f;
        public AddAdditionalMaterialForm(MainForm form)
        {
            InitializeComponent();
            f = form;
            a_materialsFormDGV.CellEndEdit += A_materialsFormDGV_CellEndEdit;
        }

        private void CloseFormBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadAMaterialsData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT * FROM additional_material";
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);

                    DataColumn numberColumn = new DataColumn("Номер", typeof(int));
                    dt.Columns.Add(numberColumn);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["Номер"] = i + 1;
                    }

                    dt.Columns["Номер"].SetOrdinal(0);

                    a_materialsFormDGV.DataSource = dt;

                    a_materialsFormDGV.Columns["a_material_ID"].Visible = false;
                    a_materialsFormDGV.Columns["name"].HeaderText = "Наименование";
                    a_materialsFormDGV.Columns["Номер"].HeaderText = "Номер";
                    a_materialsFormDGV.Columns["Номер"].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }
        private void AddAMaterialsFormBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO additional_material (name) VALUES (@name)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@name", "");
                    insertCommand.ExecuteNonQuery();
                    LoadAMaterialsData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении вспомогательного материала: " + ex.Message);
            }
            f.mainDGV.DataSource = null;
            f.materialsDGV.DataSource = null;
            f.a_materialsDGV.DataSource = null;
            f.comboBoxesAdded = false;
        }

        private void AddAdditionalMaterialForm_Load(object sender, EventArgs e)
        {
            this.Text = "Добавление вспомогательного материала";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);

            LoadAMaterialsData();
        }

        private void DeleteAMaterialsFormBtn_Click(object sender, EventArgs e)
        {
            if (a_materialsFormDGV.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить выбранную запись?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string a_materialID = a_materialsFormDGV.SelectedRows[0].Cells["a_material_ID"].Value.ToString();

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Удаляем записи из связанной таблицы "necessary_material"
                            string deleteNecessaryMaterialQuery = "DELETE FROM necessary_a_material WHERE a_material_ID = @a_materialID";
                            SqlCommand deleteNecessaryMaterialCommand = new SqlCommand(deleteNecessaryMaterialQuery, connection);
                            deleteNecessaryMaterialCommand.Parameters.AddWithValue("@a_materialID", a_materialID);
                            deleteNecessaryMaterialCommand.ExecuteNonQuery();

                            // Удаляем запись из основной таблицы "material"
                            string deleteMaterialQuery = "DELETE FROM additional_material WHERE a_material_ID = @a_materialID";
                            SqlCommand deleteMaterialCommand = new SqlCommand(deleteMaterialQuery, connection);
                            deleteMaterialCommand.Parameters.AddWithValue("@a_materialID", a_materialID);
                            deleteMaterialCommand.ExecuteNonQuery();
                            f.mainDGV.DataSource = null;
                            f.materialsDGV.DataSource = null;
                            f.a_materialsDGV.DataSource = null;
                            f.comboBoxesAdded = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при удалении вспомогательного материала: " + ex.Message);
                        return;
                    }

                    // Удаляем выделенную запись из DataGridView
                    foreach (DataGridViewRow row in a_materialsFormDGV.SelectedRows)
                    {
                        a_materialsFormDGV.Rows.Remove(row);
                    }

                    MessageBox.Show("Запись успешно удалена.");
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления.");
            }
        }

        private void A_materialsFormDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow editedRow = a_materialsFormDGV.Rows[e.RowIndex];
            string a_materialID = editedRow.Cells["a_material_ID"].Value.ToString();
            string columnName = a_materialsFormDGV.Columns[e.ColumnIndex].Name;

            if (columnName == "name")
            {
                string newName = editedRow.Cells["name"].Value.ToString();

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string updateQuery = "UPDATE additional_material SET name = @name WHERE a_material_ID = @a_materialID";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@name", newName);
                        updateCommand.Parameters.AddWithValue("@a_materialID", a_materialID);
                        updateCommand.ExecuteNonQuery();
                        f.mainDGV.DataSource = null;
                        f.materialsDGV.DataSource = null;
                        f.a_materialsDGV.DataSource = null;
                        f.comboBoxesAdded = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при обновлении вспомогательного материала: " + ex.Message);
                }
            }
        }
    }
}
