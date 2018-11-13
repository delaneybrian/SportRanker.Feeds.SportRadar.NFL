using SportRanker.Contracts.SystemEvents;

namespace SportRanker.Feeds.SportRadar.NFL.Interfaces
{
    public interface IPublisher
    {
        void PublishFixtureResult(FixtureResult fixtureResult);
    }
}
