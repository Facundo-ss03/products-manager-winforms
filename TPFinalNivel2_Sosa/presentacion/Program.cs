using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentacion
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            frmPrincipal entry = new frmPrincipal();
            entry.FormClosed += Form1_Closed;
            entry.Show();

            Application.Run();
        }

        private static void Form1_Closed(object sender, FormClosedEventArgs e)
        {
            ((Form)sender).FormClosed -= Form1_Closed;

            if (Application.OpenForms.Count == 0)
            {
                Application.ExitThread();
            }
            else
            {
                Application.OpenForms[0].FormClosed += Form1_Closed;
            }
        }
    }
}
