namespace АРМ_Швейная_фабрика
{
    partial class AddPositionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPositionForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.addPositionFormBtn = new Guna.UI2.WinForms.Guna2Button();
            this.deletePositionFormBtn = new Guna.UI2.WinForms.Guna2Button();
            this.positionFormDGV = new Guna.UI2.WinForms.Guna2DataGridView();
            this.closeFormBtn = new Guna.UI2.WinForms.Guna2CircleButton();
            ((System.ComponentModel.ISupportInitialize)(this.positionFormDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 25;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // addPositionFormBtn
            // 
            this.addPositionFormBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addPositionFormBtn.BackgroundImage")));
            this.addPositionFormBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addPositionFormBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addPositionFormBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addPositionFormBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addPositionFormBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addPositionFormBtn.FillColor = System.Drawing.Color.Empty;
            this.addPositionFormBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addPositionFormBtn.ForeColor = System.Drawing.Color.White;
            this.addPositionFormBtn.Location = new System.Drawing.Point(484, 349);
            this.addPositionFormBtn.Name = "addPositionFormBtn";
            this.addPositionFormBtn.Size = new System.Drawing.Size(23, 21);
            this.addPositionFormBtn.TabIndex = 16;
            this.addPositionFormBtn.Click += new System.EventHandler(this.AddPositionFormBtn_Click);
            // 
            // deletePositionFormBtn
            // 
            this.deletePositionFormBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deletePositionFormBtn.BackgroundImage")));
            this.deletePositionFormBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deletePositionFormBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.deletePositionFormBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.deletePositionFormBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.deletePositionFormBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.deletePositionFormBtn.FillColor = System.Drawing.Color.Empty;
            this.deletePositionFormBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.deletePositionFormBtn.ForeColor = System.Drawing.Color.White;
            this.deletePositionFormBtn.Location = new System.Drawing.Point(513, 349);
            this.deletePositionFormBtn.Name = "deletePositionFormBtn";
            this.deletePositionFormBtn.Size = new System.Drawing.Size(23, 21);
            this.deletePositionFormBtn.TabIndex = 17;
            this.deletePositionFormBtn.Click += new System.EventHandler(this.DeletePositionFormBtn_Click);
            // 
            // positionFormDGV
            // 
            this.positionFormDGV.AllowUserToAddRows = false;
            this.positionFormDGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.positionFormDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.positionFormDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.positionFormDGV.ColumnHeadersHeight = 30;
            this.positionFormDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.positionFormDGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.positionFormDGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.positionFormDGV.Location = new System.Drawing.Point(12, 46);
            this.positionFormDGV.Name = "positionFormDGV";
            this.positionFormDGV.RowHeadersVisible = false;
            this.positionFormDGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.positionFormDGV.Size = new System.Drawing.Size(524, 297);
            this.positionFormDGV.TabIndex = 15;
            this.positionFormDGV.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.White;
            this.positionFormDGV.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.positionFormDGV.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.positionFormDGV.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.positionFormDGV.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.positionFormDGV.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.positionFormDGV.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.positionFormDGV.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.positionFormDGV.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.positionFormDGV.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.positionFormDGV.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.positionFormDGV.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.positionFormDGV.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.positionFormDGV.ThemeStyle.HeaderStyle.Height = 30;
            this.positionFormDGV.ThemeStyle.ReadOnly = false;
            this.positionFormDGV.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.positionFormDGV.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.positionFormDGV.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.positionFormDGV.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.positionFormDGV.ThemeStyle.RowsStyle.Height = 22;
            this.positionFormDGV.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            this.positionFormDGV.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.positionFormDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.PositionFormDGV_CellEndEdit);
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
            this.closeFormBtn.TabIndex = 14;
            this.closeFormBtn.Text = "X";
            this.closeFormBtn.Click += new System.EventHandler(this.CloseFormBtn_Click);
            // 
            // AddPositionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(548, 383);
            this.Controls.Add(this.addPositionFormBtn);
            this.Controls.Add(this.deletePositionFormBtn);
            this.Controls.Add(this.positionFormDGV);
            this.Controls.Add(this.closeFormBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddPositionForm";
            this.Text = "AddPositionForm";
            this.Load += new System.EventHandler(this.AddPositionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.positionFormDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Button addPositionFormBtn;
        private Guna.UI2.WinForms.Guna2Button deletePositionFormBtn;
        private Guna.UI2.WinForms.Guna2DataGridView positionFormDGV;
        private Guna.UI2.WinForms.Guna2CircleButton closeFormBtn;
    }
}