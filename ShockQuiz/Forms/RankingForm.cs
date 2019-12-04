using ShockQuiz.Dominio;
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
    public partial class RankingForm : Form
    {
        FachadaRanking facha = new FachadaRanking();
        public RankingForm()
        {
            InitializeComponent();
            List<Sesion> ranking = facha.ObtenerTop();
            dgvRanking.DataSource = ranking.Select(x => new {
                x.Usuario, 
                x.Puntaje,
                Fecha=x.FechaInicio,
                Duración=x.Duracion()})
                .ToList();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
