using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.Helpers
{
    public class ProgressReportModel
    {
        public int PercentageComplete { get; set; } = 0;
        public List<Pregunta> PreguntasAlmacenadas { get; set; } = new List<Pregunta>();
    }
}
