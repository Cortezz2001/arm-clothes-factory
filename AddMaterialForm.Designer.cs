namespace АРМ_Швейная_фабрика
{
    partial class AddMaterialForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMaterialForm));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.closeFormBtn = new Guna.UI2.WinForms.Guna2CircleButton();
            this.materialsFormDGV = new Guna.UI2.WinForms.Guna2DataGridView();
            this.addMaterialsFormBtn = new Guna.UI2.WinForms.Guna2Button();
            this.deleteMaterialsFormBtn = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.materialsFormDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 25;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
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
            this.closeFormBtn.TabIndex = 6;
            this.closeFormBtn.Text = "X";
            this.closeFormBtn.Click += new System.EventHandler(this.CloseFormBtn_Click);
            // 
            // materialsFormDGV
            // 
            this.materialsFormDGV.AllowUserToAddRows = false;
            this.materialsFormDGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.materialsFormDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.materialsFormDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.materialsFormDGV.ColumnHeadersHeight = 30;
            this.materialsFormDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.materialsFormDGV.DefaultCellStyle = dataGridViewCellStyle6;
            this.materialsFormDGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.materialsFormDGV.Location = new System.Drawing.Point(12, 46);
            this.materialsFormDGV.Name = "materialsFormDGV";
            this.materialsFormDGV.RowHeadersVisible = false;
            this.materialsFormDGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.materialsFormDGV.Size = new System.Drawing.Size(524, 297);
            this.materialsFormDGV.TabIndex = 7;
            this.materialsFormDGV.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.White;
            this.materialsFormDGV.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.materialsFormDGV.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.materialsFormDGV.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.materialsFormDGV.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.materialsFormDGV.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.materialsFormDGV.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.materialsFormDGV.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.materialsFormDGV.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.materialsFormDGV.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.materialsFormDGV.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.materialsFormDGV.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.materialsFormDGV.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.materialsFormDGV.ThemeStyle.HeaderStyle.Height = 30;
            this.materialsFormDGV.ThemeStyle.ReadOnly = false;
            this.materialsFormDGV.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.materialsFormDGV.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.materialsFormDGV.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.materialsFormDGV.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.materialsFormDGV.ThemeStyle.RowsStyle.Height = 22;
            this.materialsFormDGV.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            this.materialsFormDGV.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.materialsFormDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.MaterialsFormDGV_CellEndEdit);
            // 
            // addMaterialsFormBtn
            // 
            this.addMaterialsFormBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addMaterialsFormBtn.BackgroundImage")));
            this.addMaterialsFormBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addMaterialsFormBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addMaterialsFormBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addMaterialsFormBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addMaterialsFormBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addMaterialsFormBtn.FillColor = System.Drawing.Color.Empty;
            this.addMaterialsFormBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addMaterialsFormBtn.ForeColor = System.Drawing.Color.White;
            this.addMaterialsFormBtn.Location = new System.Drawing.Point(484, 349);
            this.addMaterialsFormBtn.Name = "addMaterialsFormBtn";
            this.addMaterialsFormBtn.Size = new System.Drawing.Size(23, 21);
            this.addMaterialsFormBtn.TabIndex = 8;
            this.addMaterialsFormBtn.Click += new System.EventHandler(this.AddMaterialsFormBtn_Click);
            // 
            // deleteMaterialsFormBtn
            // 
            this.deleteMaterialsFormBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteMaterialsFormBtn.BackgroundImage")));
            this.deleteMaterialsFormBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deleteMaterialsFormBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.deleteMaterialsFormBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.deleteMaterialsFormBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.deleteMaterialsFormBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.deleteMaterialsFormBtn.FillColor = System.Drawing.Color.Empty;
            this.deleteMaterialsFormBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.deleteMaterialsFormBtn.ForeColor = System.Drawing.Color.White;
            this.deleteMaterialsFormBtn.Location = new System.Drawing.Point(513, 349);
            this.deleteMaterialsFormBtn.Name = "deleteMaterialsFormBtn";
            this.deleteMaterialsFormBtn.Size = new System.Drawing.Size(23, 21);
            this.deleteMaterialsFormBtn.TabIndex = 9;
            this.deleteMaterialsFormBtn.Click += new System.EventHandler(this.DeleteMaterialsFormBtn_Click);
            // 
            // AddMaterialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(548, 383);
            this.Controls.Add(this.addMaterialsFormBtn);
            this.Controls.Add(this.deleteMaterialsFormBtn);
            this.Controls.Add(this.materialsFormDGV);
            this.Controls.Add(this.closeFormBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddMaterialForm";
            this.Text = "AddProductForm";
            this.Load += new System.EventHandler(this.AddMaterialForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.materialsFormDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2CircleButton closeFormBtn;
        private Guna.UI2.WinForms.Guna2DataGridView materialsFormDGV;
        private Guna.UI2.WinForms.Guna2Button addMaterialsFormBtn;
        private Guna.UI2.WinForms.Guna2Button deleteMaterialsFormBtn;
    }
}