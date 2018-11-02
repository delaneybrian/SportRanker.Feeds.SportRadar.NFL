using System;
using System.Runtime.Serialization;

namespace SportRanker.Feeds.SportRadar.NFL.Definitions
{
    public class Game
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "reference")]
        public string Reference { get; set; }

        [DataMember(Name = "number")]
        public int Number { get; set; }

        [DataMember(Name = "scheduled")]
        public DateTime Scheduled { get; set; }

        [DataMember(Name = "attendance")]
        public int Attendance { get; set; }

        [DataMember(Name = "utc_offset")]
        public int UtcOffset { get; set; }

        [DataMember(Name = "entry_mode")]
        public string EntryMode { get; set; }

        [DataMember(Name = "weather")]
        public string Weather { get; set; }

        [DataMember(Name = "sr_id")]
        public string SrId { get; set; }

        [DataMember(Name = "venue")]
        public Venue Venue { get; set; }

        [DataMember(Name = "home")]
        public Team Home { get; set; }

        [DataMember(Name = "away")]
        public Team Away { get; set; }

        [DataMember(Name = "broadcast")]
        public Broadcast Broadcast { get; set; }

        [DataMember(Name = "scoring")]
        public Scoring Scoring { get; set; }
    }
}
