using System.Threading.Tasks;
using Optional;
using SportRanker.Contracts.Dto;

namespace SportRanker.Feeds.SportRadar.NFL.Interfaces
{
    public interface IDataProvider
    {
        Task<Option<Team>> GetTeamByProviderIdAsync(SourceId provider, string providerId);
        Task<Option<Fixture>> GetFixtureByProviderIdAsync(SourceId provider, string providerId);
    }
}
