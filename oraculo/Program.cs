using System;
using System.Threading;

namespace oraculo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Oraculo");

            string host = (args.Length > 0) ? args[0] : "localhost";

            Console.WriteLine("Conectado a " + host);

            var oracle = new Oraculo(host);

            int tempoEspera = 15000;
            string texto = "Qual a capital do Brasil?";

            while(true)
            {
                string pergunta = oracle.Perguntar(texto);
                Console.WriteLine(pergunta);

                Thread.Sleep(tempoEspera);
                Console.WriteLine();
            }
        }
    }
}
