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
        string Usuario;
        FachadaConfigurarSesion fachada = new FachadaConfigurarSesion();

        public ConfigurarSesionForm(string pUsuario)
        {
            InitializeComponent();
            Usuario = pUsuario;
            cbConjunto.DataSource = fachada.ObtenerConjuntos();
            cbDificultad.DataSource = fachada.ObtenerDificultades();
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            SesionForm sesionForm = new SesionForm(Usuario, (Categoria)cbCategoria.SelectedItem, (Dificultad)cbDificultad.SelectedItem, (Conjunto)cbConjunto.SelectedItem, Decimal.ToInt32(nudCantidad.Value));
            sesionForm.FormClosed += new FormClosedEventHandler(SesionForm_FormClosed);
            sesionForm.Show();
            this.Hide();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CbConjunto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conjunto conjunto = (Conjunto)cbConjunto.SelectedItem;
            cbCategoria.DataSource = fachada.ObtenerCategorias(conjunto.ConjuntoId);
        }

        private void SesionForm_FormClosed(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
