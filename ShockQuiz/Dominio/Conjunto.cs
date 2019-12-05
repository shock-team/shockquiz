using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.Dominio
{
    public abstract class Conjunto
    {
        public int ConjuntoId { get; set; }
        public string Nombre { get; set; }
        public double TiempoEsperadoPorPregunta { get; set; }
        public string Token { get; set; }
        public ICollection<Sesion> Sesiones { get; set; }
        public ICollection<Pregunta> Preguntas { get; set; }

        public virtual double CalcularPuntaje(Sesion pSesion)
        {
            throw new NotImplementedException();
        }

        public virtual void AgregarPreguntas(int pCantidad)
        {
        }

        public virtual void AgregarPreguntas(string pToken,int pCantidad)
        {
        }
    }
}
