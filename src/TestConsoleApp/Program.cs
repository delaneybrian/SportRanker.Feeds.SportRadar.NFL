using Autofac;
using SportRanker.Feeds.SportRadar.NFL.Interfaces;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = AppBootstrapper.Bootstrap();

            var feedProcessor = container.Resolve<IFeedProcessor>();

            feedProcessor.ProcessHistoricalFixtures(7).Wait();
        }
    }
}
