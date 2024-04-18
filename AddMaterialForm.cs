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
    public partial class AddMaterialForm : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\D диск\АРМ швейная фабрика\АРМ Швейная фабрика\DB.mdf;Integrated Security=True";
        private MainForm f;
        public AddMaterialForm(MainForm form)
        {
            InitializeComponent();
            f = form;
            materialsFormDGV.CellEndEdit += MaterialsFormDGV_CellEndEdit;
        }


        private void CloseFormBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadMaterialsData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT * FROM material";
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

                    materialsFormDGV.DataSource = dt;

                    materialsFormDGV.Columns["material_ID"].Visible = false; 
                    materialsFormDGV.Columns["name"].HeaderText = "Наименование";
                    materialsFormDGV.Columns["Номер"].HeaderText = "Номер";
                    materialsFormDGV.Columns["Номер"].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }
        private void AddMaterialForm_Load(object sender, EventArgs e)
        {
            this.Text = "Добавление сырья";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);

            LoadMaterialsData();
        }

        private void AddMaterialsFormBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO material (name) VALUES (@name)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@name", ""); 
                    insertCommand.ExecuteNonQuery();
                    LoadMaterialsData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении материала: " + ex.Message);
            }
            f.mainDGV.DataSource = null;
            f.materialsDGV.DataSource = null;
            f.a_materialsDGV.DataSource = null;
            f.comboBoxesAdded = false;
        }

        private void MaterialsFormDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow editedRow = materialsFormDGV.Rows[e.RowIndex];
            string materialID = editedRow.Cells["material_ID"].Value.ToString(); 
            string columnName = materialsFormDGV.Columns[e.ColumnIndex].Name; 

            if (columnName == "name") 
            {
                string newName = editedRow.Cells["name"].Value.ToString(); 

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string updateQuery = "UPDATE material SET name = @name WHERE material_ID = @materialID";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@name", newName);
                        updateCommand.Parameters.AddWithValue("@materialID", materialID);
                        updateCommand.ExecuteNonQuery();
                        f.mainDGV.DataSource = null;
                        f.materialsDGV.DataSource = null;
                        f.a_materialsDGV.DataSource = null;
                        f.comboBoxesAdded = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при обновлении сырья: " + ex.Message);
                }
            }
        }

        private void DeleteMaterialsFormBtn_Click(object sender, EventArgs e)
        {
            if (materialsFormDGV.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить выбранную запись?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string materialID = materialsFormDGV.SelectedRows[0].Cells["material_ID"].Value.ToString();

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Удаляем записи из связанной таблицы "necessary_material"
                            string deleteNecessaryMaterialQuery = "DELETE FROM necessary_material WHERE material_ID = @materialID";
                            SqlCommand deleteNecessaryMaterialCommand = new SqlCommand(deleteNecessaryMaterialQuery, connection);
                            deleteNecessaryMaterialCommand.Parameters.AddWithValue("@materialID", materialID);
                            deleteNecessaryMaterialCommand.ExecuteNonQuery();

                            // Удаляем запись из основной таблицы "material"
                            string deleteMaterialQuery = "DELETE FROM material WHERE material_ID = @materialID";
                            SqlCommand deleteMaterialCommand = new SqlCommand(deleteMaterialQuery, connection);
                            deleteMaterialCommand.Parameters.AddWithValue("@materialID", materialID);
                            deleteMaterialCommand.ExecuteNonQuery();
                            f.mainDGV.DataSource = null;
                            f.materialsDGV.DataSource = null;
                            f.a_materialsDGV.DataSource = null;
                            f.comboBoxesAdded = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при удалении сырья: " + ex.Message);
                        return;
                    }

                    // Удаляем выделенную запись из DataGridView
                    foreach (DataGridViewRow row in materialsFormDGV.SelectedRows)
                    {
                        materialsFormDGV.Rows.Remove(row);
                    }

                    MessageBox.Show("Запись успешно удалена.");
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления.");
            }
        }
    }
}
