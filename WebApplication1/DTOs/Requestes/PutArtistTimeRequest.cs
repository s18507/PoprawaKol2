﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs.Requestes
{
    public class PutArtistTimeRequest
    {
       
        [Required]
        public DateTime PerformanceDate { get; set; }



    }
}
