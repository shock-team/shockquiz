using System.Collections.Generic;
using ShockQuiz.Dominio;

namespace ShockQuiz
{
    public class Fachada
    {
        private Sesion iSesionActual;
        private int iCantidadPreguntas;
        public int iRespuestasCorrectas { get; set; }
        private int iFactorDificultad;
        private int iFactorTiempo;

        public void IniciarSesion(Usuario pUsuario, string pCategoria, string pDificultad)
        {

            //Sesion sesion = new Sesion(iCantidadPreguntas, pCategoria, pDificultad, DateTime.Now, pUsuario, )
        }

        public PreguntaDTO ObtenerPreguntaYRespuestas()
        {
            return iSesionActual.ObtenerPreguntaYRespuestas();
        }


        public ResultadoRespuesta Responder(string pRespuesta)
        {
            ResultadoRespuesta resultado = iSesionActual.Responder(pRespuesta);
            if (resultado.EsCorrecta)
            {
                iRespuestasCorrectas++;
            }
            return resultado;
        }
    }
}
