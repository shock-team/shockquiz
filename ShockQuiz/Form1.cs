using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;


namespace ShockQuiz
{
    public partial class Form1 : Form
    {

        public void JSON()
        {

            // Url de ejemplo
            var mUrl = "https://opentdb.com/api.php?amount=5&category=31&type=multiple";

            // Se crea el request http
            HttpWebRequest mRequest = (HttpWebRequest)WebRequest.Create(mUrl);

            try
            {
                // Se ejecuta la consulta
                WebResponse mResponse = mRequest.GetResponse();

                // Se obtiene los datos de respuesta
                using (Stream responseStream = mResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);

                    // Se parsea la respuesta y se serializa a JSON a un objeto dynamic
                    dynamic mResponseJSON = JsonConvert.DeserializeObject(reader.ReadToEnd());

                    //MessageBox.Show("Código de respuesta: "+ mResponseJSON.response_code);
                    Random rand = new Random();
                    // Se iteran cada uno de los resultados.
                    foreach (var bResponseItem in mResponseJSON.results)
                    {
                        // De esta manera se accede a los componentes de cada item
                        // Se decodifican algunos elementos HTML
                        MessageBox.Show(HttpUtility.HtmlDecode(bResponseItem.question.ToString()));

                        String[] res = new String[4];
                        for (int w = 0; w < 3; w++)
                        {
                            res[w] = HttpUtility.HtmlDecode(bResponseItem.incorrect_answers[w].ToString());
                        }
                        res[3] = HttpUtility.HtmlDecode(bResponseItem.correct_answer.ToString());

                        int a = rand.Next(0, 3);
                        List<byte> indices = new List<byte>();
                        for (byte i = 0; i < 3; i++)
                        {
                            indices.Add(i);
                        }
                        int j = indices.Count;
                        while (j>0  )
                        {
                            int x=indices[j];



                        }
                        MessageBox.Show("Respuestas: " +resShow[0]+", "+ resShow[1]+", "+ resShow[2]+", "+ resShow[3] +".");

                        //MessageBox.Show(HttpUtility.HtmlDecode(bResponseItem.incorrect_answers[0].ToString()));
                        MessageBox.Show("Respuesta correcta: " + HttpUtility.HtmlDecode(bResponseItem.correct_answer.ToString()));
                        // Se muestra por pantalla cada item completo
                        //MessageBox.Show("Item completo -> "+ bResponseItem);

                    }
                }
            }
            catch (WebException ex)
            {
                WebResponse mErrorResponse = ex.Response;
                using (Stream mResponseStream = mErrorResponse.GetResponseStream())
                {
                    StreamReader mReader = new StreamReader(mResponseStream, Encoding.GetEncoding("utf-8"));
                    String mErrorText = mReader.ReadToEnd();

                    MessageBox.Show("Error: " + mErrorText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ ex.Message);
            }

            
        }
        public Form1()
        {
            InitializeComponent();
            JSON();
           
        }
    }
}
