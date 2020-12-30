using ShockQuiz.DAL.OpenTriviaDB;
using ShockQuiz.Forms;
using ShockQuiz.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShockQuiz.IO;

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

        public async override Task AgregarPreguntasAsync(int pCantidad, 
            IProgress<ProgressReportModel> progress, 
            Action<List<Pregunta>, IProgress<ProgressReportModel>, int, int> almacenarPreguntas, 
            string pToken = null)
        {
            int numCalls = 0;
            if (pCantidad > 50)
            {
                int aux = pCantidad;
                while (aux > 0)
                {
                    await AgregarPreguntasLogic(aux, progress, almacenarPreguntas, numCalls, pToken);
                    aux -= 50;
                    numCalls++;
                }
            }
            else
            {
                await AgregarPreguntasLogic(pCantidad, progress, almacenarPreguntas, numCalls, pToken);
            }
        }

        private async Task AgregarPreguntasLogic(int pCantidad, 
            IProgress<ProgressReportModel> progress,
            Action<List<Pregunta>, IProgress<ProgressReportModel>, int, int> almacenarPreguntas, 
            int pNumCalls, 
            string pToken = null)
        {
            List<Pregunta> preguntas = new List<Pregunta>();

            preguntas = await Task.Run(() => JsonMapper.GetPreguntas(pToken, pCantidad));

            await Task.Run(() => almacenarPreguntas(preguntas, progress, pCantidad, pNumCalls));
        }
    }
}
