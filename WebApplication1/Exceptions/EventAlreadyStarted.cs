using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Exceptions
{
    public class EventAlreadyStarted : Exception
    {
        public EventAlreadyStarted() : base("Event has already started, you can't change the date")
        {

        }
    }
}
