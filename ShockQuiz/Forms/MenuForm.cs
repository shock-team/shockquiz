using ShockQuiz.DAL;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ShockQuiz.Forms
{
    public partial class MenuForm : Form
    {
        int idUsuario;

        public MenuForm(int pUsuario, bool esAdmin)
        {
            InitializeComponent();
            idUsuario = pUsuario;
            btnConfiguracion.Enabled = esAdmin;
            btnConfiguracion.Visible = esAdmin;
        }

        private void BtnNuevaSesion_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigurarSesionForm configurarSesionForm = new ConfigurarSesionForm(idUsuario);
                configurarSesionForm.FormClosed += new FormClosedEventHandler(ConfigurarSesionForm_FormClosed);
                if (!Application.OpenForms.OfType<SesionForm>().Any())
                {
                    configurarSesionForm.Show();

                }
                this.Hide();
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Ha habido un error con la base de datos");
                throw;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRanking_Click(object sender, EventArgs e)
        {
            RankingForm rankForm = new RankingForm();
            rankForm.FormClosed += new FormClosedEventHandler(RankForm_FormClosed);
            rankForm.Show();
            this.Hide();
        }

        private void ConfigurarSesionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void RankForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void BtnConfiguracion_Click(object sender, EventArgs e)
        {
            ConfiguracionAdminForm configForm = new ConfiguracionAdminForm();
            configForm.FormClosed += new FormClosedEventHandler(ConfigForm_FormClosed);
            configForm.Show();
            this.Hide();
        }

        private void ConfigForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
