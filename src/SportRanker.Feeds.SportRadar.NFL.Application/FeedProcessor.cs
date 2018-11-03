using SportRanker.Feeds.SportRadar.NFL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace SportRanker.Feeds.SportRadar.NFL.Application
{
    public class FeedProcessor : IFeedProcessor
    {
        public readonly IFeedConsumer _feedConsumer;
        public readonly IPublisher _publisher;

        private Timer _feedRetrivalTimer;
        private int OneDayInterval = 1000 * 60 * 60 * 24;

        public FeedProcessor(IFeedConsumer feedConsumer,
            IPublisher publisher)
        {
            _feedConsumer = feedConsumer;
            _publisher = publisher;

            _feedRetrivalTimer = new Timer();
            _feedRetrivalTimer.Elapsed += OnTimerElapsed;
            _feedRetrivalTimer.Interval = OneDayInterval;
        }

        public async Task StartProcessing()
        {
            _feedRetrivalTimer.Start();
            OnTimerElapsed(this, null);
        }

        public void OnTimerElapsed(object sender, EventArgs e)
        {
            Task.Run(async () => 
            {
                var feedResults = await _feedConsumer.GetFixtureResultsForYesterdayAsync();

                foreach (var feedResult in feedResults)
                {
                    var fixtureResult = ResultConverter.ConvertFromFeedFixtureResult(feedResult);

                    _publisher.PublishNFLFixtureResult(fixtureResult);
                }
            });           
        }
    }
}
