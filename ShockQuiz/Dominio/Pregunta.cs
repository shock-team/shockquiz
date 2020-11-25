
using ShockQuiz.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShockQuiz.Dominio
{
    public class Pregunta
    {/// <summary>
     /// El objetivo de esta clase es al
     /// </summary>
        public int PreguntaId { get; set; }
        public string Nombre { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int DificultadId { get; set; }
        public Dificultad Dificultad { get; set; }
        public int ConjuntoId { get; set; }
        public Conjunto Conjunto { get; set; }
        public string ConjuntoNombre { get; set; }
        public ICollection<Respuesta> Respuestas { get; set; }
        public int SesionActualId { get; set; }

        /// <summary>
        /// Este método se utiliza para comprobar si una respuesta dada a
        /// la pregunta es correcta.
        /// </summary>
        /// <param name="pRespuesta">La respuesta seleccionada</param>
        /// <returns></returns>
        public ResultadoRespuesta Responder(string pRespuesta)
        {
            ResultadoRespuesta resultado = new ResultadoRespuesta();
            foreach (var item in Respuestas.ToList())
            {
                if (item.EsCorrecta == true)
                {
                    resultado.RespuestaCorrecta = item.DefRespuesta;
                    if (item.DefRespuesta == pRespuesta)
                    {
                        resultado.EsCorrecta = true;
                    }
                    else
                    {
                        resultado.EsCorrecta = false;
                    }
                }
            }
            resultado.FinSesion = false;
            return resultado;
        }

        /// <summary>
        /// Este método se utiliza para obtener las posibles respuestas a la pregunta.
        /// </summary>
        /// <returns></returns>
        public List<string> ObtenerRespuestas()
        {
            Random random = new Random();
            string temp;
            List<string> lista = new List<string>();
            foreach (var respuesta in Respuestas.ToList())
            {
                lista.Add(respuesta.DefRespuesta);
            }
            int a;
            int b;
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 0; j < lista.Count - i; j++)
                {
                    a = random.Next();
                    b = random.Next();
                    if (a > b)
                    {
                        temp = lista[j];
                        lista[j] = lista[i];
                        lista[i] = temp;
                    }
                }
            }
            return lista;
        }
    }
}
