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
        FachadaMenu facha = new FachadaMenu();
        public MenuForm(string pUsuario)
        {
            InitializeComponent();
            bool esAdmin = facha.EsAdmin(pUsuario);
            btnConfiguracion.Enabled = esAdmin;
            btnConfiguracion.Visible = esAdmin;
        }

        private void BtnNuevaSesion_Click(object sender, EventArgs e)
        {
            
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
