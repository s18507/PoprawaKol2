﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Exceptions
{
    public class NotFoundEvent : Exception
    {
        public NotFoundEvent() : base("No such event")
        {

        }
    }
}
