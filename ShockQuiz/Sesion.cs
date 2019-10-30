using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz
{
    class Sesion
    {
        private int iCantidadPreguntas { get; }
        private string iCategoria { get; }
        private string iDificultad { get; }
        private double iPuntaje;
        private DateTime iFecha { get; }
        private Usuario iUsuario { get; }
        private List<Pregunta> iPreguntas;

        public Sesion(int pCantidadPreguntas, string pCategoria, string pDificultad, double pPuntaje, DateTime pFecha, Usuario pUsuario, List<Pregunta> pPreguntas)
        {
            this.iCantidadPreguntas = pCantidadPreguntas;
            this.iCategoria = pCategoria;
            this.iDificultad = pDificultad;
            this.iPuntaje = pPuntaje;
            this.iFecha = pFecha;
            this.iUsuario = pUsuario;
            this.iPreguntas = pPreguntas;
        }

        public double Puntaje
        {
            get { return this.iPuntaje; }
        }

        public void Puntuar(double pPuntaje)
        {
            this.iPuntaje = pPuntaje;
        }

        public Pregunta SiguientePregunta()
        {
            if (iPreguntas.Count() != 0)
            {
                Pregunta pregunta = this.iPreguntas.First();
                this.iPreguntas.Remove(pregunta);
                return pregunta;
            }
            else
            {
                ListaVaciaException listaVacia = new ListaVaciaException();
                throw listaVacia;
            }
        }
    }
}
