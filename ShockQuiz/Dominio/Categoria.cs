using System.Collections.Generic;

namespace ShockQuiz.Dominio
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Pregunta> Preguntas { get; set; }
    }
}
