using System;
using System.Windows.Forms;

namespace ShockQuiz.Forms
{
    public partial class MenuForm : Form
    {
        FachadaMenu facha = new FachadaMenu();
        string usuario;

        public MenuForm(string pUsuario)
        {
            InitializeComponent();
            bool esAdmin = facha.EsAdmin(pUsuario);
            usuario = pUsuario;
            btnConfiguracion.Enabled = esAdmin;
            btnConfiguracion.Visible = esAdmin;
        }

        private void BtnNuevaSesion_Click(object sender, EventArgs e)
        {
            ConfigurarSesionForm configurarSesionForm = new ConfigurarSesionForm(usuario);
            configurarSesionForm.FormClosed += new FormClosedEventHandler(ConfigurarSesionForm_FormClosed);
            configurarSesionForm.Show();
            this.Hide();
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
