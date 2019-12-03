using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShockQuiz.Dominio;

namespace ShockQuiz.Forms
{
    public partial class MenuForm : Form
    {
        public MenuForm(Usuario pUsuario)
        {
            InitializeComponent();
            btnConfiguracion.Enabled = (pUsuario.Admin);
            btnConfiguracion.Visible = (pUsuario.Admin);
        }

        private void BtnNuevaSesion_Click(object sender, EventArgs e)
        {
            
        }
    }
}
