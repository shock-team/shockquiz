﻿using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ShockQuiz.Forms
{
    public partial class RankingForm : Form
    {
        FachadaRanking facha = new FachadaRanking();
        public RankingForm()
        {
            InitializeComponent();
            List<Sesion> ranking = facha.ObtenerTop();
            dgvRanking.DataSource = ranking.Select(x => new
            {
                x.Usuario.Nombre,
                x.Puntaje,
                Fecha = x.FechaInicio,
                Duración = x.SegundosTranscurridos
            })
                .ToList();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            List<Sesion> ranking = facha.ObtenerTop(Decimal.ToInt32(nudTop.Value));
            dgvRanking.DataSource = ranking.Select(x => new
            {
                x.Usuario.Nombre,
                x.Puntaje,
                Fecha = x.FechaInicio,
                Duración = x.SegundosTranscurridos
            }).ToList();
        }
    }
}
