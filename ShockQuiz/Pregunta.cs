using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz
{
    class Pregunta
    {/// <summary>
    /// El objetivo de esta clase es al
    /// </summary>
        private string iPregunta { get; }
        private string iCategoria { get; }
        private string iDificultad { get; }
        private List<Respuesta> iRespuestas = new List<Respuesta>();
        private Respuesta iRespuestaCorrecta { get; }

        public Pregunta(string pPregunta, string pCategoria, string pDificultad, List<Respuesta> pRespuestas, Respuesta pRespuestaCorrecta)
        {
            this.iPregunta = pPregunta;
            this.iCategoria = pCategoria;
            this.iDificultad = pDificultad;
            this.iRespuestas = pRespuestas;
            this.iRespuestaCorrecta = pRespuestaCorrecta;
        }

        public ResultadoRespuesta Responder(string pRespuesta)
        {
            //Este método se encarga de comprobar si la respuesta ingresada es correcta, devolviendo
            //true si es así y false en caso contrario.
            return new ResultadoRespuesta(pRespuesta == iRespuestaCorrecta.iRespuesta, false, iRespuestaCorrecta.iRespuesta);
        }

        public List<string> ObtenerRespuestas()
        {
            //Este método se encarga de devolver las respuestas asociadas a la pregunta,
            //ordenadas aleatoriamente.
            Random random = new Random();
            string temp;
            List<string> lista = new List<string>();
            foreach (Respuesta respuesta in iRespuestas)
            {
                lista.Add(respuesta.iRespuesta);
            }
            lista.Add(iRespuestaCorrecta.iRespuesta);
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
            return lista;
        }
    }
}
