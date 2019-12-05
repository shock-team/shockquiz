using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.DAL.OpenTriviaDB;
using ShockQuiz.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace unitTest
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        public void TestMethod1()
        {
            JsonMapper.Mapper(60);
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
        public void TestMethod2()
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Pregunta pregunta = new Pregunta()
                    {
                        Nombre = "Pregunta?",
                        Categoria = bUoW.RepositorioCategoria.GetOrCreate("Categoria 2"),
                        Dificultad = bUoW.RepositorioDificultad.GetOrCreate("Dificultad"),
                        Conjunto = bUoW.RepositorioConjunto.Get("OpenTDB"),
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
                        Nombre = bUoW.RepositorioPregunta.GetOrCreate("Pregunta??", "OpenTDB2"),
                        Categoria = bUoW.RepositorioCategoria.GetOrCreate("Categoria 2"),
                        Dificultad = bUoW.RepositorioDificultad.GetOrCreate("Dificultad"),
                        Conjunto = bUoW.RepositorioConjunto.Get("OpenTDB2"),
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
                    if (pregunta.Nombre != string.Empty)
                    {
                        bUoW.RepositorioPregunta.Agregar(pregunta);
                    }

                    Pregunta pregunta2 = new Pregunta()
                    {
                        Nombre = bUoW.RepositorioPregunta.GetOrCreate("Pregunta??","OpenTDB2"),
                        Categoria = bUoW.RepositorioCategoria.GetOrCreate("Categoria"),
                        Dificultad = bUoW.RepositorioDificultad.GetOrCreate("Dificultad"),
                        Conjunto = bUoW.RepositorioConjunto.Get("OpenTDB2"),
                        Respuestas = new List<Respuesta>()
                        {
                            new Respuesta()
                            {
                                DefRespuesta= "Correcta  2",
                                EsCorrecta=true
                            },
                            new Respuesta()
                            {
                                DefRespuesta= "Incorrecta1  2",
                                EsCorrecta=false
                            },
                            new Respuesta()
                            {
                                DefRespuesta= "Incorrecta2  2",
                                EsCorrecta=false
                            }
                        }
                    };
                    if (pregunta2.Nombre != string.Empty)
                    {
                        bUoW.RepositorioPregunta.Agregar(pregunta2);
                    }

                    bUoW.GuardarCambios();
                }
            }
        }

        //[TestMethod]
        public void TestMethod4()
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    bUoW.RepositorioConjunto.ObtenerTodas();
                }
            }
        }

        [TestMethod]
        public void TestMethod5()
        {
                List<Categoria> listaCategorias = new List<Categoria>();
                List<Pregunta> listaPreguntas = new List<Pregunta>();
            using (var bDbContext = new ShockQuizDbContext())
            {
                listaPreguntas = (from t in bDbContext.Preguntas where t.Conjunto.Nombre == "OpenTDB" select t).ToList();
                foreach (Pregunta pregunta in listaPreguntas)
                {
                    if (!listaCategorias.Contains(pregunta.Categoria))
                    {
                        listaCategorias.Add(pregunta.Categoria);
                    }
                }
            }
                
            Assert.AreEqual(0,listaCategorias.Count);
        }
    }
}
