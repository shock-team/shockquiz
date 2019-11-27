using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz
{
    public class Pregunta
    {/// <summary>
    /// El objetivo de esta clase es al
    /// </summary>
        private int PreguntaId { get; }
        private string Nombre { get; }
        private string Categoria { get; }
        private string Dificultad { get; }
        private IEnumerable<Respuesta> Respuestas = new List<Respuesta>();
        private Respuesta RespuestaCorrecta { get; }

        public Pregunta(string pPregunta, string pCategoria, string pDificultad, List<Respuesta> pRespuestas, Respuesta pRespuestaCorrecta)
        {
            this.Nombre = pPregunta;
            this.Categoria = pCategoria;
            this.Dificultad = pDificultad;
            this.Respuestas = pRespuestas;
            this.RespuestaCorrecta = pRespuestaCorrecta;
        }

        public ResultadoRespuesta Responder(string pRespuesta)
        {
            //Este método se encarga de comprobar si la respuesta ingresada es correcta, devolviendo
            //true si es así y false en caso contrario.
            return new ResultadoRespuesta(pRespuesta == RespuestaCorrecta.iRespuesta, false, RespuestaCorrecta.iRespuesta);
        }

        public PreguntaDTO ObtenerPreguntaYRespuestas()
        {
            //Este método se encarga de devolver las respuestas asociadas a la pregunta,
            //ordenadas aleatoriamente.
            Random random = new Random();
            string temp;
            List<string> lista = new List<string>();
            foreach (Respuesta respuesta in Respuestas)
            {
                lista.Add(respuesta.iRespuesta);
            }
            lista.Add(RespuestaCorrecta.iRespuesta);
            int a;
            int b;
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 0; j < lista.Count - i; j++)
                {
                    a = random.Next();
                    b = random.Next();
                    if (a > b)
                    {
                        temp = lista[j];
                        lista[j] = lista[i];
                        lista[i] = temp;
                    }
                }
            }
            PreguntaDTO pregunta = new PreguntaDTO();
            pregunta.iPregunta = Nombre;
            pregunta.iRespuestas = lista;
            return pregunta;
        }
    }
}
