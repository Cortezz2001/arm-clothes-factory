using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using iTextSharp.text.pdf;
namespace АРМ_Швейная_фабрика
{
    public partial class MainForm : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\D диск\АРМ швейная фабрика\АРМ Швейная фабрика\DB.mdf;Integrated Security=True";
        private bool isDragging = false;
        bool comboBoxesAdded = false;
        private int mouseX;
        private int mouseY;

        public MainForm()
        {
            InitializeComponent();
            mainDGV.CellValueChanged += new DataGridViewCellEventHandler(MainDGV_CellValueChanged);
            materialsDGV.CellValueChanged += new DataGridViewCellEventHandler(MaterialsDGV_CellValueChanged);
            a_materialsDGV.CellValueChanged += new DataGridViewCellEventHandler(A_materialsDGV_CellValueChanged);
            mainDGV.SelectionChanged += MainDGV_SelectionChanged;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
            TreeFill(treeView);
            treeView.LabelEdit = true;
        }

        private void CloseFormBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaX = e.X - mouseX;
                int deltaY = e.Y - mouseY;
                this.Location = new System.Drawing.Point(this.Left + deltaX, this.Top + deltaY);
            }
        }

        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            mouseX = e.X;
            mouseY = e.Y;
        }
        public void TreeFill(TreeView tree)
        {
            DataTable dt_products = new DataTable();
            SqlDataAdapter da_products = new SqlDataAdapter("SELECT * FROM product", connectionString);
            da_products.Fill(dt_products);

            foreach (DataRow dr_product in dt_products.Rows)
            {
                TreeNode productNode = tree.Nodes.Add(dr_product["name"].ToString());
                productNode.ImageKey = "folder.png";
                productNode.SelectedImageKey = "folder.png";
                productNode.Tag = dr_product["product_ID"]; // Устанавливаем Tag для продукта

                DataTable dt_tech_routes = new DataTable();
                SqlDataAdapter da_tech_routes = new SqlDataAdapter("SELECT * FROM technological_route WHERE product_ID = " + dr_product["product_ID"].ToString(), connectionString);
                da_tech_routes.Fill(dt_tech_routes);

                foreach (DataRow dr_node in dt_tech_routes.Rows)
                {
                    TreeNode tech_route_Node = productNode.Nodes.Add(dr_node["name"].ToString());
                    tech_route_Node.ImageKey = "route.png";
                    tech_route_Node.SelectedImageKey = "route.png";
                    tech_route_Node.Tag = dr_node["route_ID"]; // Устанавливаем Tag для маршрута
                }
            }
            treeView.ExpandAll();
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView.SelectedNode != null && treeView.SelectedNode.Level == 1)
            {
                string tech_route_name = treeView.SelectedNode.Text;
                technology_name.Text = "Технология: " + tech_route_name;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string queryRouteId = "SELECT route_ID FROM technological_route WHERE name = @tech_route_name";
                    using (SqlCommand cmdRouteId = new SqlCommand(queryRouteId, connection))
                    {
                        cmdRouteId.Parameters.AddWithValue("@tech_route_name", tech_route_name);
                        object route_ID = cmdRouteId.ExecuteScalar();

                        if (route_ID != null && route_ID != DBNull.Value)
                        {
                            int routeID = Convert.ToInt32(route_ID);

                            DataTable dt_technological_process = GetTechnologicalProcessData(routeID);
                            DataTable dt_necessary_materials = GetNecessaryMaterialsData(routeID);
                            DataTable dt_necessary_a_materials = GetNecessaryAdditionalMaterialsData(routeID);

                            DataGridViewComboBoxColumn materialColumn = new DataGridViewComboBoxColumn();
                            materialColumn.HeaderText = "Наименование";
                            materialColumn.Name = "materialColumn";
                            materialColumn.DataSource = GetMaterials(); // Получаем данные из таблицы material
                            materialColumn.DisplayMember = "name";
                            materialColumn.ValueMember = "material_ID";
                            materialColumn.DataPropertyName = "material_ID";

                            DataGridViewComboBoxColumn additionalMaterialColumn = new DataGridViewComboBoxColumn();
                            additionalMaterialColumn.HeaderText = "Наименование";
                            additionalMaterialColumn.Name = "additionalMaterialColumn";
                            additionalMaterialColumn.DataSource = GetAdditionalMaterials(); // Получаем данные из таблицы additional_material
                            additionalMaterialColumn.DisplayMember = "name";
                            additionalMaterialColumn.ValueMember = "a_material_ID";
                            additionalMaterialColumn.DataPropertyName = "a_material_ID";

                            DataGridViewComboBoxColumn equipColumn = new DataGridViewComboBoxColumn();
                            equipColumn.HeaderText = "Оборудование";
                            equipColumn.Name = "equipColumn";
                            equipColumn.DataSource = GetEquipment(); // Загрузка данных из таблицы equipment
                            equipColumn.DataPropertyName = "equip_ID";
                            equipColumn.DisplayMember = "name";
                            equipColumn.ValueMember = "equip_ID";


                            DataGridViewComboBoxColumn positionColumn = new DataGridViewComboBoxColumn();
                            positionColumn.HeaderText = "Позиция";
                            positionColumn.Name = "positionColumn";
                            positionColumn.DataSource = GetPositions(); // Загрузка данных из таблицы position
                            positionColumn.DataPropertyName = "position_ID";
                            positionColumn.DisplayMember = "name";
                            positionColumn.ValueMember = "position_ID";

                            mainDGV.DataSource = dt_technological_process;
                            int count = mainDGV.Rows.Count;
                            materialsDGV.DataSource = dt_necessary_materials;
                            a_materialsDGV.DataSource = dt_necessary_a_materials;

                            mainDGV.Columns["name"].HeaderText = "Наименование операции";
                            mainDGV.Columns["type"].HeaderText = "Способ работы";
                            mainDGV.Columns["normatives"].HeaderText = "Нормативы";
                            mainDGV.Columns["time"].HeaderText = "Время(с)";

                            materialsDGV.Columns["quantity"].HeaderText = "Количество";

                            a_materialsDGV.Columns["quantity"].HeaderText = "Количество";
                            if (!comboBoxesAdded)
                            {
                                mainDGV.Columns.Add(equipColumn);
                                mainDGV.Columns.Add(positionColumn);
                                materialsDGV.Columns.Insert(0, materialColumn);
                                a_materialsDGV.Columns.Insert(0, additionalMaterialColumn);
                                comboBoxesAdded = true;
                            }

                            materialsDGV.Columns["route_ID"].Visible = false;
                            materialsDGV.Columns["material_ID"].Visible = false;
                            materialsDGV.Columns["n_material_ID"].Visible = false;

                            a_materialsDGV.Columns["ID"].Visible = false;
                            a_materialsDGV.Columns["a_material_ID"].Visible = false;
                            a_materialsDGV.Columns["n_a_material_ID"].Visible = false;

                            mainDGV.Columns["ID"].Visible = false;
                            mainDGV.Columns["route_ID"].Visible = false;
                            mainDGV.Columns["equip_ID"].Visible = false;
                            mainDGV.Columns["position_ID"].Visible = false;
                            mainDGV.CurrentCell = null;
                            if (mainDGV.Rows.Count > 0)
                            {
                                mainDGV.Rows[0].Selected = true;
                            }

                        }
                    }
                }
            }

            materialsDGV.ColumnHeadersHeight = 25;
            a_materialsDGV.ColumnHeadersHeight = 25;
            mainDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            foreach (DataGridViewColumn column in mainDGV.Columns)
            {
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            foreach (DataGridViewColumn column in mainDGV.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private DataTable GetTechnologicalProcessData(int routeID)
        {
            DataTable dt_technological_process = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM technological_process WHERE route_ID = @RouteID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RouteID", routeID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt_technological_process);
                    }
                }
            }
            return dt_technological_process;
        }

        private DataTable GetNecessaryMaterialsData(int routeID)
        {
            DataTable dt_necessary_materials = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM necessary_material WHERE route_ID = @RouteID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RouteID", routeID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt_necessary_materials);
                    }
                }
            }
            return dt_necessary_materials;
        }

        private DataTable GetNecessaryAdditionalMaterialsData(int processID)
        {
            DataTable dt_necessary_a_materials = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM necessary_a_material WHERE ID = @ProcessID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProcessID", processID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt_necessary_a_materials);
                    }
                }
            }
            return dt_necessary_a_materials;
        }

        private void TreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {


        }

        private DataTable GetEquipment()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT equip_ID, name FROM equipment";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);
                }
            }
            return table;
        }

        private DataTable GetPositions()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT position_ID, name FROM position";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);
                }
            }
            return table;
        }

        private DataTable GetMaterials()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT material_ID, name FROM material";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
        private DataTable GetAdditionalMaterials()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT a_material_ID, name FROM additional_material";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        private void SearchBoxTV_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchBoxTV.Text.ToLower();

            foreach (TreeNode node in treeView.Nodes)
            {
                if (node.Text.ToLower().Contains(searchText))
                {
                    node.BackColor = System.Drawing.Color.LightSkyBlue;
                }
                else
                {
                    node.BackColor = System.Drawing.Color.White;
                }

                foreach (TreeNode childNode in node.Nodes)
                {
                    if (childNode.Text.ToLower().Contains(searchText))
                    {
                        childNode.BackColor = System.Drawing.Color.LightSkyBlue;
                        node.Expand();
                    }
                    else
                    {
                        childNode.BackColor = System.Drawing.Color.White;
                    }

                    foreach (TreeNode grandChildNode in childNode.Nodes)
                    {
                        if (grandChildNode.Text.ToLower().Contains(searchText))
                        {
                            grandChildNode.BackColor = System.Drawing.Color.LightSkyBlue;
                            node.Expand();
                            childNode.Expand();
                        }
                        else
                        {
                            grandChildNode.BackColor = System.Drawing.Color.White;
                        }
                        foreach (TreeNode schemeNode in grandChildNode.Nodes)
                        {
                            if (schemeNode.Text.ToLower().Contains(searchBoxTV.Text.ToLower()))
                            {
                                schemeNode.BackColor = System.Drawing.Color.LightSkyBlue;
                                schemeNode.ForeColor = System.Drawing.Color.Black;

                                schemeNode.EnsureVisible();

                                treeView.SelectedNode = schemeNode;
                            }
                            else
                            {
                                schemeNode.BackColor = System.Drawing.Color.White;
                                schemeNode.ForeColor = System.Drawing.Color.Black;
                            }
                        }
                    }
                }
            }
            if (string.IsNullOrEmpty(searchBoxTV.Text))
            {
                foreach (TreeNode node in treeView.Nodes)
                {
                    ResetNodeColor(node);
                }
            }
            else
            {
                SearchNodes(treeView.Nodes, searchBoxTV.Text);
            }

            //string searchDGV = searchBoxTV.Text.ToLower();
            //foreach (DataGridViewRow row in mainDGV.Rows)
            //{
            //    // Проход по каждой строке таблицы данных
            //    bool rowVisible = false;
            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        // Проход по каждой ячейке в строке
            //        if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchDGV))
            //        {
            //            // Если значение ячейки содержит искомый текст, то делаем строку видимой
            //            rowVisible = true;
            //            break;
            //        }
            //    }
            //    row.Visible = rowVisible;
            //}
        }

        private void ResetNodeColor(TreeNode node)
        {
            node.BackColor = System.Drawing.Color.White;
            foreach (TreeNode childNode in node.Nodes)
            {
                ResetNodeColor(childNode);
            }
        }

        private void SearchNodes(TreeNodeCollection nodes, string searchQuery)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Text.ToLower().Contains(searchQuery.ToLower()))
                {
                    node.Expand();
                    treeView.SelectedNode = node;
                    return;
                }

                if (node.Nodes.Count > 0)
                {
                    SearchNodes(node.Nodes, searchQuery);
                }

            }
        }

        private void ИзделиеtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode newNode = treeView.Nodes.Add("");
            treeView.SelectedNode = newNode;
            newNode.BeginEdit();
        }

        private void ТехнологияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null && treeView.SelectedNode.Level == 0)
            {
                TreeNode newNode = treeView.SelectedNode.Nodes.Add("");
                newNode.ImageKey = "route.png";
                newNode.SelectedImageKey = "route.png";
                treeView.SelectedNode = newNode;
                newNode.BeginEdit();
            }
        }

        private void AddMainBtn_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null && treeView.SelectedNode.Level == 1)
            {
                string tech_route_name = treeView.SelectedNode.Text;
                int routeID = -1;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT route_ID FROM technological_route WHERE name = @tech_route_name";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@tech_route_name", tech_route_name);
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            routeID = Convert.ToInt32(result);
                        }
                    }
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO technological_process (route_ID) VALUES (@RouteID); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RouteID", routeID);

                        int newID = Convert.ToInt32(command.ExecuteScalar());

                        DataTable dt = (DataTable)mainDGV.DataSource;
                        DataRow newRow = dt.NewRow();
                        newRow["ID"] = newID;
                        dt.Rows.Add(newRow);
                    }
                }
            }


        }

        private void MainDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = sender as DataGridView;
                object value;
                int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["ID"].Value);
                string columnName = dgv.Columns[e.ColumnIndex].Name;

                if (dgv.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
                {
                    DataGridViewComboBoxCell comboCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
                    value = comboCell.Value;
                }
                else
                {
                    value = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                }

                if (columnName == "equipColumn") columnName = "equip_ID";
                else if (columnName == "positionColumn") columnName = "position_ID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $"UPDATE technological_process SET {columnName} = @Value WHERE ID = @ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Value", value);
                        command.Parameters.AddWithValue("@ID", id);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private void MaterialsDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = sender as DataGridView;
                int n_material_ID = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["n_material_ID"].Value);

                string columnName = dgv.Columns[e.ColumnIndex].Name;
                object value = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "";
                    if (columnName == "quantity")
                    {
                        query = "UPDATE necessary_material SET quantity = @Value WHERE n_material_ID = @NMaterialID";
                    }
                    else if (columnName == "materialColumn")
                    {
                        query = "UPDATE necessary_material SET material_ID = @Value WHERE n_material_ID = @NMaterialID";
                    }

                    if (!string.IsNullOrEmpty(query))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Value", value);
                            command.Parameters.AddWithValue("@NMaterialID", n_material_ID);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void MainDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (mainDGV.SelectedRows.Count > 0)
            {
                int processID = Convert.ToInt32(mainDGV.SelectedRows[0].Cells["ID"].Value);

                DataTable dt_necessary_a_materials = GetNecessaryAdditionalMaterialsData(processID);
                a_materialsDGV.DataSource = dt_necessary_a_materials;
            }
        }

        private void A_materialsDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = sender as DataGridView;
                int n_a_material_ID = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["n_a_material_ID"].Value);

                string columnName = dgv.Columns[e.ColumnIndex].Name;
                object value = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "";
                    if (columnName == "quantity")
                    {
                        query = "UPDATE necessary_a_material SET quantity = @Value WHERE n_a_material_ID = @NAmaterialID";
                    }
                    else if (columnName == "additionalMaterialColumn")
                    {
                        query = "UPDATE necessary_a_material SET a_material_ID = @Value WHERE n_a_material_ID = @NAmaterialID";
                    }

                    if (!string.IsNullOrEmpty(query))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Value", value);
                            command.Parameters.AddWithValue("@NAmaterialID", n_a_material_ID);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void AddMaterialsDGV_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null && treeView.SelectedNode.Level == 1)
            {
                string tech_route_name = treeView.SelectedNode.Text;
                int routeID = -1;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT route_ID FROM technological_route WHERE name = @tech_route_name";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@tech_route_name", tech_route_name);
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            routeID = Convert.ToInt32(result);
                        }
                    }
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO necessary_material (route_ID) VALUES (@RouteID); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RouteID", routeID);

                        int newID = Convert.ToInt32(command.ExecuteScalar());

                        DataTable dt = (DataTable)materialsDGV.DataSource;
                        DataRow newRow = dt.NewRow();
                        newRow["n_material_ID"] = newID;
                        dt.Rows.Add(newRow);
                    }
                }
            }
        }

        private void AddAMaterialsBtn_Click(object sender, EventArgs e)
        {
            if (mainDGV.SelectedRows.Count > 0)
            {
                int selectedID = Convert.ToInt32(mainDGV.SelectedRows[0].Cells["ID"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO necessary_a_material (ID) VALUES (@SelectedID); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SelectedID", selectedID);

                        int newID = Convert.ToInt32(command.ExecuteScalar());

                        DataTable dt = (DataTable)a_materialsDGV.DataSource;
                        DataRow newRow = dt.NewRow();
                        newRow["n_a_material_ID"] = newID;
                        dt.Rows.Add(newRow);
                    }
                }
            }
        }

        private void УдалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null)
            {
                string itemName = treeView.SelectedNode.Text;
                DialogResult result = MessageBox.Show($"Вы действительно хотите удалить \"{itemName}\"?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (treeView.SelectedNode.Level == 0) // Удаление продукта и связанных данных
                    {
                        string productName = treeView.SelectedNode.Text;

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string getProductIDQuery = "SELECT product_ID FROM product WHERE name = @ProductName";
                            int productID;
                            using (SqlCommand command = new SqlCommand(getProductIDQuery, connection))
                            {
                                command.Parameters.AddWithValue("@ProductName", productName);
                                productID = (int)command.ExecuteScalar();
                            }

                            string getRoutesQuery = "SELECT route_ID FROM technological_route WHERE product_ID = @ProductID";
                            List<int> routeIDs = new List<int>();
                            using (SqlCommand command = new SqlCommand(getRoutesQuery, connection))
                            {
                                command.Parameters.AddWithValue("@ProductID", productID);
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        routeIDs.Add(reader.GetInt32(0));
                                    }
                                }
                            }

                            foreach (int routeID in routeIDs)
                            {
                                string deleteNecessaryMaterialQuery = "DELETE FROM necessary_material WHERE route_ID = @RouteID";
                                using (SqlCommand command = new SqlCommand(deleteNecessaryMaterialQuery, connection))
                                {
                                    command.Parameters.AddWithValue("@RouteID", routeID);
                                    command.ExecuteNonQuery();
                                }

                                string getProcessesQuery = "SELECT ID FROM technological_process WHERE route_ID = @RouteID";
                                List<int> processIDs = new List<int>();
                                using (SqlCommand command = new SqlCommand(getProcessesQuery, connection))
                                {
                                    command.Parameters.AddWithValue("@RouteID", routeID);
                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            processIDs.Add(reader.GetInt32(0));
                                        }
                                    }
                                }

                                foreach (int processID in processIDs)
                                {
                                    string deleteNecessaryAMaterialQuery = "DELETE FROM necessary_a_material WHERE ID = @ProcessID";
                                    using (SqlCommand command = new SqlCommand(deleteNecessaryAMaterialQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@ProcessID", processID);
                                        command.ExecuteNonQuery();
                                    }
                                }

                                string deleteTechnologicalProcessQuery = "DELETE FROM technological_process WHERE route_ID = @RouteID";
                                using (SqlCommand command = new SqlCommand(deleteTechnologicalProcessQuery, connection))
                                {
                                    command.Parameters.AddWithValue("@RouteID", routeID);
                                    command.ExecuteNonQuery();
                                }
                            }

                            string deleteRoutesQuery = "DELETE FROM technological_route WHERE product_ID = @ProductID";
                            using (SqlCommand command = new SqlCommand(deleteRoutesQuery, connection))
                            {
                                command.Parameters.AddWithValue("@ProductID", productID);
                                command.ExecuteNonQuery();
                            }

                            string deleteProductQuery = "DELETE FROM product WHERE product_ID = @ProductID";
                            using (SqlCommand command = new SqlCommand(deleteProductQuery, connection))
                            {
                                command.Parameters.AddWithValue("@ProductID", productID);
                                command.ExecuteNonQuery();
                            }
                        }

                        treeView.SelectedNode.Remove();
                    }
                    else if (treeView.SelectedNode.Level == 1) // Удаление маршрута и связанных данных
                    {
                        string routeName = treeView.SelectedNode.Text;

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string getRouteIDQuery = "SELECT route_ID FROM technological_route WHERE name = @RouteName";
                            int routeID;
                            using (SqlCommand command = new SqlCommand(getRouteIDQuery, connection))
                            {
                                command.Parameters.AddWithValue("@RouteName", routeName);
                                routeID = (int)command.ExecuteScalar();
                            }

                            string deleteNecessaryAMaterialQuery = "DELETE FROM necessary_a_material WHERE ID IN (SELECT ID FROM technological_process WHERE route_ID = @RouteID)";
                            using (SqlCommand command = new SqlCommand(deleteNecessaryAMaterialQuery, connection))
                            {
                                command.Parameters.AddWithValue("@RouteID", routeID);
                                command.ExecuteNonQuery();
                            }

                            string deleteNecessaryMaterialQuery = "DELETE FROM necessary_material WHERE route_ID = @RouteID";
                            using (SqlCommand command = new SqlCommand(deleteNecessaryMaterialQuery, connection))
                            {
                                command.Parameters.AddWithValue("@RouteID", routeID);
                                command.ExecuteNonQuery();
                            }

                            string deleteTechnologicalProcessQuery = "DELETE FROM technological_process WHERE route_ID = @RouteID";
                            using (SqlCommand command = new SqlCommand(deleteTechnologicalProcessQuery, connection))
                            {
                                command.Parameters.AddWithValue("@RouteID", routeID);
                                command.ExecuteNonQuery();
                            }

                            string deleteRouteQuery = "DELETE FROM technological_route WHERE route_ID = @RouteID";
                            using (SqlCommand command = new SqlCommand(deleteRouteQuery, connection))
                            {
                                command.Parameters.AddWithValue("@RouteID", routeID);
                                command.ExecuteNonQuery();
                            }
                        }

                        treeView.SelectedNode.Parent.Nodes.Remove(treeView.SelectedNode);
                    }
                }
            }
        }

        private void DeleteMainBtn_Click(object sender, EventArgs e)
        {
            if (mainDGV.SelectedRows.Count > 0)
            {
                int selectedRowID = Convert.ToInt32(mainDGV.SelectedRows[0].Cells["ID"].Value);

                DialogResult result = MessageBox.Show("Вы действительно хотите удалить выбранную запись?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string deleteNecessaryAMaterialQuery = "DELETE FROM necessary_a_material WHERE ID = @SelectedRowID";
                        using (SqlCommand command = new SqlCommand(deleteNecessaryAMaterialQuery, connection))
                        {
                            command.Parameters.AddWithValue("@SelectedRowID", selectedRowID);
                            command.ExecuteNonQuery();
                        }

                        string deleteTechnologicalProcessQuery = "DELETE FROM technological_process WHERE ID = @SelectedRowID";
                        using (SqlCommand command = new SqlCommand(deleteTechnologicalProcessQuery, connection))
                        {
                            command.Parameters.AddWithValue("@SelectedRowID", selectedRowID);
                            command.ExecuteNonQuery();
                        }
                    }

                    mainDGV.Rows.RemoveAt(mainDGV.SelectedRows[0].Index);
                }
            }
        }

        private void DeleteMaterialsDGV_Click(object sender, EventArgs e)
        {
            if (materialsDGV.SelectedRows.Count > 0)
            {
                int selectedRowID = Convert.ToInt32(materialsDGV.SelectedRows[0].Cells["n_material_ID"].Value);

                DialogResult result = MessageBox.Show("Вы действительно хотите удалить выбранную запись?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string deleteNecessaryMaterialQuery = "DELETE FROM necessary_material WHERE n_material_ID = @SelectedRowID";
                        using (SqlCommand command = new SqlCommand(deleteNecessaryMaterialQuery, connection))
                        {
                            command.Parameters.AddWithValue("@SelectedRowID", selectedRowID);
                            command.ExecuteNonQuery();
                        }
                    }

                    materialsDGV.Rows.RemoveAt(materialsDGV.SelectedRows[0].Index);
                }
            }
        }

        private void DeleteAMaterialsDGV_Click(object sender, EventArgs e)
        {
            if (a_materialsDGV.SelectedRows.Count > 0)
            {
                int selectedRowID = Convert.ToInt32(a_materialsDGV.SelectedRows[0].Cells["n_a_material_ID"].Value);

                DialogResult result = MessageBox.Show("Вы действительно хотите удалить выбранную запись?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string deleteNecessaryAMaterialQuery = "DELETE FROM necessary_a_material WHERE n_a_material_ID = @SelectedRowID";
                        using (SqlCommand command = new SqlCommand(deleteNecessaryAMaterialQuery, connection))
                        {
                            command.Parameters.AddWithValue("@SelectedRowID", selectedRowID);
                            command.ExecuteNonQuery();
                        }
                    }

                    a_materialsDGV.Rows.RemoveAt(a_materialsDGV.SelectedRows[0].Index);
                }
            }
        }

        private void РедактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null)
            {
                treeView.SelectedNode.BeginEdit();
            }
        }

        private void TreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node != null && e.Label != null)
            {
                if (e.Node.Level == 0)
                {
                    int? productID = e.Node.Tag as int?;
                    string newName = e.Label;

                    if (productID == null)
                    {
                        string insertQuery = "INSERT INTO product (name) VALUES (@Name); SELECT SCOPE_IDENTITY();";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            using (SqlCommand command = new SqlCommand(insertQuery, connection))
                            {
                                command.Parameters.AddWithValue("@Name", newName);

                                connection.Open();
                                productID = Convert.ToInt32(command.ExecuteScalar());
                            }
                        }
                    }
                    else
                    {

                        string query = "UPDATE product SET name = @Name WHERE product_ID = @ProductID";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Name", newName);
                                command.Parameters.AddWithValue("@ProductID", productID);

                                connection.Open();
                                command.ExecuteNonQuery();
                            }
                        }
                    }

                }
                else if (e.Node.Level == 1)
                {
                    int? routeID = e.Node.Tag as int?;
                    string newName = e.Label;

                    int? productID = (e.Node.Parent.Tag as int?) ?? null;

                    if (routeID == null && productID != null)
                    {
                        string insertQuery = "INSERT INTO technological_route (name, product_ID) VALUES (@Name, @ProductID); SELECT SCOPE_IDENTITY();";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            using (SqlCommand command = new SqlCommand(insertQuery, connection))
                            {
                                command.Parameters.AddWithValue("@Name", newName);
                                command.Parameters.AddWithValue("@ProductID", productID);

                                connection.Open();
                                routeID = Convert.ToInt32(command.ExecuteScalar());
                            }
                        }
                    }
                    else
                    {
                        string query = "UPDATE technological_route SET name = @Name WHERE route_ID = @RouteID";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Name", newName);
                                command.Parameters.AddWithValue("@RouteID", routeID);

                                connection.Open();
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Элемент не может быть пустым", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Node.Remove();
            }
        }

        private void SearchBoxDGV_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchBoxDGV.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                if (mainDGV.Rows.Count > 0)
                {
                    mainDGV.Rows[0].Selected = true;
                }

                foreach (DataGridViewRow row in mainDGV.Rows)
                {
                    if (row.Index != 0)
                    {
                        row.Selected = false;
                    }
                }

                return;
            }

            foreach (DataGridViewRow row in mainDGV.Rows)
            {
                bool rowFound = false;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell is DataGridViewComboBoxCell comboBoxCell)
                    {
                        if (comboBoxCell.FormattedValue != null && comboBoxCell.FormattedValue.ToString().ToLower().Contains(searchText))
                        {
                            row.Selected = true;
                            rowFound = true;
                            break;
                        }
                    }
                    else if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchText))
                    {
                        row.Selected = true;
                        rowFound = true;
                        break;
                    }
                }

                if (!rowFound)
                {
                    row.Selected = false;
                }
            }
        }

        private void FilterBoxDGV_TextChanged(object sender, EventArgs e)
        {
            string filterText = filterBoxDGV.Text.ToLower();

            foreach (DataGridViewRow row in mainDGV.Rows)
            {
                bool rowVisible = false;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell is DataGridViewComboBoxCell comboBoxCell)
                    {
                        if (comboBoxCell.FormattedValue != null && comboBoxCell.FormattedValue.ToString().ToLower().Contains(filterText))
                        {
                            row.Visible = true;
                            rowVisible = true;
                            break;
                        }
                    }
                    else if (cell.Value != null && cell.Value.ToString().ToLower().Contains(filterText))
                    {
                        row.Visible = true;
                        rowVisible = true;
                        break;
                    }
                }

                if (!rowVisible)
                {
                    row.Visible = false;
                }
            }
        }

        private void WordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView.SelectedNode;
            string selectedElement = selectedNode.Text;

            // Создание диалога для выбора пути сохранения файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word файл (*.docx)|*.docx";
            saveFileDialog.Title = "Выберите место сохранения файла";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Создание нового документа Word
                Word.Application wordApp = new Word.Application();
                Word.Document doc = wordApp.Documents.Add();
                doc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

                // Добавление заголовка "Технологическая карта - [name]"
                Word.Paragraph title = doc.Content.Paragraphs.Add();
                title.Range.Text = "Технологическая карта - " + selectedElement;
                title.Range.InsertParagraphAfter();

                // Выполнение SQL-запроса для получения данных
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = @"SELECT technological_process.ID, technological_process.name AS Операция, type AS Способ_обработки, time AS Время_с, 
                                    equip.name AS Оборудование, position.name AS Исполнитель,
                                    am.name AS Вспомогательный_материал, nam.quantity AS Количество
                                    FROM technological_process 
                                    LEFT JOIN equipment equip ON technological_process.equip_ID = equip.equip_ID 
                                    LEFT JOIN position ON technological_process.position_ID = position.position_ID 
                                    LEFT JOIN necessary_a_material nam ON technological_process.ID = nam.ID
                                    LEFT JOIN additional_material am ON nam.a_material_ID = am.a_material_ID
                                    WHERE route_ID IN (SELECT route_ID FROM technological_route WHERE name = @selectedElement)";

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@selectedElement", selectedElement);
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }

                // Добавление таблицы с данными из technological_process и necessary_a_material
                Word.Table table = doc.Tables.Add(title.Range, dt.Rows.Count + 1, dt.Columns.Count);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    table.Cell(1, i + 1).Range.Text = dt.Columns[i].ColumnName;
                    table.Cell(1, i + 1).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25; // Изменение цвета фона заголовков
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        table.Cell(i + 2, j + 1).Range.Text = dt.Rows[i][j].ToString();
                    }
                }

                // Переименование столбцов
                table.Columns[1].Cells[1].Range.Text = "Номер";
                table.Columns[2].Cells[1].Range.Text = "Операция";
                table.Columns[3].Cells[1].Range.Text = "Способ обработки";
                table.Columns[4].Cells[1].Range.Text = "Время(с)";
                table.Columns[5].Cells[1].Range.Text = "Оборудование";
                table.Columns[6].Cells[1].Range.Text = "Исполнитель";
                table.Columns[7].Cells[1].Range.Text = "Вспомогательный материал";
                table.Columns[8].Cells[1].Range.Text = "Количество";

                // Добавление отступа между таблицами
                Word.Paragraph paragraphSpace = doc.Content.Paragraphs.Add();
                paragraphSpace.Range.InsertParagraphBefore();

                // Добавление заголовка "Необходимые материалы"
                Word.Paragraph materialsTitle = doc.Content.Paragraphs.Add();
                materialsTitle.Range.Text = "Необходимые материалы";
                materialsTitle.Range.InsertParagraphAfter();

                // Выполнение SQL-запроса для получения данных о необходимых материалах
                DataTable materialsDt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = @"SELECT material.name AS Сырье, quantity AS Количество
                                    FROM necessary_material 
                                    LEFT JOIN material ON necessary_material.material_ID = material.material_ID 
                                    WHERE route_ID IN (SELECT route_ID FROM technological_route WHERE name = @selectedElement)";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@selectedElement", selectedElement);
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(materialsDt);
                    }
                }

                // Добавление таблицы с данными о необходимых материалах
                Word.Table materialsTable = doc.Tables.Add(materialsTitle.Range, materialsDt.Rows.Count + 1, materialsDt.Columns.Count);
                for (int i = 0; i < materialsDt.Columns.Count; i++)
                {
                    materialsTable.Cell(1, i + 1).Range.Text = materialsDt.Columns[i].ColumnName;
                    materialsTable.Cell(1, i + 1).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25; // Изменение цвета фона заголовков
                }
                for (int i = 0; i < materialsDt.Rows.Count; i++)
                {
                    for (int j = 0; j < materialsDt.Columns.Count; j++)
                    {
                        materialsTable.Cell(i + 2, j + 1).Range.Text = materialsDt.Rows[i][j].ToString();
                    }
                }

                // Переименование столбцов в таблице с материалами
                materialsTable.Columns[1].Cells[1].Range.Text = "Сырье";
                materialsTable.Columns[2].Cells[1].Range.Text = "Количество";

                // Добавление границ для таблиц
                table.Borders.Enable = 1; // wdBorderTop, wdBorderLeft, wdBorderBottom, wdBorderRight
                materialsTable.Borders.Enable = 1; // wdBorderTop, wdBorderLeft, wdBorderBottom, wdBorderRight

                // Сохранение документа
                doc.SaveAs2(filePath);
                doc.Close();
                wordApp.Quit();

                Console.WriteLine("Отчет успешно сформирован и сохранен по пути: " + filePath);
            }
            else
            {
                Console.WriteLine("Отменено пользователем.");
            }
        }

        private void ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView.SelectedNode;
            string selectedElement = selectedNode.Text;

            // Создание диалога для выбора пути сохранения файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel файл (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Выберите место сохранения файла";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Создание нового документа Excel
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.ActiveSheet;

                // Добавление заголовка "Технологическая карта - [name]"
                worksheet.Cells[1, 1] = "Технологическая карта - " + selectedElement;

                // Выполнение SQL-запроса для получения данных
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = @"SELECT technological_process.ID, technological_process.name AS Операция, type AS Способ_обработки, time AS Время_с, 
                            equip.name AS Оборудование, position.name AS Исполнитель,
                            am.name AS Вспомогательный_материал, nam.quantity AS Количество
                            FROM technological_process 
                            LEFT JOIN equipment equip ON technological_process.equip_ID = equip.equip_ID 
                            LEFT JOIN position ON technological_process.position_ID = position.position_ID 
                            LEFT JOIN necessary_a_material nam ON technological_process.ID = nam.ID
                            LEFT JOIN additional_material am ON nam.a_material_ID = am.a_material_ID
                            WHERE route_ID IN (SELECT route_ID FROM technological_route WHERE name = @selectedElement)";

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@selectedElement", selectedElement);
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }

                // Добавление таблицы с данными из technological_process и necessary_a_material
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[3, i + 1] = dt.Columns[i].ColumnName;
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 4, j + 1] = dt.Rows[i][j].ToString();
                    }
                }

                // Переименование столбцов
                worksheet.Cells[3, 1] = "Номер";
                worksheet.Cells[3, 2] = "Операция";
                worksheet.Cells[3, 3] = "Способ обработки";
                worksheet.Cells[3, 4] = "Время(с)";
                worksheet.Cells[3, 5] = "Оборудование";
                worksheet.Cells[3, 6] = "Исполнитель";
                worksheet.Cells[3, 7] = "Вспомогательный материал";
                worksheet.Cells[3, 8] = "Количество";

                // Добавление отступа между таблицами
                Excel.Range range = worksheet.Range[worksheet.Cells[dt.Rows.Count + 5, 1], worksheet.Cells[dt.Rows.Count + 5, dt.Columns.Count]];
                range.Merge();
                range.Value = "Необходимые материалы";

                // Выполнение SQL-запроса для получения данных о необходимых материалах
                DataTable materialsDt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = @"SELECT material.name AS Сырье, quantity AS Количество
                            FROM necessary_material 
                            LEFT JOIN material ON necessary_material.material_ID = material.material_ID 
                            WHERE route_ID IN (SELECT route_ID FROM technological_route WHERE name = @selectedElement)";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@selectedElement", selectedElement);
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(materialsDt);
                    }
                }

                // Добавление таблицы с данными о необходимых материалах
                for (int i = 0; i < materialsDt.Columns.Count; i++)
                {
                    worksheet.Cells[dt.Rows.Count + 6, i + 1] = materialsDt.Columns[i].ColumnName;
                }
                for (int i = 0; i < materialsDt.Rows.Count; i++)
                {
                    for (int j = 0; j < materialsDt.Columns.Count; j++)
                    {
                        worksheet.Cells[i + dt.Rows.Count + 7, j + 1] = materialsDt.Rows[i][j].ToString();
                    }
                }

                // Переименование столбцов в таблице с материалами
                worksheet.Cells[dt.Rows.Count + 6, 1] = "Сырье";
                worksheet.Cells[dt.Rows.Count + 6, 2] = "Количество";

                // Автоподгон ширины ячеек
                worksheet.Columns.AutoFit();

                // Сохранение документа
                workbook.SaveAs(filePath);
                workbook.Close();
                excelApp.Quit();

                Console.WriteLine("Отчет успешно сформирован и сохранен по пути: " + filePath);
            }
            else
            {
                Console.WriteLine("Отменено пользователем.");
            }
        }
    }
}
   






