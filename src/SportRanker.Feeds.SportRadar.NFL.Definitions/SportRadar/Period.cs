using System.Runtime.Serialization;

namespace SportRanker.Feeds.SportRadar.NFL.Definitions
{
    public class Period
    {
        [DataMember(Name = "period_type")]
        public string PeriodTtype { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "number")]
        public int Number { get; set; }

        [DataMember(Name = "sequence")]
        public int Sequence { get; set; }

        [DataMember(Name = "home_points")]
        public int HomePoints { get; set; }

        [DataMember(Name = "away_points")]
        public int AwayPoints { get; set; }
    }
}
