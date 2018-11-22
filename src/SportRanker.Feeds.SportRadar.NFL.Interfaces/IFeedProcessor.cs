using System.Threading.Tasks;

namespace SportRanker.Feeds.SportRadar.NFL.Interfaces
{
    public interface IFeedProcessor
    {
        Task StartProcessing();
        Task ProcessHistoricalFixtures(int days);
    }
}
