using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Exceptions
{
    public class NoArtistInEvent :Exception
    {
        public NoArtistInEvent() : base("No such artist in this event")
        {

        }
    }
}
