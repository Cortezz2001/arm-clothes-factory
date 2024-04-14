using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace АРМ_Швейная_фабрика
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new authForm());
            MainForm mainForm = new MainForm();
            AuthForm authForm = new AuthForm(mainForm);
            Application.Run(authForm);
        }
    }
}
