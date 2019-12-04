using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.Dominio
{
    public class Respuesta
    {
        public int RespuestaId { get; set; }
        public string DefRespuesta { get; set; }

        public virtual Pregunta PreguntaCorrecta { get; set; }

        public Nullable<int> PreguntaId { get; set; }
        public virtual Pregunta Pregunta { get; set; }

    }
}
