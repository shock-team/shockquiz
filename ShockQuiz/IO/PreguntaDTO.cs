using System.Collections.Generic;

namespace ShockQuiz.IO
{
    public class PreguntaDTO
    {
        public int IdPregunta { get; set; }
        public string Pregunta { get; set; }
        public List<RespuestaDTO> Respuestas { get; set; } = new List<RespuestaDTO>();
    }
}
