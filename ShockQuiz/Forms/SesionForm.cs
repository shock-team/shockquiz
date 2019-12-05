using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Windows.Forms;
using ShockQuiz.Dominio;
using ShockQuiz.IO;


namespace ShockQuiz
{
    public partial class SesionForm : Form
    {
        FachadaSesion fachada = new FachadaSesion();
        int segTimer = 0;

        public SesionForm(string pUsuario, string pCategoria, string pDificultad, string pConjunto, int pCantidad)
        {
            InitializeComponent();
            lblCategoria.Text = pCategoria;
            lblDificultad.Text = pDificultad;
            fachada.IniciarSesion(pUsuario, pCategoria, pDificultad, pCantidad, pConjunto);
            lblRespuestasActuales.Text = "0";
            SiguientePregunta();
            lblRespuestasTotales.Text = pCantidad.ToString();

            timer1.Interval = 1000;
            timer1.Start();
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
        }

        private void Finalizar(ResultadoRespuesta pResultado)
        {
            if (pResultado.TiempoLimiteFinalizado)
            {
                timer1.Stop();
                btnSiguiente.Enabled = false;
                fachada.GuardarSesion();
                MessageBox.Show("Tiempo agotado! Puntaje: "+ fachada.ObtenerPuntaje(), "Fin de la partida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            else if (pResultado.FinSesion)
            {
                timer1.Stop();
                btnSiguiente.Enabled = false;
                fachada.GuardarSesion();
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
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            SiguientePregunta();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            segTimer += 1;
            lblTimer.Text = segTimer + " s";
            ResultadoRespuesta resultado = fachada.RevisarTiempoLimite();
            Finalizar(resultado);
        }
    }
}
