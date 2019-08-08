using System;
using System.Threading;

namespace oraculo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Oraculo");

            var oracle = new Oraculo();

            int tempoEspera = 5000;
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
