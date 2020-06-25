using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class ArtistEvent
    {
        public int ArtistIdArtist { get; set; }
        public int EventIdEvent { get; set; }
        public DateTime PerformanceDate { get; set; }

        public virtual Artist ArtistIdArtistNavigation { get; set; }
        public virtual Event EventIdEventNavigation { get; set; }
    }
}
