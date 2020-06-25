using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Exceptions
{
    public class NotFoundArtist : Exception
    {
        public NotFoundArtist() : base("No such id")
        {

        }
    }
}
