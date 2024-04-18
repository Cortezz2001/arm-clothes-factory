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
    public partial class AuthForm : Form
    {
        private MainForm mainForm;
        DB db = new DB();
        public AuthForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
            wrongDataLabel.Visible = false;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }

        private void AuthBtn_Click(object sender, EventArgs e)
        {
            if (wrongDataLabel.Visible == true)
            {
                wrongDataLabel.Visible = false;
            }

            String loginUser = loginTB.Text;
            String passUser = passwordTB.Text;
            try
            {
                DB db = new DB();
                DataTable table = new DataTable();
                db.OpenConnection();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM teachers", db.GetConnection());
                SqlCommand command = new SqlCommand("SELECT * FROM users WHERE login = @loginUser AND password = @passUser", db.GetConnection());
                command.Parameters.Add(new SqlParameter("@loginUser", loginUser));
                command.Parameters.Add(new SqlParameter("@passUser", passUser));
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    mainForm.Show();
                    this.Hide();
                    db.CloseConnection();
                }
                else
                {
                    wrongDataLabel.Visible = true;
                    db.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void CloseFormBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
