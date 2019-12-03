using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShockQuiz.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new Contestar());
=======
            Application.Run(new LoginForm());
>>>>>>> 4ac8bb843540e464c3f787cb553c39f65231cecc
        }
    }
}
