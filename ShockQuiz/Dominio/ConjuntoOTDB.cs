using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.Dominio
{
    public class ConjuntoOTDB : Conjunto
    {
        public override double CalcularPuntaje(Sesion pSesion)
        {
            int TIEMPO_LIMITE_1 = 5;
            int TIEMPO_LIMITE_2 = 20;
            double FACTOR_DIFICULTAD;
            switch (pSesion.Dificultad.Nombre)
            {
                case "hard":
                    FACTOR_DIFICULTAD = 5;
                    break;

                case "medium":
                    FACTOR_DIFICULTAD = 3;
                    break;

                default:
                    FACTOR_DIFICULTAD = 1;
                    break;
            }
            double FACTOR_TIEMPO;
            double tiempoPorPregunta = pSesion.Duracion().TotalSeconds / pSesion.CantidadPreguntas;
            if (tiempoPorPregunta < TIEMPO_LIMITE_1)
            {
                FACTOR_TIEMPO = 5;
            }
            else if (tiempoPorPregunta > TIEMPO_LIMITE_2)
            {
                FACTOR_TIEMPO = 1;
            }
            else
            {
                FACTOR_TIEMPO = 3;
            }
            return (pSesion.RespuestasCorrectas / pSesion.CantidadPreguntas) * FACTOR_DIFICULTAD * FACTOR_TIEMPO;
        }
    }
}
