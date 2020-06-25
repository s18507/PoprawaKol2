﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Artist
    {
        public Artist()
        {
            ArtistEvent = new HashSet<ArtistEvent>();
        }

        public int IdArtist { get; set; }
        public string Nickname { get; set; }

        public virtual ICollection<ArtistEvent> ArtistEvent { get; set; }
    }
}
