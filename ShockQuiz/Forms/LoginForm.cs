using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (facha.CheckLogin(txtUsuario.Text, txtContraseña.Text))
                {
                    MessageBox.Show("Bienvenido " + txtUsuario.Text + "!","Iniciar sesión",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta.", "Iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Usuario inexistente.", "Iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
