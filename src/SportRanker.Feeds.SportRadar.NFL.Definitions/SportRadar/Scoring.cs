using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SportRanker.Feeds.SportRadar.NFL.Definitions
{
    public class Scoring
    {
        [DataMember(Name = "home_points")]
        public int HomePoints { get; set; }

        [DataMember(Name = "away_points")]
        public int AwayPoints { get; set; }

        [DataMember(Name = "periods")]
        public ICollection<Period> Periods { get; set; }
    }
}
