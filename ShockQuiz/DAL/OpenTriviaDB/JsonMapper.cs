﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using ShockQuiz.Dominio;

namespace ShockQuiz.DAL.OpenTriviaDB
{
    public class JsonMapper
    {
        public static List<Pregunta> Mapper(int pNumber = 10)
        {
            List<Pregunta> listaPreguntas = new List<Pregunta>();

            // Url
            var mUrl = "https://opentdb.com/api.php?amount="+pNumber+"&type=multiple";

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
                        Respuesta respuestaCorrecta = new Respuesta()
                        {
                               DefRespuesta = HttpUtility.HtmlDecode(bResponseItem.correct_answer.ToString())
                        };
                       
                        List<Respuesta> respuestasIncorrectas = new List<Respuesta>();
                        for (int i = 0; i < 3; i++)
                        {
                            Respuesta res = new Respuesta()
                            {
                                DefRespuesta = HttpUtility.HtmlDecode(bResponseItem.incorrect_answers[i].ToString())
                            };
                            respuestasIncorrectas.Add(res);
                        }

                        Pregunta pregunta = new Pregunta()
                        {
                            Nombre = preguntaDesc,
                            Categoria = new Categoria()
                            {
                                Nombre = categoria
                            },
                            Dificultad = new Dificultad()
                            {
                                Nombre = dificultad
                            },
                            RespuestasIncorrectas = respuestasIncorrectas,
                            RespuestaCorrecta = respuestaCorrecta
                        };
                        listaPreguntas.Add(pregunta);
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
            catch (Exception)
            {
                throw;
                //MessageBox.Show("Error: " + ex.Message);
            }
            return listaPreguntas;
        }
    }
}
