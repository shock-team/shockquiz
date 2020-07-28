using Newtonsoft.Json;
using ShockQuiz.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShockQuiz.DAL
{
    public class RepositorioSesionActiva
    {
        static string fileName = "sesiondata.txt";
        public static void GuardarSesionActiva(Sesion pSesion)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.TypeNameHandling = TypeNameHandling.Auto;
            serializer.Formatting = Formatting.Indented;

            using (StreamWriter sw = new StreamWriter(fileName))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, pSesion, typeof(Sesion));
            }
        }

        public static Sesion TraerSesionActiva()
        {
            string sesionJson = File.ReadAllText(fileName);
            Sesion oldSesion = JsonConvert.DeserializeObject<Sesion>(sesionJson, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
        });
            return oldSesion;
        }

        public static int TiempoRestante()
        {
            string sesionJson = File.ReadAllText(fileName);
            Sesion oldSesion = JsonConvert.DeserializeObject<Sesion>(sesionJson, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
            });
            return oldSesion.TiempoRestante;
        }

        public static bool ExisteSesionActiva()
        {
            if (File.Exists(fileName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void EliminarSesionActiva()
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }
    }
}
