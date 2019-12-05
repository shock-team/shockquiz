using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShockQuiz.DAL.OpenTriviaDB;

namespace ShockQuiz.Dominio
{
    public class ConjuntoOTDB : Conjunto
    {
        public override double CalcularPuntaje(Sesion pSesion)
        {
            int TIEMPO_LIMITE_1 = 5;
            int TIEMPO_LIMITE_2 = 20;
            double FACTOR_DIFICULTAD=1;
            switch (pSesion.Dificultad.Nombre)
            {
                case "hard":
                    FACTOR_DIFICULTAD = 5;
                    break;

                case "medium":
                    FACTOR_DIFICULTAD = 3;
                    break;

                case "easy":
                    FACTOR_DIFICULTAD = 1;
                    break;
            }
            double FACTOR_TIEMPO=1;
            double tiempoPorPregunta = pSesion.Duracion().TotalSeconds / pSesion.CantidadPreguntas;
            if (tiempoPorPregunta < TIEMPO_LIMITE_1)
            {
                FACTOR_TIEMPO = 5;
            }
            if (tiempoPorPregunta > TIEMPO_LIMITE_2)
            {
                FACTOR_TIEMPO = 1;
            }
            if (tiempoPorPregunta >= TIEMPO_LIMITE_1 && tiempoPorPregunta <= TIEMPO_LIMITE_2)
            {
                FACTOR_TIEMPO = 3;
            }
            double puntaje = ((double)pSesion.RespuestasCorrectas / (double)pSesion.CantidadPreguntas) * FACTOR_DIFICULTAD * FACTOR_TIEMPO;
            return Math.Round(puntaje,2);
        }

        public override void AgregarPreguntas(int pCantidad)
        {
            string pToken = null;
            JsonMapper.AlmacenarPreguntas(pToken,pCantidad);
        }

        public override void AgregarPreguntas(string pToken, int pCantidad)
        {
            if (pCantidad > 50)
            {
                int aux = pCantidad;
                while (aux > 0)
                {
                    JsonMapper.AlmacenarPreguntas(pToken, aux);
                    aux -= 50;
                }
            }
            else
            {
                JsonMapper.AlmacenarPreguntas(pToken, pCantidad);
            }
        }
    }
}
