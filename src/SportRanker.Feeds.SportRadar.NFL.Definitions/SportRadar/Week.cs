using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SportRanker.Feeds.SportRadar.NFL.Definitions
{
    public class Week
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "sequence")]
        public int Sequence { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "games")]
        public ICollection<Game> Games { get; set; }
    }
}
