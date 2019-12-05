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
            IEnumerable<Conjunto> conjuntos = fachada.ObtenerConjuntos();
            foreach (Conjunto conjunto in conjuntos)
            {
                cbConjunto.Items.Add(conjunto);
            }
            IEnumerable<Dificultad> dificultades = fachada.ObtenerDificultades();
            foreach (Dificultad dificultad in dificultades)
            {
                cbDificultad.Items.Add(dificultad);
            }
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
            List<Categoria> categorias = new List<Categoria>();
            categorias = fachada.ObtenerCategorias(conjunto.Nombre).ToList();
            foreach (Categoria categoria in categorias)
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
