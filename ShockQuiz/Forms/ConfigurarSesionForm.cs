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
    public partial class ConfigurarSesionForm : Form
    {
        Usuario Usuario;
        FachadaConfigurarSesion fachada = new FachadaConfigurarSesion();

        public ConfigurarSesionForm(Usuario pUsuario)
        {
            InitializeComponent();
            Usuario = pUsuario;
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            SesionForm sesionForm = new SesionForm(Usuario, (Categoria)cbCategoria.SelectedItem, (Dificultad)cbDificultad.SelectedItem, (Conjunto)cbConjunto.SelectedItem, int.Parse(txtCantidad.Text));
            sesionForm.Show();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
