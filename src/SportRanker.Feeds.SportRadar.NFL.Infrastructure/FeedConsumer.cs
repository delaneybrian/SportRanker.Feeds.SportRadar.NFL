using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SportRanker.Feeds.SportRadar.NFL.Definitions;
using SportRanker.Feeds.SportRadar.NFL.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SportRanker.Contracts.Dto;

namespace SportRanker.Feeds.SportRadar.NFL.Infrastructure
{
    public class FeedConsumer : IFeedConsumer
    {
        private readonly HttpClient _httpClient;

        private readonly string ApiKey = "9btpg2fmxpfj7j28t5yf8rwj";

        private readonly int DaysInYear = 365;

        public FeedConsumer()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ICollection<FeedFixture>> GetFixtureResultsForYesterdayAsync()
        {
            ICollection<FeedFixture> feedFixtures = new List<FeedFixture>();

            var currentYear = DateTime.UtcNow.Year;

            var url = $"https://api.sportradar.us/nfl/official/trial/v5/en/games/{currentYear}/REG/schedule.json?api_key={ApiKey}";

            var result = await _httpClient.GetAsync(url);

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();

                DefaultContractResolver contractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                };

                var feedSchedule = JsonConvert.DeserializeObject<FeedSchedule>(content, new JsonSerializerSettings
                {
                    ContractResolver = contractResolver,
                    Formatting = Formatting.Indented
                });

                foreach (var week in feedSchedule.Weeks)
                {
                    foreach (var game in week.Games)
                    {
                        if (game.Status == "closed" &&
                            game.Scheduled.Date == DateTime.UtcNow.Date.AddDays(-1))
                        {
                            feedFixtures.Add(
                                new FeedFixture()
                                {
                                    FeedSource = SourceId.SportRadar,
                                    ProviderFixtureId = game.Id,
                                    KickOffTimeUtc = game.Scheduled,
                                    HomeTeamId = game.Home.Id,
                                    HomeTeamName = game.Home.Name,
                                    HomeTeamScore = game.Scoring.HomePoints,
                                    AwayTeamId = game.Away.Id,
                                    AwayTeamName = game.Away.Name,
                                    AwayTeamScore = game.Scoring.AwayPoints
                                });
                        }
                    }
                }
            }

            return feedFixtures;
        }

        public async Task<ICollection<FeedFixture>> GetFixtureResultsForPreviousDaysAsync(int numDays)
        {
            ICollection<FeedFixture> feedFixtures = new List<FeedFixture>();

            var years = new List<int>()
            {
                DateTime.UtcNow.Year,
                DateTime.UtcNow.Year - 1
            };

            foreach (var year in years)
            {
                var url = $"https://api.sportradar.us/nfl/official/trial/v5/en/games/{year}/REG/schedule.json?api_key={ApiKey}";

                var result = await _httpClient.GetAsync(url);

                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();

                    DefaultContractResolver contractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    };

                    var feedSchedule = JsonConvert.DeserializeObject<FeedSchedule>(content, new JsonSerializerSettings
                    {
                        ContractResolver = contractResolver,
                        Formatting = Formatting.Indented
                    });

                    foreach (var week in feedSchedule.Weeks)
                    {
                        foreach (var game in week.Games)
                        {
                            if (game.Status == "closed" &&
                                game.Scheduled.Date == DateTime.UtcNow.Date.AddDays(-1))
                            {
                                var feedFixture =
                                    new FeedFixture()
                                    {
                                        FeedSource = SourceId.SportRadar,
                                        ProviderFixtureId = game.Id,
                                        KickOffTimeUtc = game.Scheduled,
                                        HomeTeamId = game.Home.Id,
                                        HomeTeamName = game.Home.Name,
                                        HomeTeamScore = game.Scoring.HomePoints,
                                        AwayTeamId = game.Away.Id,
                                        AwayTeamName = game.Away.Name,
                                        AwayTeamScore = game.Scoring.AwayPoints
                                    };

                                var daysInPast = (DateTime.UtcNow - feedFixture.KickOffTimeUtc).Days;

                                if (daysInPast < numDays && daysInPast > 0)
                                    feedFixtures.Add(feedFixture);
                            }
                        }
                    }
                }
            }

            return feedFixtures;
        }
    }
}
