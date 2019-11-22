using System;
using System.Collections.Generic;
using System.Linq;

namespace ShockQuiz
{
    class Sesion
    {
        private int iCantidadPreguntas { get; }
        private string iCategoria { get; }
        private string iDificultad { get; }
        private double iPuntaje;
        private DateTime iFechaInicio;
        private DateTime iFechaFin;
        private Usuario iUsuario { get; }
        private List<Pregunta> iPreguntas;
        private int iRespuestasCorrectas = 0;

        public Sesion(int pCantidadPreguntas, string pCategoria, string pDificultad, double pPuntaje, DateTime pFecha, DateTime pFechaFin, Usuario pUsuario, List<Pregunta> pPreguntas)
        {
            this.iCantidadPreguntas = pCantidadPreguntas;
            this.iCategoria = pCategoria;
            this.iDificultad = pDificultad;
            this.iPuntaje = pPuntaje;
            this.iFechaInicio = pFecha;
            this.iFechaFin = pFechaFin;
            this.iUsuario = pUsuario;
            this.iPreguntas = pPreguntas;
        }

        public double Puntaje
        {
            get { return this.iPuntaje; }
        }


        public PreguntaDTO ObtenerPreguntaYRespuestas()
        {
            return iPreguntas.First().ObtenerPreguntaYRespuestas();
        }

        public ResultadoRespuesta Responder(string pRespuesta)
        {
            Pregunta pregunta = iPreguntas.First();
            ResultadoRespuesta resultado = pregunta.Responder(pRespuesta);
            if (resultado.iEsCorrecta)
            {
                iRespuestasCorrectas++;
            }
            iPreguntas.Remove(pregunta);
            if (iPreguntas.Count() == 0)
            {
                resultado.iFinSesion = true;
                Finalizar();
            }
            return resultado;
        }

        public TimeSpan Duracion()
        {
            return iFechaFin - iFechaInicio;
        }

        public void Finalizar()
        {
            double factorTiempo = 1;
            double factorDificultad = 1;
            this.iFechaFin = DateTime.Now;
            iPuntaje = (iRespuestasCorrectas / iCantidadPreguntas) * factorTiempo * factorDificultad;
        }
    }
}
