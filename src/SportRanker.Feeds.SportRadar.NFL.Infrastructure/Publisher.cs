﻿using System;
using RabbitMQ.Client;
using Newtonsoft.Json;
using System.Text;
using SportRanker.Contracts.SystemEvents;
using SportRanker.Feeds.SportRadar.NFL.Interfaces;
using System.Threading;

namespace SportRanker.Feeds.SportRadar.NFL.Infrastructure
{
    public class Publisher : IPublisher
    {
        private const string NewFixtureExchange = "new_fixture_exchange";

        private const string NewNFLFixtureRoutingKey = "results.nfl";

        public void PublishFixtureResult(FixtureResult fixtureResult)
        {
            Uri ampqUri = new Uri(@"amqps://lhqadfns:Ox1Z9RVKMsu36ZjbLV0HEzknWsgJi36S@raven.rmq.cloudamqp.com/lhqadfns");

            var factory = new ConnectionFactory()
            {
                Uri = ampqUri
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(
                    exchange: NewFixtureExchange,
                    type: "topic");

                var message = JsonConvert.SerializeObject(fixtureResult);

                var body = Encoding.UTF8.GetBytes(message);

                try
                {
                    channel.BasicPublish(exchange: NewFixtureExchange,
                        routingKey: NewNFLFixtureRoutingKey,
                        basicProperties: null,
                        body: body);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could Not Publish To Queue");
                }

                Thread.Sleep(100);
            }
        }
    }
}
