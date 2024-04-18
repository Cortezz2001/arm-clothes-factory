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
    public partial class AddPositionForm : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\D диск\АРМ швейная фабрика\АРМ Швейная фабрика\DB.mdf;Integrated Security=True";
        private MainForm f;
        public AddPositionForm(MainForm form)
        {
            InitializeComponent();
            f = form;
            positionFormDGV.CellEndEdit += PositionFormDGV_CellEndEdit;
        }

        private void AddPositionForm_Load(object sender, EventArgs e)
        {
            this.Text = "Добавление должности";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);

            LoadPositionData();
        }

        private void LoadPositionData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT * FROM position";
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

                    positionFormDGV.DataSource = dt;

                    // Скрываем столбец equip_ID
                    positionFormDGV.Columns["position_ID"].Visible = false;
                    positionFormDGV.Columns["name"].HeaderText = "Наименование";
                    positionFormDGV.Columns["Номер"].HeaderText = "Номер";
                    positionFormDGV.Columns["Номер"].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void CloseFormBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddPositionFormBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO position (name) VALUES (@name)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@name", "");
                    insertCommand.ExecuteNonQuery();
                    LoadPositionData();
                    f.mainDGV.DataSource = null;
                    f.materialsDGV.DataSource = null;
                    f.a_materialsDGV.DataSource = null;
                    f.comboBoxesAdded = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении должности: " + ex.Message);
            }
        }

        private void DeletePositionFormBtn_Click(object sender, EventArgs e)
        {
            if (positionFormDGV.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить выбранную запись?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string positionID = positionFormDGV.SelectedRows[0].Cells["position_ID"].Value.ToString();

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Проверяем, есть ли связанные записи в таблице "technological_process"
                            string checkQuery = "SELECT COUNT(*) FROM technological_process WHERE position_ID = @positionID";
                            SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                            checkCommand.Parameters.AddWithValue("@positionID", positionID);
                            int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                            if (count > 0)
                            {
                                MessageBox.Show("Невозможно удалить должность, так как есть связанные записи в таблице 'technological_process'.");
                                return;
                            }

                            // Удаляем запись из основной таблицы "equipment"
                            string deleteQuery = "DELETE FROM position WHERE position_ID = @positionID";
                            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                            deleteCommand.Parameters.AddWithValue("@positionID", positionID);
                            deleteCommand.ExecuteNonQuery();
                            f.mainDGV.DataSource = null;
                            f.materialsDGV.DataSource = null;
                            f.a_materialsDGV.DataSource = null;
                            f.comboBoxesAdded = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при удалении должности: " + ex.Message);
                        return;
                    }

                    // Удаляем выделенную запись из DataGridView
                    foreach (DataGridViewRow row in positionFormDGV.SelectedRows)
                    {
                        positionFormDGV.Rows.Remove(row);
                    }

                    MessageBox.Show("Запись успешно удалена.");
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления.");
            }
        }

        private void PositionFormDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow editedRow = positionFormDGV.Rows[e.RowIndex];
            string equipmentID = editedRow.Cells["position_ID"].Value.ToString();
            string columnName = positionFormDGV.Columns[e.ColumnIndex].Name;

            if (columnName == "name")
            {
                string newName = editedRow.Cells["name"].Value.ToString();

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string updateQuery = "UPDATE position SET name = @name WHERE position_ID = @positionID";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@name", newName);
                        updateCommand.Parameters.AddWithValue("@positionID", equipmentID);
                        updateCommand.ExecuteNonQuery();
                        f.mainDGV.DataSource = null;
                        f.materialsDGV.DataSource = null;
                        f.a_materialsDGV.DataSource = null;
                        f.comboBoxesAdded = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при обновлении должности: " + ex.Message);
                }
            }
        }
    }
}
