using System;
using System.Threading;

namespace oraculo
{
    class Program
    {
        static string[] lista = {
        "Brasil", "Uruguai", "Japao", "Equador", "Congo"};

        static void Main(string[] args)
        {
            Console.WriteLine("Oraculo");

            string host = (args.Length > 0) ? args[0] : "localhost";

            Console.WriteLine("Conectado a " + host);

            var oracle = new Oraculo(host);

            int tempoEspera = 8000;

            int i = 0;

            while(true)
            {
                string texto = $"Qual a capital do {lista[i % lista.Length]}?";
                i++;

                string pergunta = oracle.Perguntar(texto);
                Console.WriteLine(pergunta);

                Thread.Sleep(tempoEspera);

                var respostas = oracle.LerRespostas();
                foreach(var resp in respostas)
                {
                    Console.WriteLine($"{resp.Equipe}: {resp.Texto}");
                }

                Console.WriteLine();
            }
        }
    }
}
