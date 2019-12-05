using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ShockQuiz.Forms
{
    public partial class ConfiguracionAdminForm : Form
    {
        FachadaConfiguracionAdmin fachada = new FachadaConfiguracionAdmin();

        public ConfiguracionAdminForm()
        {
            InitializeComponent();
            ActualizarConjuntos();
            helpToken.SetShowHelp(cbToken, true);
            helpToken.SetHelpString(cbToken, "Activando el token, la API recordará las preguntas ya enviadas.");
            helpToken.HelpNamespace = "helpFile.chm";
            helpToken.SetHelpNavigator(cbToken, HelpNavigator.TableOfContents);
        }

        public void ActualizarConjuntos()
        {
            foreach (var item in fachada.ObtenerConjuntos())
            {
                cbConjunto.Items.Add(item);
            }
            cbConjunto.DisplayMember = "Nombre";
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
                try
                {
                    conjunto.AgregarPreguntas(conjunto.Token,Decimal.ToInt32(nudCantidad.Value));
                    MessageBox.Show(Decimal.ToInt32(nudCantidad.Value) + " preguntas añadidas correctamente!","Éxito",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                MessageBox.Show("La cantidad de preguntas a agregar debe ser mayor que 0", "Error");
            }
        }

        private void btnAddConjunto_Click(object sender, EventArgs e)
        {
            try
            {
                fachada.AñadirConjunto(txtAddConjunto.Text, Decimal.ToInt32(nudAddConjunto.Value), cbToken.Checked);
                ActualizarConjuntos();
                MessageBox.Show("Conjunto OpenTDB añadido correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddConjunto.Clear();
                nudAddConjunto.Value = 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
