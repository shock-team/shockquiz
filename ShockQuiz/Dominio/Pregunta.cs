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
        public ICollection<Sesion> Sesiones { get; set; } = new List<Sesion>();

        public void QuitarDeSesion(int pIdSesion)
        {
            List<Sesion> listaDeSesiones = Sesiones.ToList();
            int indiceSesion = listaDeSesiones.FindIndex(x => x.SesionId == pIdSesion);
            listaDeSesiones.RemoveAt(indiceSesion);
            Sesiones = listaDeSesiones;
        }
    }
}
