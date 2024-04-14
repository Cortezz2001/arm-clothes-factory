using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace АРМ_Швейная_фабрика
{
    public partial class MainForm : Form
    {
        private bool isDragging = false;
        private int mouseX;
        private int mouseY;
        public MainForm()
        {
            InitializeComponent();
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
    }
}
