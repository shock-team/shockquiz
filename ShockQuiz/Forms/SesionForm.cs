using ShockQuiz.Dominio;
using ShockQuiz.IO;
using System;
using System.Windows.Forms;


namespace ShockQuiz
{
    public partial class SesionForm : Form
    {
        FachadaSesion fachada = new FachadaSesion();

        public SesionForm(int pSesionId, string pCategoria, string pDificultad, int pCantidad)
        {
            InitializeComponent();
            lblCategoria.Text = pCategoria;
            lblDificultad.Text = pDificultad;
            fachada.idSesionActual = pSesionId;
            lblRespuestasActuales.Text = "0";
            SiguientePregunta();
            lblRespuestasTotales.Text = pCantidad.ToString();
        }

        private void ColorBotonCorrecto(string pRespuesta)
        {
            if (btnRespuesta1.Text == pRespuesta)
            {
                btnRespuesta1.BackColor = System.Drawing.Color.Green;
            }
            else if (btnRespuesta2.Text == pRespuesta)
            {
                btnRespuesta2.BackColor = System.Drawing.Color.Green;
            }
            else if (btnRespuesta3.Text == pRespuesta)
            {
                btnRespuesta3.BackColor = System.Drawing.Color.Green;
            }
            else if (btnRespuesta4.Text == pRespuesta)
            {
                btnRespuesta4.BackColor = System.Drawing.Color.Green;
            }
            btnRespuesta1.Enabled = false;
            btnRespuesta2.Enabled = false;
            btnRespuesta3.Enabled = false;
            btnRespuesta4.Enabled = false;
            btnSiguiente.Enabled = true;
        }

        private void Finalizar(ResultadoRespuesta pResultado)
        {
            if (pResultado.TiempoLimiteFinalizado)
            {
                btnSiguiente.Enabled = false;
                MessageBox.Show("¡Tiempo agotado! Puntaje: " + fachada.ObtenerPuntaje(), "Fin de la partida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            else if (pResultado.FinSesion)
            {
                btnSiguiente.Enabled = false;
                MessageBox.Show("Puntaje: " + fachada.ObtenerPuntaje(), "Fin de la partida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
                this.Close();
            }
        }

        private void BtnRespuesta1_Click(object sender, EventArgs e)
        {
            ResultadoRespuesta resultado = fachada.Responder(btnRespuesta1.Text);
            if (!resultado.EsCorrecta)
            {
                btnRespuesta1.BackColor = System.Drawing.Color.Red;
            }
            ColorBotonCorrecto(resultado.RespuestaCorrecta);
            Finalizar(resultado);
        }

        private void BtnRespuesta2_Click(object sender, EventArgs e)
        {
            ResultadoRespuesta resultado = fachada.Responder(btnRespuesta2.Text);
            if (!resultado.EsCorrecta)
            {
                btnRespuesta2.BackColor = System.Drawing.Color.Red;
            }
            ColorBotonCorrecto(resultado.RespuestaCorrecta);
            Finalizar(resultado);
        }

        private void BtnRespuesta3_Click(object sender, EventArgs e)
        {
            ResultadoRespuesta resultado = fachada.Responder(btnRespuesta3.Text);
            if (!resultado.EsCorrecta)
            {
                btnRespuesta3.BackColor = System.Drawing.Color.Red;
            }
            ColorBotonCorrecto(resultado.RespuestaCorrecta);
            Finalizar(resultado);
        }

        private void BtnRespuesta4_Click(object sender, EventArgs e)
        {
            ResultadoRespuesta resultado = fachada.Responder(btnRespuesta4.Text);
            if (!resultado.EsCorrecta)
            {
                btnRespuesta4.BackColor = System.Drawing.Color.Red;
            }
            ColorBotonCorrecto(resultado.RespuestaCorrecta);
            Finalizar(resultado);
        }

        private void SiguientePregunta()
        {
            fachada.IniciarTimer();
            PreguntaDTO actual = fachada.ObtenerPreguntaYRespuestas();
            lblPregunta.Text = actual.Pregunta;
            btnRespuesta1.Text = actual.Respuestas[0];
            btnRespuesta1.Enabled = true;
            btnRespuesta1.BackColor = System.Drawing.SystemColors.Control;
            btnRespuesta2.Text = actual.Respuestas[1];
            btnRespuesta2.Enabled = true;
            btnRespuesta2.BackColor = System.Drawing.SystemColors.Control;
            btnRespuesta3.Text = actual.Respuestas[2];
            btnRespuesta3.Enabled = true;
            btnRespuesta3.BackColor = System.Drawing.SystemColors.Control;
            btnRespuesta4.Text = actual.Respuestas[3];
            btnRespuesta4.Enabled = true;
            btnRespuesta4.BackColor = System.Drawing.SystemColors.Control;
            lblRespuestasActuales.Text = (int.Parse(lblRespuestasActuales.Text) + 1).ToString();
            btnSiguiente.Enabled = false;
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            SiguientePregunta();
        }

        public void FinTiempoLimite()
        {
            btnSiguiente.Enabled = false;
            fachada.FinTiempoLimite();
            MessageBox.Show("¡Tiempo agotado! Puntaje: " + fachada.ObtenerPuntaje(), "Fin de la partida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();
        }
    }
}
