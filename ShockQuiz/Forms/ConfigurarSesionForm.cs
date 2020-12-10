﻿using ShockQuiz.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ShockQuiz.Dominio;

namespace ShockQuiz.Forms
{
    public partial class ConfigurarSesionForm : Form
    {
        int idUsuario;
        FachadaConfigurarSesion fachada = new FachadaConfigurarSesion();

        public ConfigurarSesionForm(int pUsuario)
        {
            InitializeComponent();
            idUsuario = pUsuario;
            cbConjunto.DisplayMember = "Nombre";
            cbConjunto.ValueMember = "Id";
            cbDificultad.DisplayMember = "Nombre";
            cbDificultad.ValueMember = "Id";
            cbCategoria.DisplayMember = "Nombre";
            cbCategoria.ValueMember = "Id";
            foreach (Conjunto conjunto in fachada.ObtenerConjuntos())
            {
                cbConjunto.Items.Add(conjunto);
            }
            if (cbConjunto.Items.Count == 1)
            {
                cbConjunto.SelectedIndex = 0;
                cbConjunto.Enabled = false;
            }
            foreach (Dificultad dificultad in fachada.ObtenerDificultades())
            {
                cbDificultad.Items.Add(dificultad);
            }
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                var categoria = (Categoria)cbCategoria.SelectedItem ?? new Categoria { };
                var dificultad = (Dificultad)cbDificultad.SelectedItem ?? new Dificultad { };
                var sesion = fachada.IniciarSesion(idUsuario, categoria.Id, dificultad.Id, Decimal.ToInt32(nudCantidad.Value), ((Conjunto)cbConjunto.SelectedItem).ConjuntoId);
                SesionForm sesionForm = new SesionForm(sesion.SesionId, categoria.Nombre, dificultad.Nombre, Decimal.ToInt32(nudCantidad.Value));
                sesionForm.FormClosed += new FormClosedEventHandler(SesionForm_FormClosed);
                sesionForm.Show();
                this.Hide();
            }
            catch (PreguntasInsuficientesException)
            {
                MessageBox.Show("No hay preguntas suficientes para la selección", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione una dificultad y categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CbConjunto_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCategoria.Items.Clear();
            Conjunto conjunto = (Conjunto)cbConjunto.SelectedItem;
            List<Categoria> categorias = fachada.ObtenerCategorias(conjunto.ConjuntoId).ToList();
            foreach (Categoria categoria in categorias)
            {
                cbCategoria.Items.Add(categoria);
            }
        }
        private void BtnCancelar_Click(object sender, EventArgs e) => this.Close();

        private void SesionForm_FormClosed(object sender, EventArgs e) => this.Close();
    }
}
