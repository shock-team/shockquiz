using ShockQuiz.Dominio;
using System;
using System.Windows.Forms;

namespace ShockQuiz.Forms
{
    public partial class ConfiguracionAdminForm : Form
    {
        FachadaConfiguracionAdmin fachada = new FachadaConfiguracionAdmin();

        public ConfiguracionAdminForm()
        {
            InitializeComponent();
            cbConjunto.DataSource = fachada.ObtenerConjuntos();
        }

        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "")
            {
                bool resultado = fachada.UsuarioAAdmin(txtUsuario.Text);
                if (resultado)
                {
                    MessageBox.Show("La operación se ha realizado con éxito", "Aviso");
                }
                else
                {
                    MessageBox.Show("No se ha encontrado al usuario", "Error");
                }
                txtUsuario.Clear();
            }
            else
            {
                MessageBox.Show("Ingrese un usuario", "Error");
            }
        }

        private void BtnUsuario_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "")
            {
                bool resultado = fachada.AdminAUsuario(txtUsuario.Text);
                if (resultado)
                {
                    MessageBox.Show("La operación se ha realizado con éxito", "Aviso");
                }
                else
                {
                    MessageBox.Show("No se ha encontrado al usuario", "Error");
                }
                txtUsuario.Clear();
            }
            else
            {
                MessageBox.Show("Ingrese un usuario", "Error");
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (nudCantidad.Value > 0)
            {
                Conjunto conjunto = (Conjunto)cbConjunto.SelectedItem;
                conjunto.AgregarPreguntas(Decimal.ToInt32(nudCantidad.Value));
            }
            else
            {
                MessageBox.Show("La cantidad de preguntas a agregar debe ser mayor que 0", "Error");
            }
            nudCantidad.Value = 0;
        }
    }
}
