
using Newtonsoft.Json;
using ShockQuiz.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShockQuiz.Dominio
{
    public class Pregunta
    {
        public int PreguntaId { get; set; }
        public string Nombre { get; set; }
        public int CategoriaId { get; set; }
        [JsonIgnore]
        public Categoria Categoria { get; set; }
        public int DificultadId { get; set; }
        [JsonIgnore]
        public Dificultad Dificultad { get; set; }
        public int ConjuntoId { get; set; }
        [JsonIgnore]
        public Conjunto Conjunto { get; set; }
        public ICollection<Respuesta> Respuestas { get; set; }

        public ResultadoRespuesta Responder(string pRespuesta)
        {
            //Este método se encarga de comprobar si la respuesta ingresada es correcta, devolviendo
            //true si es así y false en caso contrario.
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

        public List<string> ObtenerRespuestas()
        {
            //Este método se encarga de devolver las respuestas asociadas a la pregunta,
            //ordenadas aleatoriamente.
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
