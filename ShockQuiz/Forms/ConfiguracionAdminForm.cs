using ShockQuiz.Dominio;
using System;
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

            foreach (Type tipo in fachada.ObtenerTiposDeConjunto().ToList())
            {
                comboTipoConjunto.Items.Add(tipo);
            }
            comboTipoConjunto.DisplayMember = "Name";
            comboTipoConjunto.SelectedIndex = 0;
        }

        public void ActualizarConjuntos()
        {
            cbConjunto.Items.Clear();
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

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (nudCantidad.Value > 0)
            {
                try
                {
                    fachada.AlmacenarPreguntas(((Conjunto)cbConjunto.SelectedItem).ConjuntoId, Convert.ToInt32(nudCantidad.Value));

                    MessageBox.Show($"{Decimal.ToInt32(nudCantidad.Value)} preguntas añadidas correctamente al conjunto {cbConjunto.Text}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                int indice = comboTipoConjunto.SelectedIndex;
                if (comboTipoConjunto.SelectedIndex > -1)
                {
                    fachada.AñadirConjunto(txtAddConjunto.Text, Decimal.ToInt32(nudAddConjunto.Value), cbToken.Checked, (Type)comboTipoConjunto.SelectedItem);
                    ActualizarConjuntos();
                    MessageBox.Show("Conjunto añadido correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAddConjunto.Clear();
                    nudAddConjunto.Value = 1;
                }
                else
                {
                    MessageBox.Show("Seleccione un tipo de conjunto", "Error");
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Introduzca los datos apropiados", "Error");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show("Ya existe un conjunto con ese nombre", "Error");
            }
            catch (Exception)
            {
                MessageBox.Show("Ha habido un error con la base de datos", "Error");
            }
        }

        private void btnDispose_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Estas seguro de borrar toda la información?", "Confirmar limpieza de DB", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    fachada.LimpiarDB();
                    MessageBox.Show("Operación realizada correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}
