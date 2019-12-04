﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.Dominio
{
    public abstract class Conjunto
    {
        public int ConjuntoId { get; set; }
        public string Nombre { get; set; }
        public double tiempoEsperadoPorPregunta { get; set; }
        public virtual ICollection<Sesion> Sesiones { get; set; }
        public virtual ICollection<Pregunta> Preguntas { get; set; }

        public virtual double CalcularPuntaje(Sesion pSesion) { return pSesion.Duracion().TotalSeconds; }
    }
}
