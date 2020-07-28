using Newtonsoft.Json;

namespace ShockQuiz.Dominio
{
    public class Respuesta
    {
        public int RespuestaId { get; set; }
        public string DefRespuesta { get; set; }
        public bool EsCorrecta { get; set; }

        public int PreguntaId { get; set; }
        [JsonIgnore]
        public Pregunta Pregunta { get; set; }

    }
}
