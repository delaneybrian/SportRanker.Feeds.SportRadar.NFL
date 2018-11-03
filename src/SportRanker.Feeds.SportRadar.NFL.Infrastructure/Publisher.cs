using SportRanker.Feeds.SportRadar.NFL.Interfaces;
using RabbitMQ.Client;
using Newtonsoft.Json;
using SportRanker.Feeds.SportRadar.NFL.Contracts;
using System.Text;

namespace SportRanker.Feeds.SportRadar.NFL.Infrastructure
{
    public class Publisher : IPublisher
    {
        private const string NewFixtureExchange = "new_fixture_exchange";

        private const string NewNFLFixtureRoutingKey = "results.nfl";

        public void PublishNFLFixtureResult(FixtureResult fixtureResult)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(
                    exchange: NewFixtureExchange,
                    type: "topic");

                var message = JsonConvert.SerializeObject(fixtureResult);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: NewFixtureExchange,
                                 routingKey: NewNFLFixtureRoutingKey,
                                 basicProperties: null,
                                 body: body);
            }
        }
    }
}
