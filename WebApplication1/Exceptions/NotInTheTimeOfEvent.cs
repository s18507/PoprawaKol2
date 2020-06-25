using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Exceptions
{
    public class NotInTheTimeOfEvent : Exception
    {
        public NotInTheTimeOfEvent() : base("Performance not in the time of event")
        {

        }
    }
}
