using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs.Responses
{
    public class PutArtistTimeResponse
    {
       
        public int IdArtist { get; set; }
        
        public int IdEvent { get; set; }
        public DateTime PerformanceDate { get; set; }

    }
}
