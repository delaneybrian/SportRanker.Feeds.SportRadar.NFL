using Autofac;
using SportRanker.Feeds.SportRadar.NFL.Application;
using SportRanker.Feeds.SportRadar.NFL.Infrastructure;
using SportRanker.Feeds.SportRadar.NFL.Interfaces;

namespace SportRanker.Feeds.SportRadar.NFL.App
{
    public class AppBootstrapper
    {
        public static IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterType<FeedProcessor>()
                .As<IFeedProcessor>();

            builder
                .RegisterType<FeedConsumer>()
                .As<IFeedConsumer>();

            builder
                .RegisterType<Publisher>()
                .As<IPublisher>();

            return builder.Build();
        }
    }
}
