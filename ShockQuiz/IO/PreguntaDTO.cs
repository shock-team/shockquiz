using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.IO
{
    public class PreguntaDTO
    {
        private string Pregunta { get; set; }
        private IList<string> Respuestas { get; set; }
    }
}
