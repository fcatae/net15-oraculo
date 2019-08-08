using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;

namespace oraculo
{
    class Oraculo
    {
        ConnectionMultiplexer redis;
        string connString = "localhost";
        string topic = "Perguntas";
        int n = 1;

        public Oraculo()
        {
            redis = ConnectionMultiplexer.Connect(connString);
        }

        public string Perguntar(string texto)
        {
            var pub = redis.GetSubscriber();

            string pergunta = $"P{n++}: {texto}";
            pub.Publish(topic, pergunta);

            return pergunta;
        }
    }
}
