namespace АРМ_Швейная_фабрика
{
    partial class AuthForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthForm));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.authBtn = new Guna.UI2.WinForms.Guna2Button();
            this.loginTB = new Guna.UI2.WinForms.Guna2TextBox();
            this.passwordTB = new Guna.UI2.WinForms.Guna2TextBox();
            this.wrongDataLabel = new System.Windows.Forms.Label();
            this.closeFormBtn = new Guna.UI2.WinForms.Guna2CircleButton();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(100, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Авторизация";
            // 
            // authBtn
            // 
            this.authBtn.BorderRadius = 25;
            this.authBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.authBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.authBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.authBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.authBtn.FillColor = System.Drawing.Color.DodgerBlue;
            this.authBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authBtn.ForeColor = System.Drawing.Color.White;
            this.authBtn.Location = new System.Drawing.Point(58, 302);
            this.authBtn.Name = "authBtn";
            this.authBtn.Size = new System.Drawing.Size(231, 48);
            this.authBtn.TabIndex = 3;
            this.authBtn.Text = "Войти";
            this.authBtn.Click += new System.EventHandler(this.AuthBtn_Click);
            // 
            // loginTB
            // 
            this.loginTB.Animated = true;
            this.loginTB.BorderRadius = 25;
            this.loginTB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.loginTB.DefaultText = "";
            this.loginTB.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.loginTB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.loginTB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.loginTB.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.loginTB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginTB.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.loginTB.HoverState.PlaceholderForeColor = System.Drawing.Color.DodgerBlue;
            this.loginTB.IconLeft = ((System.Drawing.Image)(resources.GetObject("loginTB.IconLeft")));
            this.loginTB.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.loginTB.Location = new System.Drawing.Point(58, 134);
            this.loginTB.Margin = new System.Windows.Forms.Padding(5);
            this.loginTB.Name = "loginTB";
            this.loginTB.PasswordChar = '\0';
            this.loginTB.PlaceholderText = "Логин";
            this.loginTB.SelectedText = "";
            this.loginTB.Size = new System.Drawing.Size(231, 48);
            this.loginTB.TabIndex = 1;
            this.loginTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // passwordTB
            // 
            this.passwordTB.Animated = true;
            this.passwordTB.BorderRadius = 25;
            this.passwordTB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passwordTB.DefaultText = "";
            this.passwordTB.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.passwordTB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.passwordTB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passwordTB.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passwordTB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.passwordTB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordTB.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.passwordTB.HoverState.PlaceholderForeColor = System.Drawing.Color.DodgerBlue;
            this.passwordTB.IconLeft = ((System.Drawing.Image)(resources.GetObject("passwordTB.IconLeft")));
            this.passwordTB.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.passwordTB.Location = new System.Drawing.Point(58, 192);
            this.passwordTB.Margin = new System.Windows.Forms.Padding(5);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.PasswordChar = '*';
            this.passwordTB.PlaceholderText = "Пароль";
            this.passwordTB.SelectedText = "";
            this.passwordTB.Size = new System.Drawing.Size(231, 48);
            this.passwordTB.TabIndex = 2;
            this.passwordTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // wrongDataLabel
            // 
            this.wrongDataLabel.AutoSize = true;
            this.wrongDataLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wrongDataLabel.ForeColor = System.Drawing.Color.Red;
            this.wrongDataLabel.Location = new System.Drawing.Point(70, 264);
            this.wrongDataLabel.Name = "wrongDataLabel";
            this.wrongDataLabel.Size = new System.Drawing.Size(208, 17);
            this.wrongDataLabel.TabIndex = 3;
            this.wrongDataLabel.Text = "Неправильный логин или пароль";
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
            this.closeFormBtn.Location = new System.Drawing.Point(302, 12);
            this.closeFormBtn.Name = "closeFormBtn";
            this.closeFormBtn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.closeFormBtn.Size = new System.Drawing.Size(28, 28);
            this.closeFormBtn.TabIndex = 4;
            this.closeFormBtn.Text = "X";
            this.closeFormBtn.Click += new System.EventHandler(this.CloseFormBtn_Click);
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(342, 390);
            this.Controls.Add(this.closeFormBtn);
            this.Controls.Add(this.wrongDataLabel);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.loginTB);
            this.Controls.Add(this.authBtn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AuthForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Button authBtn;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox loginTB;
        private Guna.UI2.WinForms.Guna2TextBox passwordTB;
        private System.Windows.Forms.Label wrongDataLabel;
        private Guna.UI2.WinForms.Guna2CircleButton closeFormBtn;
    }
}

