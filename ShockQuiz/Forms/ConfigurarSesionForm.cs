using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            IEnumerable<string> conjuntos = fachada.ObtenerConjuntos();
            foreach (string conjunto in conjuntos)
            {
                cbConjunto.Items.Add(conjunto);
            }
            IEnumerable<string> dificultades = fachada.ObtenerDificultades();
            foreach (string dificultad in dificultades)
            {
                cbDificultad.Items.Add(dificultad);
            }
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            SesionForm sesionForm = new SesionForm(Usuario, (string)cbCategoria.SelectedItem, (string)cbDificultad.SelectedItem, (string)cbConjunto.SelectedItem, Decimal.ToInt32(nudCantidad.Value));
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
            cbCategoria.Items.Clear();
            string conjunto = (string)cbConjunto.SelectedItem;
            List<string> categorias = fachada.ObtenerCategorias(conjunto).ToList();
            foreach (string categoria in categorias)
            {
                cbCategoria.Items.Add(categoria);
            }
        }

        private void SesionForm_FormClosed(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
