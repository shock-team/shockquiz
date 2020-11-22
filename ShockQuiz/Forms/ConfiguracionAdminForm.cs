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
                try
                {
                    fachada.UsuarioAAdmin(txtUsuario.Text);
                    MessageBox.Show("La operación se ha realizado con éxito", "Aviso");
                }
                catch (InvalidOperationException)
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
                try
                {
                    if (cbConjunto.Text == "OpenTDB")
                    {
                        ConjuntoOTDB conjunto = new ConjuntoOTDB();
                        conjunto.AgregarPreguntas(Decimal.ToInt32(nudCantidad.Value), conjunto.Token);
                        MessageBox.Show(Decimal.ToInt32(nudCantidad.Value) + " preguntas añadidas correctamente al conjunto OpenTDB!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ha habido un error con la base de datos", "Error");
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

        private void btnDispose_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Estas seguro de borar toda la información?", "Confirmar limpieza de DB", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    fachada.LimpiarDB();
                    MessageBox.Show("Operación realiazada correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex )
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
