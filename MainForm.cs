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
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
            TreeFill(treeView);
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


                DataTable dt_tech_routes = new DataTable();
                SqlDataAdapter da_tech_routes = new SqlDataAdapter("SELECT * FROM technological_route WHERE product_ID = " + dr_product["product_ID"].ToString(), connectionString);
                da_tech_routes.Fill(dt_tech_routes);

                foreach (DataRow dr_node in dt_tech_routes.Rows)
                {
                    TreeNode tech_route_Node = productNode.Nodes.Add(dr_node["name"].ToString());
                    tech_route_Node.ImageKey = "route.png";
                    tech_route_Node.SelectedImageKey = "route.png";


                }
            }
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null && e.Node.Parent.Parent == null)
            {
                technology_name.Text = "Технология: " + e.Node.Text;
            }

            if (treeView.SelectedNode != null && treeView.SelectedNode.Level == 1)
            {
                string tech_route_name = treeView.SelectedNode.Text;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string queryRouteId = "SELECT route_ID FROM technological_route WHERE name = @tech_route_name";
                    using (SqlCommand cmdRouteId = new SqlCommand(queryRouteId, connection))
                    {
                        cmdRouteId.Parameters.AddWithValue("@tech_route_name", tech_route_name);
                        string route_ID = cmdRouteId.ExecuteScalar()?.ToString(); // Используем безопасную навигацию

                        if (!string.IsNullOrEmpty(route_ID))
                        {
                            string queryProcessID = "SELECT ID FROM technological_process WHERE route_ID = @route_ID";
                            using (SqlCommand cmdProcessID = new SqlCommand(queryProcessID, connection))
                            {
                                cmdProcessID.Parameters.AddWithValue("@route_ID", route_ID);
                                int processID = (int)(cmdProcessID.ExecuteScalar() ?? 0); // Используем безопасную навигацию
                                LoadMaterials(processID);
                            }
                        }

                        string queryProcesses = "SELECT ID, name, type, normatives, time, route_ID, equip_ID, position_ID FROM technological_process WHERE route_ID = @route_ID";
                        using (SqlCommand cmdProcesses = new SqlCommand(queryProcesses, connection))
                        {
                            cmdProcesses.Parameters.AddWithValue("@route_ID", route_ID);
                            SqlDataAdapter adapter = new SqlDataAdapter(cmdProcesses);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Добавляем пустую строку, если таблица пуста
                            if (dataTable.Rows.Count == 0)
                            {
                                dataTable.Rows.Add(dataTable.NewRow());
                            }

                            // Привязываем данные к mainDGV
                            mainDGV.DataSource = dataTable;

                            // Добавляем колонки ComboBox, если это еще не сделано
                            if (!comboBoxesAdded)
                            {
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

                                mainDGV.Columns.Add(equipColumn);
                                mainDGV.Columns.Add(positionColumn);

                                comboBoxesAdded = true;
                            }

                            // Устанавливаем стили и размеры ячеек
                            mainDGV.Columns["ID"].HeaderText = "Номер";
                            mainDGV.Columns["name"].HeaderText = "Наименование операции";
                            mainDGV.Columns["type"].HeaderText = "Способ работы";
                            mainDGV.Columns["normatives"].HeaderText = "Нормативы";
                            mainDGV.Columns["time"].HeaderText = "Время(с)";
                            mainDGV.Columns["route_ID"].Visible = false;
                            mainDGV.Columns["equip_ID"].Visible = false;
                            mainDGV.Columns["position_ID"].Visible = false;
                            mainDGV.CurrentCell = null;
                        }
                    }
                }
            }

            // Устанавливаем размеры и стили ячеек в DataGridView для материалов
            materialsDGV.ColumnHeadersHeight = 25;
            a_materialsDGV.ColumnHeadersHeight = 25;
            mainDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            foreach (DataGridViewColumn column in mainDGV.Columns)
            {
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void TreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {


        }
        private void LoadMaterials(int processID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Загрузка материалов
                string queryMaterials = "SELECT m.name AS MaterialName, nm.quantity " +
                                        "FROM necessary_materials nm " +
                                        "INNER JOIN materials m ON nm.material_ID = m.material_ID " +
                                        "WHERE nm.ID = @processID";
                using (SqlCommand cmdMaterials = new SqlCommand(queryMaterials, connection))
                {
                    cmdMaterials.Parameters.AddWithValue("@processID", processID);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmdMaterials);
                    DataTable materialsTable = new DataTable();
                    adapter.Fill(materialsTable);
                    materialsDGV.DataSource = materialsTable;
                    materialsDGV.Columns["MaterialName"].HeaderText = "Наименование";
                    materialsDGV.Columns["quantity"].HeaderText = "Количество";
                }

                // Загрузка дополнительных материалов
                string queryAdditionalMaterials = "SELECT am.name AS AdditionalMaterialName, nam.quantity " +
                                                   "FROM necessary_a_materials nam " +
                                                   "INNER JOIN additional_materials am ON nam.a_material_ID = am.a_material_ID " +
                                                   "WHERE nam.ID = @processID";
                using (SqlCommand cmdAdditionalMaterials = new SqlCommand(queryAdditionalMaterials, connection))
                {
                    cmdAdditionalMaterials.Parameters.AddWithValue("@processID", processID);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmdAdditionalMaterials);
                    DataTable additionalMaterialsTable = new DataTable();
                    adapter.Fill(additionalMaterialsTable);
                    a_materialsDGV.DataSource = additionalMaterialsTable;
                    a_materialsDGV.Columns["AdditionalMaterialName"].HeaderText = "Наименование";
                    a_materialsDGV.Columns["quantity"].HeaderText = "Количество";
                }

            }
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

        private void SearchBoxTV_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchBoxTV.Text.ToLower();

            foreach (TreeNode node in treeView.Nodes)
            {
                if (node.Text.ToLower().Contains(searchText))
                {
                    node.BackColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    node.BackColor = System.Drawing.Color.White;
                }

                foreach (TreeNode childNode in node.Nodes)
                {
                    if (childNode.Text.ToLower().Contains(searchText))
                    {
                        childNode.BackColor = System.Drawing.Color.Yellow;
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
                            grandChildNode.BackColor = System.Drawing.Color.Yellow;
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
                                schemeNode.BackColor = System.Drawing.Color.Yellow;
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

            string searchDGV = searchBoxTV.Text.ToLower();
            foreach (DataGridViewRow row in mainDGV.Rows)
            {
                // Проход по каждой строке таблицы данных
                bool rowVisible = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Проход по каждой ячейке в строке
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchDGV))
                    {
                        // Если значение ячейки содержит искомый текст, то делаем строку видимой
                        rowVisible = true;
                        break;
                    }
                }
                row.Visible = rowVisible;
            }
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
            AddProductForm AddProductForm = new AddProductForm(this);
            AddProductForm.Show();
        }

        private void ТехнологияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTechRouteForm AddTechRouteForm = new AddTechRouteForm(this);
            AddTechRouteForm.Show();
        }

        private void MainDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

