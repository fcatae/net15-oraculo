using System;
using StackExchange.Redis;
using System.Threading;

namespace oraculo
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = "localhost";
            string topic = "Perguntas";

            Console.WriteLine("Oraculo");

            var redis = ConnectionMultiplexer.Connect(connString);

            var pub = redis.GetSubscriber();

            int n = 1;
            string texto = "Qual a capital do Brasil?";

            while(true)
            {
                string pergunta = $"P{n}: {texto}";
                pub.Publish(topic, pergunta);
                Console.WriteLine(pergunta);

                Thread.Sleep(5000);
                Console.WriteLine();
            }
        }
    }
}
