using System.Runtime.Serialization;

namespace SportRanker.Feeds.SportRadar.NFL.Definitions
{
    public class Broadcast
    {
        [DataMember(Name = "network")]
        public string Network { get; set; }

        [DataMember(Name = "satellite")]
        public string Satellite { get; set; }

        [DataMember(Name = "internet")]
        public string Internet { get; set; }
    }
}
