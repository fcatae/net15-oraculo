using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StackExchange.Redis;

namespace oraculo
{
    class Oraculo
    {
        ConnectionMultiplexer redis;
        string topic = "Perguntas";
        int n = 0;

        public Oraculo(string connString)
        {
            redis = ConnectionMultiplexer.Connect(connString);
        }

        public string Perguntar(string texto)
        {
            n++;

            var pub = redis.GetSubscriber();

            string pergunta = $"P{n}: {texto}";
            pub.Publish(topic, pergunta);

            return pergunta;
        }

        public Resposta[] LerRespostas()
        {
            var db = redis.GetDatabase();

            string key = $"P{n}";

            var respostas = db.HashGetAll(key)
                .Select(v => new Resposta
                {
                    Equipe = v.Name,
                    Texto = v.Value
                }).ToArray();

            return respostas;
        }
    }
}
