using ShockQuiz.Dominio;
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
            dgvRanking.Rows.Clear();
            List<Sesion> ranking = facha.ObtenerTop();
            foreach (var item in ranking)
            {
                dgvRanking.Rows.Add(item.Usuario.Nombre, item.Puntaje, item.FechaInicio, item.SegundosTranscurridos);

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            dgvRanking.Rows.Clear();
            List<Sesion> ranking = facha.ObtenerTop(Decimal.ToInt32(nudTop.Value));
            foreach (var item in ranking)
            {
                dgvRanking.Rows.Add(item.Usuario.Nombre, item.Puntaje, item.FechaInicio, item.SegundosTranscurridos);

            }
        }
    }
}
