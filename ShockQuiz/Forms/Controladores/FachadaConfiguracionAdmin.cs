using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.DAL.OpenTriviaDB;
using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ShockQuiz.Forms
{
    public class FachadaConfiguracionAdmin
    {
        /// <summary>
        /// Incrementa la autoridad de un usuario a administrador
        /// </summary>
        /// <param name="pUsuario">El usuario</param>
        /// <returns></returns>
        public void UsuarioAAdmin(string pUsuario)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    bUoW.RepositorioUsuario.Ascender(pUsuario);
                    bUoW.GuardarCambios();
                }
            }
        }

        /// <summary>
        /// Devuelve los conjuntos presentes en la base de datos de la aplicación
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Conjunto> ObtenerConjuntos()
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    return bUoW.RepositorioConjunto.ObtenerTodas();
                }
            }
        }

        /// <summary>
        /// Crea una nueva instancia de ConjuntoOTDB y la guarda en la base de datos
        /// </summary>
        /// <param name="pNombre">Nombre del nuevo ConjuntoOTDB</param>
        /// <param name="pTEPP">Cantidad de sengudos esperada por pregunta</param>
        /// <param name="token">Si el checkbox del Token fue seleccionado o no</param>
        public void AñadirConjunto(string pNombre, int pTEPP, bool token, Type pTipoConjunto)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    string tokenString = null;
                    if (token)
                    {
                        tokenString = JsonMapper.ObtenerToken();
                    }
                    Conjunto conjunto = (Conjunto)Activator.CreateInstance(pTipoConjunto);
                    conjunto.Nombre = pNombre;
                    conjunto.TiempoEsperadoPorPregunta = pTEPP;
                    conjunto.Token = tokenString;

                    bUoW.RepositorioConjunto.Agregar(conjunto);
                    bUoW.GuardarCambios();
                }
            }
        }

        /// <summary>
        /// Este método se utiliza para eliminar los datos almacenados actualmente
        /// en la base de datos.
        /// </summary>
        public void LimpiarDB()
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    bDbContext.Set<Respuesta>().RemoveRange(bDbContext.Set<Respuesta>());
                    bUoW.GuardarCambios();
                    bDbContext.Set<Pregunta>().RemoveRange(bDbContext.Set<Pregunta>());
                    bUoW.GuardarCambios();
                    bDbContext.Set<Sesion>().RemoveRange(bDbContext.Set<Sesion>());
                    bUoW.GuardarCambios();
                    bDbContext.Set<Usuario>().RemoveRange(bDbContext.Set<Usuario>());
                    bUoW.GuardarCambios();
                    bDbContext.Set<Categoria>().RemoveRange(bDbContext.Set<Categoria>());
                    bUoW.GuardarCambios();
                    bDbContext.Set<Conjunto>().RemoveRange(bDbContext.Set<Conjunto>());
                    bUoW.GuardarCambios();
                    bDbContext.Set<Dificultad>().RemoveRange(bDbContext.Set<Dificultad>());
                    bUoW.GuardarCambios();
                }
            }
        }

        /// <summary>
        /// Este método se utiliza para almacenar una lista de preguntas obtenida a partir de un conjunto.
        /// </summary>
        /// <param name="pIdConjunto">El ID del conjunto cuyas preguntas se obtienen.</param>
        /// <param name="pCantidad">La cantidad de preguntas.</param>
        public void AlmacenarPreguntas(int pIdConjunto, int pCantidad)
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    Conjunto conjunto = bUoW.RepositorioConjunto.Obtener(pIdConjunto);
                    List<Pregunta> preguntas = conjunto.ObtenerPreguntas(pCantidad);
                    foreach (Pregunta pregunta in preguntas)
                    {
                        pregunta.Conjunto = conjunto;
                        pregunta.ConjuntoNombre = conjunto.Nombre;

                        string descripcion = pregunta.Nombre;
                        pregunta.Nombre = bUoW.RepositorioPregunta.GetOrCreate(descripcion, conjunto.Nombre);

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
        /// Este método se utiliza para obtener una lista con todos los tipos presentes en la carpeta
        /// ShockQuiz.Dominio.Conjuntos.
        /// </summary>
        /// <returns></returns>
        public List<Type> ObtenerTiposDeConjunto()
        {
            string nameSpace = "ShockQuiz.Dominio.Conjuntos";
            var tipos = from t in Assembly.GetExecutingAssembly().GetTypes()
                        where t.IsClass && t.Namespace == nameSpace
                              && t.IsSubclassOf(typeof(Conjunto))
                        select t;
            return tipos.ToList();
        }
    }
}
