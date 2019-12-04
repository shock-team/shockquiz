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
        [TestMethod]
        public void TestMethod1()
        {
            JsonMapper.Mapper(15);
        }

        //[TestMethod]
        public void TestMethodOwO()
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Conjunto otdb = new ConjuntoOTDB()
                    {
                        Nombre = "OpenTDB",
                        tiempoEsperadoPorPregunta = 40
                    };
                    bUoW.RepositorioConjunto.Agregar(otdb);
                    bUoW.GuardarCambios();
                }
            }
        }

        //[TestMethod]
       /* public void TestMethod2()
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Pregunta pregunta = new Pregunta()
                    {
                        Nombre = "Pregunta?",
                        Categoria = bUoW.RepositorioCategoria.GetOrCreateConjunto("Categoria 2"),
                        Dificultad = new Dificultad()
                        {
                            Nombre = "Dificultad"
                        },
                        Conjunto = new Conjunto()
                        {
                            Nombre = "OpenAss"
                        },
                        Respuestas = new List<Respuesta>()
                        {
                            new Respuesta()
                            {
                                DefRespuesta= "Correcta",
                                EsCorrecta=true
                            },
                            new Respuesta()
                            {
                                DefRespuesta= "Incorrecta1",
                                EsCorrecta=false
                            },
                            new Respuesta()
                            {
                                DefRespuesta= "Incorrecta2",
                                EsCorrecta=false
                            }
                        }
                    };
                    bUoW.RepositorioPregunta.Agregar(pregunta);
                    bUoW.GuardarCambios();
                }
            }
        }

        //[TestMethod]
        public void TestMethod3()
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Pregunta pregunta = new Pregunta()
                    {
                        Nombre = "Pregunta?",
                        Categoria = bUoW.RepositorioCategoria.GetOrCreateConjunto("Categoria 3"),
                        Dificultad = bUoW.RepositorioDificultad.GetOrCreateDificultad("Dificultad owo"),
                        Conjunto = new Conjunto()
                        {
                            Nombre = "OpenAss"
                        },
                        Respuestas = new List<Respuesta>()
                        {
                            new Respuesta()
                            {
                                DefRespuesta= "Correcta",
                                EsCorrecta=true
                            },
                            new Respuesta()
                            {
                                DefRespuesta= "Incorrecta1",
                                EsCorrecta=false
                            },
                            new Respuesta()
                            {
                                DefRespuesta= "Incorrecta2",
                                EsCorrecta=false
                            }
                        }
                    };
                    bUoW.RepositorioPregunta.Agregar(pregunta);

                    Pregunta pregunta2 = new Pregunta()
                    {
                        Nombre = "Pregunta re loca?",
                        Categoria = bUoW.RepositorioCategoria.GetOrCreateConjunto("Categoria 3"),
                        Dificultad = new Dificultad()
                        {
                            Nombre = "Dificultad"
                        },
                        Conjunto = new Conjunto()
                        {
                            Nombre = "OpenAss"
                        },
                        Respuestas = new List<Respuesta>()
                        {
                            new Respuesta()
                            {
                                DefRespuesta= "Correcta",
                                EsCorrecta=true
                            },
                            new Respuesta()
                            {
                                DefRespuesta= "Incorrecta1",
                                EsCorrecta=false
                            },
                            new Respuesta()
                            {
                                DefRespuesta= "Incorrecta2",
                                EsCorrecta=false
                            }
                        }
                    };
                    bUoW.RepositorioPregunta.Agregar(pregunta2);

                    bUoW.GuardarCambios();
                }
            }

        }*/
    }
}
