using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DTOs.Responses
{
    public class GetArtistResponse
    {
        public string Nickname { get; set; }
        public List<Event> Events { get; set; }
    }
}
