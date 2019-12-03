using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz
{
    public class PreguntaDTO
    {
        public string Pregunta { get; set; }
        public IList<string> Respuestas { get; set; }
    }
}
