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
            cbCategoria.DataSource = fachada.ObtenerCategorias();
            cbConjunto.DataSource = fachada.ObtenerConjuntos();
            cbDificultad.DataSource = fachada.ObtenerDificultades();
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            int cantidadMinima = 10;
            if (int.Parse(txtCantidad.Text) >= cantidadMinima)
            {
                SesionForm sesionForm = new SesionForm(Usuario, (Categoria)cbCategoria.SelectedItem, (Dificultad)cbDificultad.SelectedItem, (Conjunto)cbConjunto.SelectedItem, int.Parse(txtCantidad.Text));
                sesionForm.Show();
            }
            else
            {
                MessageBox.Show("La cantidad de preguntas debe ser al menos " + cantidadMinima.ToString(),"Error");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
