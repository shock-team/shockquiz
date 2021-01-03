using Newtonsoft.Json;
using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace ShockQuiz.DAL.OpenTriviaDB
{
    public class JsonMapper
    {
        /// <summary>
        /// Devuelve el token alfanumérico proveniente de la API de OpenTDB. Se utiliza para que la API
        /// no envíe Preguntas repetidas.
        /// </summary>
        public static string ObtenerToken()
        {
            var mUrl = "https://opentdb.com/api_token.php?command=request";
            HttpWebRequest mRequest = (HttpWebRequest)WebRequest.Create(mUrl);

            try
            {
                WebResponse mResponse = mRequest.GetResponse();

                using (Stream responseStream = mResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    dynamic mResponseJSON = JsonConvert.DeserializeObject(reader.ReadToEnd());
                    return HttpUtility.HtmlDecode(mResponseJSON.token.ToString());
                }
            }
            catch (WebException ex)
            {
                WebResponse mErrorResponse = ex.Response;
                using (Stream mResponseStream = mErrorResponse.GetResponseStream())
                {
                    StreamReader mReader = new StreamReader(mResponseStream, Encoding.GetEncoding("utf-8"));
                    String mErrorText = mReader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return string.Empty;
        }

        /// <summary>
        /// Obtiene de OpenTDB una cantidad <paramref name="pNumber"/> de Preguntas y las almacena en la base de datos.
        /// </summary>
        /// <param name="pToken">API Token</param>
        /// <param name="pNumber">Cantidad de Preguntas</param>
        /// <returns></returns>
        public static List<Pregunta> GetPreguntas(string pToken = null, int pNumber = 10)
        {
            List<Pregunta> listaPreguntas = new List<Pregunta>();

            var mUrl = "https://opentdb.com/api.php?amount=" + pNumber + "&type=multiple";
            if (pToken != null)
            {
                mUrl = "https://opentdb.com/api.php?amount=" + pNumber + "&type=multiple&token=" + pToken;
            }


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

                    // Se iteran cada uno de los resultados.
                    foreach (var bResponseItem in mResponseJSON.results)
                    {
                        string preguntaDesc = HttpUtility.HtmlDecode(bResponseItem.question.ToString());
                        string categoria = HttpUtility.HtmlDecode(bResponseItem.category.ToString());
                        string dificultad = HttpUtility.HtmlDecode(bResponseItem.difficulty.ToString());

                        List<Respuesta> respuestas = new List<Respuesta>();
                        Respuesta respuestaCorrecta = new Respuesta()
                        {
                            EsCorrecta = true,
                            DefRespuesta = HttpUtility.HtmlDecode(bResponseItem.correct_answer.ToString())
                        };
                        respuestas.Add(respuestaCorrecta);

                        for (int i = 0; i < 3; i++)
                        {
                            Respuesta res = new Respuesta()
                            {
                                DefRespuesta = HttpUtility.HtmlDecode(bResponseItem.incorrect_answers[i].ToString()),
                                EsCorrecta = false
                            };
                            respuestas.Add(res);
                        }

                        Pregunta pregunta = new Pregunta()
                        {
                            Nombre = preguntaDesc,
                            Categoria = new Categoria() { Nombre = categoria },
                            Dificultad = new Dificultad() { Nombre = dificultad },
                            Respuestas = respuestas
                        };
                        if (pregunta.Nombre != string.Empty)
                        {
                            listaPreguntas.Add(pregunta);
                        }
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
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listaPreguntas;
        }
    }
}
