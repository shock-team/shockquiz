﻿using ShockQuiz.Dominio;
using ShockQuiz.Helpers;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using ShockQuiz.Dominio.Conjuntos;

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

        private async void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (nudCantidad.Value > 0)
            {
                try
                {
                    Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
                    progress.ProgressChanged += ReportProgress;

                    Conjunto conjunto = fachada.ObtenerConjunto(((Conjunto)cbConjunto.SelectedItem).ConjuntoId);
                    await conjunto.AgregarPreguntasAsync(Decimal.ToInt32(nudCantidad.Value), progress, fachada.AlmacenarPreguntas, conjunto.Token);
                    
                    MessageBox.Show($"{Decimal.ToInt32(nudCantidad.Value)} preguntas añadidas correctamente al conjunto {cbConjunto.Text}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ha habido un error con la base de datos", "Error");
                }
                finally
                {
                    progressBar.Value = 0;
                }
            }
            else
            {
                MessageBox.Show("La cantidad de preguntas a agregar debe ser mayor que 0", "Error");
            }

        }

        private void ReportProgress(object sender, ProgressReportModel e)
        {
            progressBar.Value = e.PercentageComplete;
        }

        private void btnAddConjunto_Click(object sender, EventArgs e)
        {
            try
            {
                fachada.AñadirConjunto(txtAddConjunto.Text, Decimal.ToInt32(nudAddConjunto.Value), cbToken.Checked, comboTipoConjunto.SelectedIndex);
                ActualizarConjuntos();
                MessageBox.Show("Conjunto OpenTDB añadido correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddConjunto.Clear();
                nudAddConjunto.Value = 1;
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
                    MessageBox.Show("Operación realiazada correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex )
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}
