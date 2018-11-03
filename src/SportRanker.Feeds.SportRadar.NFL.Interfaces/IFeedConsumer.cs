using SportRanker.Feeds.SportRadar.NFL.Definitions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportRanker.Feeds.SportRadar.NFL.Interfaces
{
    public interface IFeedConsumer
    {
        Task<ICollection<FeedFixture>> GetFixtureResultsForYesterdayAsync();
    }
}
