using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs.Requestes;
using WebApplication1.DTOs.Responses;

namespace WebApplication1.Services
{
    public interface IDbService
    {
        public GetArtistResponse GetArtist(string id);
        public PutArtistTimeResponse PutArtist(PutArtistTimeRequest request, string idArtist, string idEvent);
        

        
    }
}
