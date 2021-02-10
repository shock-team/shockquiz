using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShockQuiz.Dominio;
using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.IO;

namespace ShockQuiz.Servicios
{
    public class ServiciosPregunta
    {
        /// <summary>
        /// Éste método se utiliza para persistir una lista de preguntas en la base de datos.
        /// </summary>
        /// <param name="pListaDePreguntas">La lista de preguntas a persistir.</param>
        public static void AlmacenarPreguntas(List<Pregunta> pListaDePreguntas, int pConjunto)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Conjunto conjunto = bUoW.RepositorioConjunto.Obtener(pConjunto);
                    foreach (Pregunta pregunta in pListaDePreguntas)
                    {
                        pregunta.Conjunto = conjunto;

                        string descripcion = pregunta.Nombre;
                        pregunta.Nombre = bUoW.RepositorioPregunta.GetOrCreate(descripcion, pregunta.ConjuntoNombre);

                        string categoria = pregunta.Categoria.Nombre;
                        pregunta.Categoria = bUoW.RepositorioCategoria.GetOrCreate(categoria);

                        string dificultad = pregunta.Dificultad.Nombre;
                        pregunta.Dificultad = bUoW.RepositorioDificultad.GetOrCreate(dificultad);

                        if (pregunta.Nombre != string.Empty)
                        {
                            bUoW.RepositorioPregunta.Agregar(pregunta);
                        }
                    }
                    bUoW.GuardarCambios();
                }
            }
        }

        /// <summary>
        /// Este método se utiliza para obtener una pregunta presente en la base de datos
        /// a partir de su ID.
        /// </summary>
        /// <param name="pIdPregunta">El ID de la pregunta a obtener.</param>
        /// <returns></returns>
        public static Pregunta ObtenerPregunta(int pIdPregunta)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    return bUoW.RepositorioPregunta.ObtenerPreguntaPorId(pIdPregunta);
                }
            }
        }

        /// <summary>
        /// Este método se utiliza para obtener el resultado a la hora de responder una pregunta presente
        /// en la base de datos.
        /// </summary>
        /// <param name="pIdPregunta">El ID de la pregunta a responder.</param>
        /// <param name="pIdRespuesta">El ID de la respuesta seleccionada por el usuario.</param>
        /// <returns></returns>
        public static ResultadoRespuesta Responder(int pIdPregunta, int pIdRespuesta)
        {
            ResultadoRespuesta resultado = new ResultadoRespuesta();
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Respuesta respuestaCorrecta = bUoW.RepositorioPregunta.ObtenerRespuestaCorrecta(pIdPregunta);
                    resultado.EsCorrecta = (respuestaCorrecta.RespuestaId == pIdRespuesta);
                    resultado.RespuestaCorrecta = respuestaCorrecta.DefRespuesta;
                    return resultado;
                }
            }
        }
    }
}
