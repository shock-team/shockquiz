using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.IO
{
    public class LoginDTO
    {
        public int IdUsuario { get; set; }
        public bool EsAdmin { get; set; }
        public int IdSesion { get; set; }
    }
}
