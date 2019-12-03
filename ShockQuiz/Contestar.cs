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
    public partial class Contestar : Form
    {
        Fachada fachada = new Fachada();

        public void JSON()
        {

            // Url de ejemplo
            var mUrl = "https://opentdb.com/api.php?amount=5&category=31&type=multiple";

            // Se crea el request http
            HttpWebRequest mRequest = (HttpWebRequest)WebRequest.Create(mUrl);

            try
            {
                // Se ejecuta la consulta
                WebResponse mResponse = mRequest.GetResponse();

                // Se obtiene los datos de respuesta
                using (Stream responseStream = mResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);

                    // Se parsea la respuesta y se serializa a JSON a un objeto dynamic
                    dynamic mResponseJSON = JsonConvert.DeserializeObject(reader.ReadToEnd());

                    //MessageBox.Show("Código de respuesta: "+ mResponseJSON.response_code);
                    Random rand = new Random();
                    // Se iteran cada uno de los resultados.
                    foreach (var bResponseItem in mResponseJSON.results)
                    {
                        // De esta manera se accede a los componentes de cada item
                        // Se decodifican algunos elementos HTML
                        MessageBox.Show(HttpUtility.HtmlDecode(bResponseItem.question.ToString()));

                        String[] res = new String[4];
                        for (int w = 0; w < 3; w++)
                        {
                            res[w] = HttpUtility.HtmlDecode(bResponseItem.incorrect_answers[w].ToString());
                        }
                        res[3] = HttpUtility.HtmlDecode(bResponseItem.correct_answer.ToString());

                        int a = rand.Next(0, 3);
                        List<byte> indices = new List<byte>();
                        for (byte i = 0; i < 3; i++)
                        {
                            indices.Add(i);
                        }
                        int j = indices.Count;
                        while (j > 0)
                        {
                            int x = indices[j];



                        }
                        //MessageBox.Show("Respuestas: " +resShow[0]+", "+ resShow[1]+", "+ resShow[2]+", "+ resShow[3] +".");

                        //MessageBox.Show(HttpUtility.HtmlDecode(bResponseItem.incorrect_answers[0].ToString()));
                        //MessageBox.Show("Respuesta correcta: " + HttpUtility.HtmlDecode(bResponseItem.correct_answer.ToString()));
                        // Se muestra por pantalla cada item completo
                        //MessageBox.Show("Item completo -> "+ bResponseItem);

                    }
                }
            }
            catch (WebException ex)
            {
                WebResponse mErrorResponse = ex.Response;
                using (Stream mResponseStream = mErrorResponse.GetResponseStream())
                {
                    StreamReader mReader = new StreamReader(mResponseStream, Encoding.GetEncoding("utf-8"));
                    String mErrorText = mReader.ReadToEnd();

                    MessageBox.Show("Error: " + mErrorText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }
        public Contestar(Categoria pCategoria, Dificultad pDificultad)
        {
            InitializeComponent();
            JSON();
            lblCategoria.Text = pCategoria.Nombre;
            lblDificultad.Text = pDificultad.Nombre;
            lblRespuestasActuales.Text = "0";
            SiguientePregunta();
            lblRespuestasTotales.Text = fachada.iCantidadPreguntas.ToString();
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

        private void Finalizar(bool pFin)
        {
            if (pFin)
            {
                MessageBox.Show("Puntaje: " + fachada.ObtenerPuntaje().ToString(), "Fin de la partida");
                timer1.Stop();
                btnSiguiente.Enabled = false;
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
            Finalizar(resultado.FinSesion);
        }

        private void BtnRespuesta2_Click(object sender, EventArgs e)
        {
            ResultadoRespuesta resultado = fachada.Responder(btnRespuesta2.Text);
            if (!resultado.EsCorrecta)
            {
                btnRespuesta2.BackColor = System.Drawing.Color.Red;
            }
            ColorBotonCorrecto(resultado.RespuestaCorrecta);
            Finalizar(resultado.FinSesion);
        }

        private void BtnRespuesta3_Click(object sender, EventArgs e)
        {
            ResultadoRespuesta resultado = fachada.Responder(btnRespuesta3.Text);
            if (!resultado.EsCorrecta)
            {
                btnRespuesta3.BackColor = System.Drawing.Color.Red;
            }
            ColorBotonCorrecto(resultado.RespuestaCorrecta);
            Finalizar(resultado.FinSesion);
        }

        private void BtnRespuesta4_Click(object sender, EventArgs e)
        {
            ResultadoRespuesta resultado = fachada.Responder(btnRespuesta4.Text);
            if (!resultado.EsCorrecta)
            {
                btnRespuesta4.BackColor = System.Drawing.Color.Red;
            }
            ColorBotonCorrecto(resultado.RespuestaCorrecta);
            Finalizar(resultado.FinSesion);
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
            lblTimer.Text = timer1.ToString();
        }
    }
}
