using System;
using System.Windows.Forms;
using UI.Presenter;
using UI.View;

namespace UI
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

            MainForm mainForm = new MainForm();
            MainPresenter presenter = new MainPresenter(mainForm);

            Application.Run(mainForm);
        }
    }
}
