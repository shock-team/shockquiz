using System;
using System.Windows.Forms;
using ShockQuiz.Excepciones;
using ShockQuiz.Dominio;

namespace ShockQuiz.Forms
{
    public partial class LoginForm : Form
    {
        FachadaLogin facha = new FachadaLogin();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                int usuario = facha.CheckLogin(txtUsuario.Text, txtContraseña.Text);
                bool esAdmin = facha.EsAdmin(txtUsuario.Text);
                MenuForm menuForm = new MenuForm(usuario, esAdmin);
                menuForm.FormClosed += new FormClosedEventHandler(LoginForm_FormClosed);
                var sesionActiva = facha.ObtenerSesionNoFinalizada();
                if (sesionActiva != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Existe una sesión sin finalizar, ¿desea continuarla?", "Sesión activa", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SesionForm sesionForm = new SesionForm(sesionActiva.SesionId, sesionActiva.Categoria.Nombre, sesionActiva.Dificultad.Nombre, sesionActiva.PreguntasRestantes);
                        //sesionForm.FormClosed += new FormClosedEventHandler(LoginForm_FormClosed);
                        sesionForm.Show();
                        this.Hide();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        facha.CancelarSesionActiva();
                        menuForm.Show();
                        this.Hide();
                    }
                }
                
                menuForm.Show();
                this.Hide();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Usuario inexistente.", "Iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ContraseñaIncorrectaException)
            {
                MessageBox.Show("Contraseña incorrecta.", "Iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                facha.AddUser(txtUsuario.Text, txtContraseña.Text);
                MessageBox.Show("Usuario " + txtUsuario.Text + " creado correctamente!", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show("Usuario ya existente.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
