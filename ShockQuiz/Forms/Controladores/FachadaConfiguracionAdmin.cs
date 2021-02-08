using ShockQuiz.DAL.EntityFramework;
using ShockQuiz.DAL.OpenTriviaDB;
using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ShockQuiz.Servicios;

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
            ServiciosUsuario.UsuarioAAdmin(pUsuario);
        }

        /// <summary>
        /// Devuelve los conjuntos presentes en la base de datos de la aplicación
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Conjunto> ObtenerConjuntos()
        {
            return ServiciosConjunto.ObtenerConjuntos();
        }

        /// <summary>
        /// Crea una nueva instancia de ConjuntoOTDB y la guarda en la base de datos
        /// </summary>
        /// <param name="pNombre">Nombre del nuevo ConjuntoOTDB</param>
        /// <param name="pTEPP">Cantidad de sengudos esperada por pregunta</param>
        /// <param name="token">Si el checkbox del Token fue seleccionado o no</param>
        /// <param name="pTipoConjunto">El tipo del conjunto a crear.</param>
        public void AñadirConjunto(string pNombre, int pTEPP, bool token, Type pTipoConjunto)
        {
            ServiciosConjunto.AñadirConjunto(pNombre, pTEPP, token, pTipoConjunto);
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

        public void LimpiarRanking()
        {
            using (var bDbContext = new ShockQuizDbContext())
            {
                using (UnitOfWork bUoW = new UnitOfWork(bDbContext))
                {
                    bDbContext.Set<Sesion>().RemoveRange(bDbContext.Set<Sesion>());
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
            Conjunto conjunto = ServiciosConjunto.ObtenerConjunto(pIdConjunto);
            List<Pregunta> preguntas = conjunto.ObtenerPreguntas(pCantidad);
            ServiciosPregunta.AlmacenarPreguntas(preguntas, pIdConjunto);
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
