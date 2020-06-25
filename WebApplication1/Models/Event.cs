﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Event
    {
        public Event()
        {
            ArtistEvent = new HashSet<ArtistEvent>();
            EventOrganiser = new HashSet<EventOrganiser>();
        }

        public int IdEvent { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [JsonIgnore]
        public virtual ICollection<ArtistEvent> ArtistEvent { get; set; }
        [JsonIgnore]
        public virtual ICollection<EventOrganiser> EventOrganiser { get; set; }
    }
}
