using ShockQuiz.Excepciones;
using ShockQuiz.IO;
using System;
using System.Windows.Forms;

namespace ShockQuiz.Forms
{
    public partial class LoginForm : Form
    {
        FachadaLogin facha = new FachadaLogin();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                LoginDTO loginDTO = facha.Login(txtUsuario.Text, txtContraseña.Text);
                MenuForm menuForm = new MenuForm(loginDTO.IdUsuario, loginDTO.EsAdmin);
                menuForm.FormClosed += new FormClosedEventHandler(LoginForm_FormClosed);
                if (loginDTO.IdSesion != -1)
                {
                    DialogResult dialogResult = MessageBox.Show("Existe una sesión sin finalizar, ¿desea continuarla?", "Sesión activa", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        menuForm.Show();
                        SesionForm sesionForm = new SesionForm(loginDTO.IdSesion);
                        sesionForm.Show();
                        this.Hide();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        facha.CancelarSesion(loginDTO.IdUsuario);
                        menuForm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    menuForm.Show();
                }

                this.Hide();
            }
            /*catch (InvalidOperationException)
            {
                MessageBox.Show("Usuario inexistente.", "Iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
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

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e) => this.Close();

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}
