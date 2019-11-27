using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.Dominio
{
    public class ResultadoRespuesta
    {
        public bool EsCorrecta { get; }
        public bool FinSesion { get; set; }
        public string RespuestaCorrecta { get; }

        public ResultadoRespuesta(bool pCorrecta, bool pFin, string pRespuesta)
        {
            EsCorrecta = pCorrecta;
            FinSesion = pFin;
            RespuestaCorrecta = pRespuesta;
        }
    }
}
