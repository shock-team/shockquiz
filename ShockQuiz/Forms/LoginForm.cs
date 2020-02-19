using System;
using System.Windows.Forms;
using ShockQuiz.Excepciones;

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
                MessageBox.Show("Bienvenido " + txtUsuario.Text + "!", "Iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                bool esAdmin = facha.EsAdmin(txtUsuario.Text);
                MenuForm menuForm = new MenuForm(usuario, esAdmin);
                menuForm.FormClosed += new FormClosedEventHandler(LoginForm_FormClosed);
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
