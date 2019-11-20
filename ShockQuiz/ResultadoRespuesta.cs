using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz
{
    class ResultadoRespuesta
    {
        public bool iEsCorrecta { get; }
        public bool iFinSesion { get; set; }
        public string iRespuestaCorrecta { get; }

        public ResultadoRespuesta(bool pCorrecta, bool pFin, string pRespuesta)
        {
            iEsCorrecta = pCorrecta;
            iFinSesion = pFin;
            iRespuestaCorrecta = pRespuesta;
        }
    }
}
