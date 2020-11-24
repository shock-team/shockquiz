using ShockQuiz.Forms;
using System;
using System.Windows.Forms;

namespace ShockQuiz
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);;
                Application.Run(new LoginForm());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Ha ocurrido una excepción, dirijase a ErrorLog.txt para más información", "Error");
            }
        }
    }
}
