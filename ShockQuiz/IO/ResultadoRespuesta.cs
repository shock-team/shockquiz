namespace ShockQuiz.IO
{
    public class ResultadoRespuesta
    {
        public bool EsCorrecta { get; set; }
        public bool FinSesion { get; set; }
        public string RespuestaCorrecta { get; set; }
        public bool TiempoLimiteFinalizado { get; set; }
    }
}
