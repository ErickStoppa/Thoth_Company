using System;
using System.Windows.Forms;
using AgendaApp.Forms;

namespace AgendaApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                using (var loginForm = new LoginForm())
                {
                    var result = loginForm.ShowDialog();
                    if (result != DialogResult.OK)
                        break;

                    var usuario = loginForm.UsuarioLogado;
                    using (var mainForm = new MainForm(usuario))
                    {
                        mainForm.ShowDialog();
                        if (!mainForm.Logout)
                            break;
                    }
                }
            }
        }
    }
}