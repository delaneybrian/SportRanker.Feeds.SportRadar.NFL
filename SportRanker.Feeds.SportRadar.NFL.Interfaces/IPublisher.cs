using SportRanker.Feeds.SportRadar.NFL.Contracts;

namespace SportRanker.Feeds.SportRadar.NFL.Interfaces
{
    public interface IPublisher
    {
        void PublishNFLFixtureResult(FixtureResult fixtureResult);
    }
}
