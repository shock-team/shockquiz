using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.DAL.OpenTriviaDB;
using ShockQuiz.Dominio;
using System.Collections.Generic;

namespace unitTest
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        public void TestMethod1()
        {

            List<Pregunta> listaPreguntas = JsonMapper.Mapper(1);
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    foreach (Pregunta item in listaPreguntas)
                    {
                        bUoW.RepositorioPregunta.Agregar(item);
                        bUoW.GuardarCambios();
                    }
                }
            }

        }
        [TestMethod]
        public void TestMethod2()
        {
            Pregunta pregunta = new Pregunta()
            {
                Nombre = "Preguntaaaa?",
                Categoria = new Categoria()
                {
                    Nombre = "Categoria"
                },
                Dificultad = new Dificultad()
                {
                    Nombre = "Dificultad"
                },
                Conjunto = new Conjunto()
                {
                    Nombre = "OpenAss"
                },
                RespuestaCorrecta = new Respuesta()
                {

                    DefRespuesta = "Correcta"
                },
                RespuestasIncorrectas = new List<Respuesta>()
                {
                    new Respuesta()
                    {
                        DefRespuesta= "Incorrecta1"
                    },
                    new Respuesta()
                    {
                        DefRespuesta= "Incorrecta2"
                    }
                }



            };

            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    bUoW.RepositorioPregunta.Agregar(pregunta);
                    bUoW.GuardarCambios();
                }
            }
        }
    }
}
