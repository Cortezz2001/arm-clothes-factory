namespace АРМ_Швейная_фабрика
{
    partial class AddEquipmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEquipmentForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.addEquipmentFormBtn = new Guna.UI2.WinForms.Guna2Button();
            this.deleteEquipmentFormBtn = new Guna.UI2.WinForms.Guna2Button();
            this.equipmentFormDGV = new Guna.UI2.WinForms.Guna2DataGridView();
            this.closeFormBtn = new Guna.UI2.WinForms.Guna2CircleButton();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentFormDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 25;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // addEquipmentFormBtn
            // 
            this.addEquipmentFormBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addEquipmentFormBtn.BackgroundImage")));
            this.addEquipmentFormBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addEquipmentFormBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addEquipmentFormBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addEquipmentFormBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addEquipmentFormBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addEquipmentFormBtn.FillColor = System.Drawing.Color.Empty;
            this.addEquipmentFormBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addEquipmentFormBtn.ForeColor = System.Drawing.Color.White;
            this.addEquipmentFormBtn.Location = new System.Drawing.Point(484, 347);
            this.addEquipmentFormBtn.Name = "addEquipmentFormBtn";
            this.addEquipmentFormBtn.Size = new System.Drawing.Size(23, 21);
            this.addEquipmentFormBtn.TabIndex = 12;
            this.addEquipmentFormBtn.Click += new System.EventHandler(this.AddEquipmentFormBtn_Click);
            // 
            // deleteEquipmentFormBtn
            // 
            this.deleteEquipmentFormBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteEquipmentFormBtn.BackgroundImage")));
            this.deleteEquipmentFormBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deleteEquipmentFormBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.deleteEquipmentFormBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.deleteEquipmentFormBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.deleteEquipmentFormBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.deleteEquipmentFormBtn.FillColor = System.Drawing.Color.Empty;
            this.deleteEquipmentFormBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.deleteEquipmentFormBtn.ForeColor = System.Drawing.Color.White;
            this.deleteEquipmentFormBtn.Location = new System.Drawing.Point(513, 347);
            this.deleteEquipmentFormBtn.Name = "deleteEquipmentFormBtn";
            this.deleteEquipmentFormBtn.Size = new System.Drawing.Size(23, 21);
            this.deleteEquipmentFormBtn.TabIndex = 13;
            this.deleteEquipmentFormBtn.Click += new System.EventHandler(this.DeleteEquipmentFormBtn_Click);
            // 
            // equipmentFormDGV
            // 
            this.equipmentFormDGV.AllowUserToAddRows = false;
            this.equipmentFormDGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.equipmentFormDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.equipmentFormDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.equipmentFormDGV.ColumnHeadersHeight = 30;
            this.equipmentFormDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.equipmentFormDGV.DefaultCellStyle = dataGridViewCellStyle9;
            this.equipmentFormDGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.equipmentFormDGV.Location = new System.Drawing.Point(12, 44);
            this.equipmentFormDGV.Name = "equipmentFormDGV";
            this.equipmentFormDGV.RowHeadersVisible = false;
            this.equipmentFormDGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.equipmentFormDGV.Size = new System.Drawing.Size(524, 297);
            this.equipmentFormDGV.TabIndex = 11;
            this.equipmentFormDGV.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.White;
            this.equipmentFormDGV.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.equipmentFormDGV.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.equipmentFormDGV.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.equipmentFormDGV.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.equipmentFormDGV.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.equipmentFormDGV.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.equipmentFormDGV.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.equipmentFormDGV.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.equipmentFormDGV.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.equipmentFormDGV.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.equipmentFormDGV.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.equipmentFormDGV.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.equipmentFormDGV.ThemeStyle.HeaderStyle.Height = 30;
            this.equipmentFormDGV.ThemeStyle.ReadOnly = false;
            this.equipmentFormDGV.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.equipmentFormDGV.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.equipmentFormDGV.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.equipmentFormDGV.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.equipmentFormDGV.ThemeStyle.RowsStyle.Height = 22;
            this.equipmentFormDGV.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            this.equipmentFormDGV.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.equipmentFormDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.EquipmentFormDGV_CellEndEdit);
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
            this.closeFormBtn.Location = new System.Drawing.Point(508, 10);
            this.closeFormBtn.Name = "closeFormBtn";
            this.closeFormBtn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.closeFormBtn.Size = new System.Drawing.Size(28, 28);
            this.closeFormBtn.TabIndex = 10;
            this.closeFormBtn.Text = "X";
            this.closeFormBtn.Click += new System.EventHandler(this.CloseFormBtn_Click);
            // 
            // AddEquipmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(548, 383);
            this.Controls.Add(this.addEquipmentFormBtn);
            this.Controls.Add(this.deleteEquipmentFormBtn);
            this.Controls.Add(this.equipmentFormDGV);
            this.Controls.Add(this.closeFormBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddEquipmentForm";
            this.Text = "AddEquipmentForm";
            this.Load += new System.EventHandler(this.AddEquipmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.equipmentFormDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Button addEquipmentFormBtn;
        private Guna.UI2.WinForms.Guna2Button deleteEquipmentFormBtn;
        private Guna.UI2.WinForms.Guna2DataGridView equipmentFormDGV;
        private Guna.UI2.WinForms.Guna2CircleButton closeFormBtn;
    }
}