using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShockQuiz;
using ShockQuiz.Dominio;

namespace unitTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            Categoria cat = new Categoria()
            {
                Nombre = "Categoria"
            };

            Dificultad dif = new Dificultad()
            {
                Nombre = "Dificultad"
            };

            Conjunto con = new ConjuntoOTDB()
            {
                Nombre = "OpenTDB",
                tiempoEsperadoPorPregunta = 40
            };




            SesionForm form = new SesionForm("asd", cat, dif, con, 1);
            form.Show();
            
        }
    }
}
