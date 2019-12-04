using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShockQuiz.Forms
{
    public partial class ConfiguracionAdminForm : Form
    {
        FachadaConfiguracionAdmin fachada = new FachadaConfiguracionAdmin();

        public ConfiguracionAdminForm()
        {
            InitializeComponent();
        }

        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            fachada.UsuarioAAdmin(txtUsuario.Text);
            MessageBox.Show("El usuario " + txtUsuario.Text + " ha pasado a ser administrador");
            txtUsuario.Clear();
        }

        private void BtnUsuario_Click(object sender, EventArgs e)
        {
            fachada.AdminAUsuario(txtUsuario.Text);
            MessageBox.Show("El administrador " + txtUsuario.Text + " ha pasado a ser usuario");
            txtUsuario.Clear();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
