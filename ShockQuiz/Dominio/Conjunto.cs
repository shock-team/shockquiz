using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.Dominio
{
    public class Conjunto
    {
        public int ConjuntoId { get; set; }
        public string Nombre { get; set; }
        public ICollection<Sesion> Sesiones { get; set; }
        public ICollection<Pregunta> Preguntas { get; set; }
    }
}
