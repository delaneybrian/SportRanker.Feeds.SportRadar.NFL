using System;
using Autofac;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using SportRanker.Feeds.SportRadar.NFL.Interfaces;

namespace SportRanker.Feeds.SportRadar.NFL.App
{
    public static class NFLResultFinder
    {
        [FunctionName("NFLResultFinder")]
        public static void Run([TimerTrigger("0 0 08 * * 1")]TimerInfo myTimer, TraceWriter log)
        {
            log.Info($"C#" +
               $" Timer trigger function executed at: {DateTime.Now}");

            var container = AppBootstrapper.Bootstrap();

            var feedProcessor = container.Resolve<IFeedProcessor>();

            feedProcessor.StartProcessing().Wait();
        }
    }
}
