using System.Runtime.Serialization;

namespace SportRanker.Feeds.SportRadar.NFL.Definitions
{
    public class Broadcast
    {
        [DataMember(Name = "id")]
        public string network { get; set; }

        [DataMember(Name = "id")]
        public string satellite { get; set; }

        [DataMember(Name = "id")]
        public string internet { get; set; }
    }
}
