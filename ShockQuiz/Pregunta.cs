using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz
{
    class Pregunta
    {
        private string iPregunta { get; }
        private string iCategoria { get; }
        private string iDificultad { get; }
        private List<string> iRespuestas = new List<string>();
        private string iRespuestaCorrecta { get; }

        public Pregunta(string pPregunta, string pCategoria, string pDificultad, List<string> pRespuestas, string pRespuestaCorrecta)
        {
            this.iPregunta = pPregunta;
            this.iCategoria = pCategoria;
            this.iDificultad = pDificultad;
            this.iRespuestas = pRespuestas;
            this.iRespuestaCorrecta = pRespuestaCorrecta;
        }

        public bool Responder(string pRespuesta)
        {
            return pRespuesta == iRespuestaCorrecta;
        }

        public List<string> Respuestas()
        {
            Random random = new Random();
            string temp;
            List<string> lista = iRespuestas;
            lista.Add(iRespuestaCorrecta);
            for (int i = 0; i < lista.Count; i++)
            {
                temp = lista[i];
                lista[i] = lista[random.Next(lista.Count)];
                lista[random.Next(lista.Count)] = temp;
            }
            return lista;
        }
    }
}
