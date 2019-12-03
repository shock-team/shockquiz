using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.IO
{
    public class ResultadoRespuesta
    {
        public bool EsCorrecta { get; set; }
        public bool FinSesion { get; set; }
        public string RespuestaCorrecta { get; set; }
    }
}
