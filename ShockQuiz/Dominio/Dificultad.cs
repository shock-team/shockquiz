using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.Dominio
{
    public class Dificultad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Sesion> Sesiones { get; set; }
        public virtual ICollection<Pregunta> Preguntas { get; set; }
    }
}
