using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tets
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string temp;
            List<string> lista = new List<string>
            {
                "aa", "ab", "ac", "ba", "bb", "bc", "ca", "cb", "cc"
            };
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 0; j < lista.Count - i; j++)
                {
                    int a = random.Next();
                    int b = random.Next();
                    if (a > b)
                    {
                        temp = lista[j];
                        lista[j] = lista[i];
                        lista[i] = temp;
                    }
                }
            }
            foreach (string item in lista)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
