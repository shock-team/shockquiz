using ShockQuiz.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShockQuiz.Dominio
{
    public abstract class Conjunto
    {
        public int ConjuntoId { get; set; }
        public string Nombre { get; set; }
        public double TiempoEsperadoPorPregunta { get; set; }
        public string Token { get; set; }
        public ICollection<Pregunta> Preguntas { get; set; }

        public virtual double CalcularPuntaje(Sesion pSesion)
        {
            throw new NotImplementedException();
        }

        public virtual void AgregarPreguntas(int pCantidad, string pToken = null)
        {
        }        
        
        public virtual Task AgregarPreguntasAsync(int pCantidad, 
            IProgress<ProgressReportModel> progress,
            Action<List<Pregunta>, IProgress<ProgressReportModel>, int, int, string> almacenarPreguntas,
            string pToken = null)
        {
            throw new NotImplementedException();
        }        
    }
}
