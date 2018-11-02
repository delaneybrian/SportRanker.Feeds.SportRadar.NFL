using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SportRanker.Feeds.SportRadar.NFL.Definitions
{
    public class FeedSchedule
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "year")]
        public int Year { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "weeks")]
        public ICollection<Week> Weeks { get; set; }

        [DataMember(Name = "_comment")]
        public string Comment { get; set; }
    }  
}
