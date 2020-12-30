using ShockQuiz.Dominio;
using ShockQuiz.IO;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Drawing;

namespace ShockQuiz
{
    public partial class SesionForm : Form
    {
        FachadaSesion fachada = new FachadaSesion();
        int idSesionActual;
        PreguntaDTO preguntaActual;

        public SesionForm(int pSesionId)
        {
            InitializeComponent();

            Sesion sesionActual = fachada.ObtenerSesion(pSesionId);
            NombresDatos nombresDatos = sesionActual.ObtenerNombres();

            lblCategoria.Text = nombresDatos.Categoria;
            lblDificultad.Text = nombresDatos.Dificultad;
            idSesionActual = pSesionId;
            lblRespuestasActuales.Text = (sesionActual.CantidadTotalPreguntas - sesionActual.Preguntas.Count).ToString();
            lblRespuestasTotales.Text = sesionActual.CantidadTotalPreguntas.ToString();

            LoadFont();

            SiguientePregunta();

            fachada.IniciarTimer(FinTiempoLimite,ActualizarTimer, idSesionActual);
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
                MessageBox.Show("¡Tiempo agotado! Puntaje: " + fachada.ObtenerPuntaje(idSesionActual), "Fin de la partida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            else if (pResultado.FinSesion)
            {
                fachada.DetenerTimer();
                btnSiguiente.Enabled = false;
                MessageBox.Show("Puntaje: " + fachada.ObtenerPuntaje(idSesionActual), "Fin de la partida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
                this.Close();
            }
        }

        private void LogicaRespuesta(Button pBtnRespuesta, int pIndiceRespuesta)
        {
            ResultadoRespuesta resultado = fachada.Responder(idSesionActual, preguntaActual.IdPregunta, preguntaActual.Respuestas[pIndiceRespuesta].IdRespuesta);
            if (!resultado.EsCorrecta)
            {
                pBtnRespuesta.BackColor = System.Drawing.Color.Red;
            }
            ColorBotonCorrecto(resultado.RespuestaCorrecta);
            Finalizar(resultado);
        }

        private void BtnRespuesta1_Click(object sender, EventArgs e) => LogicaRespuesta(btnRespuesta1, 0);
        private void BtnRespuesta2_Click(object sender, EventArgs e) => LogicaRespuesta(btnRespuesta2, 1);
        private void BtnRespuesta3_Click(object sender, EventArgs e) => LogicaRespuesta(btnRespuesta3, 2);
        private void BtnRespuesta4_Click(object sender, EventArgs e) => LogicaRespuesta(btnRespuesta4, 3);

        private void SiguientePregunta()
        {
            preguntaActual = fachada.ObtenerPreguntaYRespuestas(idSesionActual);

            lblPregunta.Text = preguntaActual.Pregunta;

            btnRespuesta1.Text = preguntaActual.Respuestas[0].Respuesta;
            btnRespuesta1.Enabled = true;
            btnRespuesta1.BackColor = System.Drawing.SystemColors.Control;

            btnRespuesta2.Text = preguntaActual.Respuestas[1].Respuesta;
            btnRespuesta2.Enabled = true;
            btnRespuesta2.BackColor = System.Drawing.SystemColors.Control;

            btnRespuesta3.Text = preguntaActual.Respuestas[2].Respuesta;
            btnRespuesta3.Enabled = true;
            btnRespuesta3.BackColor = System.Drawing.SystemColors.Control;

            btnRespuesta4.Text = preguntaActual.Respuestas[3].Respuesta;
            btnRespuesta4.Enabled = true;
            btnRespuesta4.BackColor = System.Drawing.SystemColors.Control;

            lblRespuestasActuales.Text = (int.Parse(lblRespuestasActuales.Text) + 1).ToString();
            btnSiguiente.Enabled = false;
        }

        private void FinTiempoLimite()
        {
            btnSiguiente.Enabled = false;
            fachada.FinTiempoLimite(idSesionActual);
            MessageBox.Show("¡Tiempo agotado! Puntaje: " + fachada.ObtenerPuntaje(idSesionActual), "Fin de la partida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();
        }

        private void BtnSiguiente_Click(object sender, EventArgs e) => SiguientePregunta();

        private void SesionForm_FormClosing(object sender, FormClosingEventArgs e) => fachada.DetenerTimer();

        private void ActualizarTimer(int pTiempoRestante) => lblTimer.Text = pTiempoRestante.ToString()+ " s";

        PrivateFontCollection fonts = new PrivateFontCollection();

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        private void LoadFont()
        {
            byte[] fontData = Properties.Resources.Adobe_Garamond_Pro_Regular;
            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.Adobe_Garamond_Pro_Regular.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.Adobe_Garamond_Pro_Regular.Length, IntPtr.Zero, ref dummy);
            Marshal.FreeCoTaskMem(fontPtr);

            Font preguntaFont = new Font(fonts.Families[0], 21.0F);
            lblPregunta.Font = preguntaFont;

            Font otrosFont = new Font(fonts.Families[0], 15.0F);
            lblCategoria.Font = otrosFont;
            lblDificultad.Font = otrosFont;
            lblRespuestasActuales.Font = otrosFont;
            lblRespuestasTotales.Font = otrosFont;
            lblTimer.Font = otrosFont;
            label2.Font = otrosFont;
            label4.Font = otrosFont;
            label6.Font = otrosFont;
            label8.Font = otrosFont;
            label9.Font = otrosFont;
            btnRespuesta1.Font = otrosFont;
            btnRespuesta2.Font = otrosFont;
            btnRespuesta3.Font = otrosFont;
            btnRespuesta4.Font = otrosFont;
        }
    }
}