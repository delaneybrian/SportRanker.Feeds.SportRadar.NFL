using System.Threading.Tasks;
using Optional;
using SportRanker.Contracts.SystemEvents;
using SportRanker.Feeds.SportRadar.NFL.Definitions;

namespace SportRanker.Feeds.SportRadar.NFL.Interfaces
{
    public interface IFixtureResultDeriver
    {
        Task<Option<FixtureResult>> TryGenerateFixtureResult(FeedFixture feedFixture);
    }
}
