namespace АРМ_Швейная_фабрика
{
    partial class AddAdditionalMaterialForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAdditionalMaterialForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.closeFormBtn = new Guna.UI2.WinForms.Guna2CircleButton();
            this.addAMaterialsFormBtn = new Guna.UI2.WinForms.Guna2Button();
            this.deleteAMaterialsFormBtn = new Guna.UI2.WinForms.Guna2Button();
            this.a_materialsFormDGV = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.a_materialsFormDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 25;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // closeFormBtn
            // 
            this.closeFormBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.closeFormBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.closeFormBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.closeFormBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.closeFormBtn.FillColor = System.Drawing.Color.DodgerBlue;
            this.closeFormBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeFormBtn.ForeColor = System.Drawing.Color.White;
            this.closeFormBtn.Location = new System.Drawing.Point(508, 12);
            this.closeFormBtn.Name = "closeFormBtn";
            this.closeFormBtn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.closeFormBtn.Size = new System.Drawing.Size(28, 28);
            this.closeFormBtn.TabIndex = 10;
            this.closeFormBtn.Text = "X";
            this.closeFormBtn.Click += new System.EventHandler(this.CloseFormBtn_Click);
            // 
            // addAMaterialsFormBtn
            // 
            this.addAMaterialsFormBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addAMaterialsFormBtn.BackgroundImage")));
            this.addAMaterialsFormBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addAMaterialsFormBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addAMaterialsFormBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addAMaterialsFormBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addAMaterialsFormBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addAMaterialsFormBtn.FillColor = System.Drawing.Color.Empty;
            this.addAMaterialsFormBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addAMaterialsFormBtn.ForeColor = System.Drawing.Color.White;
            this.addAMaterialsFormBtn.Location = new System.Drawing.Point(484, 349);
            this.addAMaterialsFormBtn.Name = "addAMaterialsFormBtn";
            this.addAMaterialsFormBtn.Size = new System.Drawing.Size(23, 21);
            this.addAMaterialsFormBtn.TabIndex = 12;
            this.addAMaterialsFormBtn.Click += new System.EventHandler(this.AddAMaterialsFormBtn_Click);
            // 
            // deleteAMaterialsFormBtn
            // 
            this.deleteAMaterialsFormBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteAMaterialsFormBtn.BackgroundImage")));
            this.deleteAMaterialsFormBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deleteAMaterialsFormBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.deleteAMaterialsFormBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.deleteAMaterialsFormBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.deleteAMaterialsFormBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.deleteAMaterialsFormBtn.FillColor = System.Drawing.Color.Empty;
            this.deleteAMaterialsFormBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.deleteAMaterialsFormBtn.ForeColor = System.Drawing.Color.White;
            this.deleteAMaterialsFormBtn.Location = new System.Drawing.Point(513, 349);
            this.deleteAMaterialsFormBtn.Name = "deleteAMaterialsFormBtn";
            this.deleteAMaterialsFormBtn.Size = new System.Drawing.Size(23, 21);
            this.deleteAMaterialsFormBtn.TabIndex = 13;
            this.deleteAMaterialsFormBtn.Click += new System.EventHandler(this.DeleteAMaterialsFormBtn_Click);
            // 
            // a_materialsFormDGV
            // 
            this.a_materialsFormDGV.AllowUserToAddRows = false;
            this.a_materialsFormDGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.a_materialsFormDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.a_materialsFormDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.a_materialsFormDGV.ColumnHeadersHeight = 30;
            this.a_materialsFormDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.a_materialsFormDGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.a_materialsFormDGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.a_materialsFormDGV.Location = new System.Drawing.Point(12, 46);
            this.a_materialsFormDGV.Name = "a_materialsFormDGV";
            this.a_materialsFormDGV.RowHeadersVisible = false;
            this.a_materialsFormDGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.a_materialsFormDGV.Size = new System.Drawing.Size(524, 297);
            this.a_materialsFormDGV.TabIndex = 11;
            this.a_materialsFormDGV.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.White;
            this.a_materialsFormDGV.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.a_materialsFormDGV.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.a_materialsFormDGV.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.a_materialsFormDGV.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.a_materialsFormDGV.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.a_materialsFormDGV.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.a_materialsFormDGV.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.a_materialsFormDGV.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.a_materialsFormDGV.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.a_materialsFormDGV.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.a_materialsFormDGV.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.a_materialsFormDGV.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.a_materialsFormDGV.ThemeStyle.HeaderStyle.Height = 30;
            this.a_materialsFormDGV.ThemeStyle.ReadOnly = false;
            this.a_materialsFormDGV.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.a_materialsFormDGV.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.a_materialsFormDGV.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.a_materialsFormDGV.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.a_materialsFormDGV.ThemeStyle.RowsStyle.Height = 22;
            this.a_materialsFormDGV.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            this.a_materialsFormDGV.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.a_materialsFormDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.A_materialsFormDGV_CellEndEdit);
            // 
            // AddAdditionalMaterialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(548, 383);
            this.Controls.Add(this.addAMaterialsFormBtn);
            this.Controls.Add(this.deleteAMaterialsFormBtn);
            this.Controls.Add(this.a_materialsFormDGV);
            this.Controls.Add(this.closeFormBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddAdditionalMaterialForm";
            this.Text = "AddTechRouteForm";
            this.Load += new System.EventHandler(this.AddAdditionalMaterialForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.a_materialsFormDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2CircleButton closeFormBtn;
        private Guna.UI2.WinForms.Guna2Button addAMaterialsFormBtn;
        private Guna.UI2.WinForms.Guna2Button deleteAMaterialsFormBtn;
        private Guna.UI2.WinForms.Guna2DataGridView a_materialsFormDGV;
    }
}