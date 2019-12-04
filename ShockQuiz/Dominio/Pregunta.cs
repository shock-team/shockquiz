
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShockQuiz.IO;

namespace ShockQuiz.Dominio
{
    public class Pregunta
    {/// <summary>
     /// El objetivo de esta clase es al
     /// </summary>
        public int PreguntaId { get; set; }
        public string Nombre { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public int DificultadId { get; set; }
        public virtual Dificultad Dificultad { get; set; }
        public int ConjuntoId { get; set; }
        public virtual Conjunto Conjunto { get; set; }
        public virtual ICollection<Respuesta> Respuestas { get; set; }
       
        public ResultadoRespuesta Responder(string pRespuesta)
        {
            //Este método se encarga de comprobar si la respuesta ingresada es correcta, devolviendo
            //true si es así y false en caso contrario.
            ResultadoRespuesta resultado = new ResultadoRespuesta();
            foreach (var item in Respuestas)
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

        public PreguntaDTO ObtenerPreguntaYRespuestas()
        {
            //Este método se encarga de devolver las respuestas asociadas a la pregunta,
            //ordenadas aleatoriamente.
            Random random = new Random();
            string temp;
            List<string> lista = new List<string>();
            foreach (Respuesta respuesta in Respuestas)
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
            PreguntaDTO pregunta = new PreguntaDTO();
            pregunta.Pregunta = Nombre;
            pregunta.Respuestas = lista;
            return pregunta;
        }
    }
}
