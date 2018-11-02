using SportRanker.Feeds.SportRadar.NFL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SportRanker.Feeds.SportRadar.NFL.Application
{
    public class FeedProcessor : IFeedProcessor
    {
        public readonly IFeedConsumer _feedConsumer;
        public readonly IPublisher _publisher;

        public FeedProcessor(IFeedConsumer feedConsumer)
        {
            _feedConsumer = feedConsumer;
        }

        public Task StartProcessing()
        {
            while (true)
            {
                _feedConsumer.GetFixtureResultsForYesterday();

                Thread.Sleep(5000000);
            }
        }
    }
}
