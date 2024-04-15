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
            this.Close();
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
        }

        private void TreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (treeView.SelectedNode != null)
            {
                if (treeView.SelectedNode.Level == 1)
                {
                    string tech_route_name = treeView.SelectedNode.Text;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string queryRouteId = "SELECT route_ID FROM technological_route WHERE name = @tech_route_name";
                        using (SqlCommand cmdRouteId = new SqlCommand(queryRouteId, connection))
                        {
                            cmdRouteId.Parameters.AddWithValue("@tech_route_name", tech_route_name);
                            string route_ID = cmdRouteId.ExecuteScalar().ToString();

                            string queryProcesses = "SELECT ID, name, type, normatives, time, route_ID, equip_ID, position_ID FROM technological_process WHERE route_ID = @route_ID";
                            using (SqlCommand cmdProcesses = new SqlCommand(queryProcesses, connection))
                            {
                                cmdProcesses.Parameters.AddWithValue("@route_ID", route_ID);
                                SqlDataAdapter adapter = new SqlDataAdapter(cmdProcesses);
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                // Добавление новых столбцов для комбобоксов
                                DataGridViewComboBoxColumn routeColumn = new DataGridViewComboBoxColumn();
                                routeColumn.HeaderText = "Маршрут";
                                routeColumn.Name = "routeColumn";
                                routeColumn.DataSource = GetTechnologicalRoutes(); // Загрузка данных из таблицы technological_route
                                routeColumn.DataPropertyName = "route_ID";
                                routeColumn.DisplayMember = "name";
                                routeColumn.ValueMember = "route_ID";
                                

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
                                

                                mainDGV.DataSource = dataTable;
                                mainDGV.Columns["ID"].HeaderText = "Номер";
                                mainDGV.Columns["name"].HeaderText = "Наименование операции";
                                mainDGV.Columns["type"].HeaderText = "Способ работы";
                                mainDGV.Columns["normatives"].HeaderText = "Нормативы";
                                mainDGV.Columns["time"].HeaderText = "Время(с)";
                                mainDGV.Columns.Add(routeColumn);
                                mainDGV.Columns.Add(equipColumn);
                                mainDGV.Columns.Add(positionColumn);
                                mainDGV.Columns["route_ID"].Visible = false;
                                mainDGV.Columns["equip_ID"].Visible = false;
                                mainDGV.Columns["position_ID"].Visible = false;
                                mainDGV.CurrentCell = null;
                            }
                        }
                    }
                }
            }
            mainDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            foreach (DataGridViewColumn column in mainDGV.Columns)
            {
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            //mainDGV.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            foreach (DataGridViewColumn column in mainDGV.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // Функции для загрузки данных в комбобоксы
        private DataTable GetTechnologicalRoutes()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT route_ID, name FROM technological_route";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);
                }
            }
            return table;
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
    }
}

