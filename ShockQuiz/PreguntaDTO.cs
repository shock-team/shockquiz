using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz
{
    public class PreguntaDTO
    {
        public string iPregunta { get; set; }
        public IEnumerable<string> iRespuestas { get; set; }
    }
}
