using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class EventOrganiser
    {
        public int EventIdEvent { get; set; }
        public int OrganiserIdOrganiser { get; set; }

        public virtual Event EventIdEventNavigation { get; set; }
        public virtual Organiser OrganiserIdOrganiserNavigation { get; set; }
    }
}
