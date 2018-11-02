using SportRanker.Feeds.SportRadar.NFL.Interfaces;
using System;
using System.Threading.Tasks;
using Autofac;

namespace SportRanker.Feeds.SportRadar.NFL.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = AppBootstrapper.Bootstrap();

            var feedProcessor = container.Resolve<IFeedProcessor>();

            Task.Run(() => feedProcessor.StartProcessing());

            Console.ReadKey();
        }
    }
}
