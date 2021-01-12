using ShockQuiz.DAL.OpenTriviaDB;
using ShockQuiz.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShockQuiz.Dominio.Conjuntos
{
    public class ConjuntoOTDB : Conjunto
    {
        public override double CalcularPuntaje(Sesion pSesion)
        {
            int TIEMPO_LIMITE_1 = 5;
            int TIEMPO_LIMITE_2 = 20;
            double FACTOR_DIFICULTAD = 1;
            NombresDatos nombresDatos = pSesion.ObtenerNombres();
            switch (nombresDatos.Dificultad)
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
            double puntaje = ((double)pSesion.RespuestasCorrectas / (double)pSesion.CantidadTotalPreguntas) * FACTOR_DIFICULTAD * FACTOR_TIEMPO;
            return Math.Round(puntaje, 2);
        }

        public override List<Pregunta> ObtenerPreguntas(int pCantidad)
        {
            List<Pregunta> preguntasTotales = new List<Pregunta>();
            try
            {
                if (pCantidad > 50)
                {
                    int aux = pCantidad;
                    while (aux > 0)
                    {
                        preguntasTotales = ObtenerPreguntasLogic(preguntasTotales, pCantidad);
                        aux -= 50;
                    }
                }
                else
                {
                    preguntasTotales = ObtenerPreguntasLogic(preguntasTotales, pCantidad);
                }
            }
            catch (Exception) { }
            foreach (Pregunta pregunta in preguntasTotales)
            {
                pregunta.ConjuntoNombre = Nombre;
                pregunta.ConjuntoId = ConjuntoId;
            }
            return preguntasTotales;
        }

        private List<Pregunta> ObtenerPreguntasLogic(List<Pregunta> pPreguntasActuales, int pCantidad)
        {
            List<Pregunta> preguntasDeLlamada;
            preguntasDeLlamada = JsonMapper.GetPreguntas(Token, pCantidad);
            return pPreguntasActuales.Union(preguntasDeLlamada).ToList();
        }
    }
}
