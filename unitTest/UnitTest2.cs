using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShockQuiz;
using ShockQuiz.DAL.OpenTriviaDB;
using ShockQuiz.Dominio;

namespace unitTest
{
    [TestClass]
    public class UnitTest2
    {
        //[TestMethod]
        public void TestMethod1()
        {
            MessageBox.Show(JsonMapper.ObtenerToken());
        }
    }
}
