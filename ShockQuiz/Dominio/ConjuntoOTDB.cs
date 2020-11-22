using ShockQuiz.DAL.OpenTriviaDB;
using ShockQuiz.Forms;
using System;
using System.Collections.Generic;

namespace ShockQuiz.Dominio
{
    public class ConjuntoOTDB : Conjunto
    {
        FachadaConfiguracionAdmin fachada = new FachadaConfiguracionAdmin();

        public override double CalcularPuntaje(Sesion pSesion)
        {
            int TIEMPO_LIMITE_1 = 5;
            int TIEMPO_LIMITE_2 = 20;
            double FACTOR_DIFICULTAD = 1;
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
            double FACTOR_TIEMPO = 1;
            double tiempoPorPregunta = pSesion.SegundosTranscurridos / pSesion.CantidadTotalPreguntas;
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
            double puntaje = ((double)pSesion.RespuestasCorrectas / (double)pSesion.PreguntasRestantes) * FACTOR_DIFICULTAD * FACTOR_TIEMPO;
            return Math.Round(puntaje, 2);
        }


        public override void AgregarPreguntas(int pCantidad, string pToken = null)
        {
            if (pCantidad > 50)
            {
                int aux = pCantidad;
                while (aux > 0)
                {
                    List<Pregunta> preguntas = JsonMapper.GetPreguntas(pToken, aux);
                    fachada.AlmacenarPreguntas(preguntas);
                    aux -= 50;
                }
            }
            else
            {
                List<Pregunta> preguntas = JsonMapper.GetPreguntas(pToken, pCantidad);
                fachada.AlmacenarPreguntas(preguntas);
            }
        }
    }
}
