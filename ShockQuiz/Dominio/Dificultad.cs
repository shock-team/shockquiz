using Newtonsoft.Json;
using System.Collections.Generic;

namespace ShockQuiz.Dominio
{
    public class Dificultad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [JsonIgnore]
        public ICollection<Sesion> Sesiones { get; set; }
        [JsonIgnore]
        public ICollection<Pregunta> Preguntas { get; set; }
    }
}
