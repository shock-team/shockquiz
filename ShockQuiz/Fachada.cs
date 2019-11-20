using System.Collections.Generic;

namespace ShockQuiz
{
    class Fachada
    {
        private Sesion iSesionActual;
        private int iCantidadPreguntas;
        private int iRespuestasCorrectas;
        private int iFactorDificultad;
        private int iFactorTiempo;

        public void IniciarSesion(Usuario pUsuario, string pCategoria, string pDificultad)
        {

            //Sesion sesion = new Sesion(iCantidadPreguntas, pCategoria, pDificultad, DateTime.Now, pUsuario, )
        }

        public List<string> ObtenerRespuestas()
        {
            return iSesionActual.ObtenerRespuestas();
        }


        public bool Responder(Pregunta pPregunta, string pRespuesta)
        {
            return pPregunta.Responder(pRespuesta);
        }

        public void FinalizarSesion()
        {
            iSesionActual.Finalizar();
        }
    }
}
