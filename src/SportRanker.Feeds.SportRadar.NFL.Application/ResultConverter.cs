using SportRanker.Feeds.SportRadar.NFL.Contracts;
using SportRanker.Feeds.SportRadar.NFL.Definitions;

namespace SportRanker.Feeds.SportRadar.NFL.Application
{
    public static class ResultConverter
    {
        public static FixtureResult ConvertFromFeedFixtureResult(FeedFixture feedFixture)
        {
            return new FixtureResult()
            {
                SportId = SportId.NFL,
                FeedSource = FeedSource.SportRadar,
                HomeTeamId = feedFixture.HomeTeamId,
                HomeTeamName = feedFixture.HomeTeamName,
                HomeTeamScore = feedFixture.HomeTeamScore,
                AwayTeamId = feedFixture.AwayTeamId,
                AwayTeamName = feedFixture.AwayTeamName,
                AwayTeamScore = feedFixture.AwayTeamScore,
                KickOffTimeUtc = feedFixture.KickOffTimeUtc
            };
        }
    }
}
