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
    public partial class AddEquipmentForm : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\D диск\АРМ швейная фабрика\АРМ Швейная фабрика\DB.mdf;Integrated Security=True";
        private MainForm f;
        public AddEquipmentForm(MainForm form)
        {
            InitializeComponent();
            f = form;
            equipmentFormDGV.CellEndEdit += EquipmentFormDGV_CellEndEdit;
        }

        private void AddEquipmentForm_Load(object sender, EventArgs e)
        {
            this.Text = "Добавление оборудования";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);

            LoadEquipmentData();
        }
        private void LoadEquipmentData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT * FROM equipment";
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Добавляем столбец "Номер" и заполняем его значениями от 1 до n
                    DataColumn numberColumn = new DataColumn("Номер", typeof(int));
                    dt.Columns.Add(numberColumn);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["Номер"] = i + 1;
                    }
                    dt.Columns["Номер"].SetOrdinal(0);

                    equipmentFormDGV.DataSource = dt;

                    // Скрываем столбец equip_ID
                    equipmentFormDGV.Columns["equip_ID"].Visible = false;
                    equipmentFormDGV.Columns["name"].HeaderText = "Наименование";
                    equipmentFormDGV.Columns["Номер"].HeaderText = "Номер";
                    equipmentFormDGV.Columns["Номер"].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void AddEquipmentFormBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO equipment (name) VALUES (@name)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@name", "");
                    insertCommand.ExecuteNonQuery();
                    LoadEquipmentData();
                    f.mainDGV.DataSource = null;
                    f.materialsDGV.DataSource = null;
                    f.a_materialsDGV.DataSource = null;
                    f.comboBoxesAdded = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении оборудования: " + ex.Message);
            }
        }

        private void EquipmentFormDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow editedRow = equipmentFormDGV.Rows[e.RowIndex];
            string equipmentID = editedRow.Cells["equip_ID"].Value.ToString();
            string columnName = equipmentFormDGV.Columns[e.ColumnIndex].Name;

            if (columnName == "name")
            {
                string newName = editedRow.Cells["name"].Value.ToString();

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string updateQuery = "UPDATE equipment SET name = @name WHERE equip_ID = @equipmentID";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@name", newName);
                        updateCommand.Parameters.AddWithValue("@equipmentID", equipmentID);
                        updateCommand.ExecuteNonQuery();
                        f.mainDGV.DataSource = null;
                        f.materialsDGV.DataSource = null;
                        f.a_materialsDGV.DataSource = null;
                        f.comboBoxesAdded = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при обновлении оборудования: " + ex.Message);
                }
            }
        }

        private void DeleteEquipmentFormBtn_Click(object sender, EventArgs e)
        {
            if (equipmentFormDGV.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить выбранную запись?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string equipmentID = equipmentFormDGV.SelectedRows[0].Cells["equip_ID"].Value.ToString();

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Проверяем, есть ли связанные записи в таблице "technological_process"
                            string checkQuery = "SELECT COUNT(*) FROM technological_process WHERE equip_ID = @equipmentID";
                            SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                            checkCommand.Parameters.AddWithValue("@equipmentID", equipmentID);
                            int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                            if (count > 0)
                            {
                                MessageBox.Show("Невозможно удалить оборудование, так как есть связанные записи в таблице 'technological_process'.");
                                return;
                            }

                            // Удаляем запись из основной таблицы "equipment"
                            string deleteQuery = "DELETE FROM equipment WHERE equip_ID = @equipmentID";
                            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                            deleteCommand.Parameters.AddWithValue("@equipmentID", equipmentID);
                            deleteCommand.ExecuteNonQuery();
                            f.mainDGV.DataSource = null;
                            f.materialsDGV.DataSource = null;
                            f.a_materialsDGV.DataSource = null;
                            f.comboBoxesAdded = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при удалении оборудования: " + ex.Message);
                        return;
                    }

                    // Удаляем выделенную запись из DataGridView
                    foreach (DataGridViewRow row in equipmentFormDGV.SelectedRows)
                    {
                        equipmentFormDGV.Rows.Remove(row);
                    }

                    MessageBox.Show("Запись успешно удалена.");
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления.");
            }
        }

        private void CloseFormBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
