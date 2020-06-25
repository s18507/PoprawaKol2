using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs.Requestes;
using WebApplication1.DTOs.Responses;
using WebApplication1.Exceptions;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class DbService : IDbService
    {
        private readonly s18507Context _dbcontext;
        public DbService(s18507Context dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public GetArtistResponse GetArtist(string id)
        {
            int idInt = Convert.ToInt32(id);
              
            var artist = _dbcontext.Artist.FirstOrDefault(p => p.IdArtist == idInt);
            if (artist == null) throw new NotFoundArtist();

            var artistEvent = (from events in _dbcontext.Event
                              join eventsArt in _dbcontext.ArtistEvent
                              on events.IdEvent equals eventsArt.EventIdEvent
                              where eventsArt.ArtistIdArtist == idInt
                              orderby events.StartDate descending
                              select new Event
                              {
                                  IdEvent = events.IdEvent,
                                  Name = events.Name,
                                  StartDate = events.StartDate,
                                  EndDate = events.EndDate
                              }).ToList();

            return new GetArtistResponse { Nickname = artist.Nickname, Events = artistEvent };
  
        }
        public PutArtistTimeResponse PutArtist(PutArtistTimeRequest request, string idArtist, string idEvent)
        {
            int id_artist = Convert.ToInt32(idArtist);
            int id_event = Convert.ToInt32(idEvent);

            var artist = _dbcontext.Artist.FirstOrDefault(p => p.IdArtist == id_artist);
            if (artist == null) throw new NotFoundArtist();

            var events = _dbcontext.Event.FirstOrDefault(p => p.IdEvent == id_event);
            if (events == null) throw new NotFoundEvent();

            var artistEvent = _dbcontext.ArtistEvent.
                FirstOrDefault(p => p.ArtistIdArtist == id_artist && p.EventIdEvent == id_event);
            if (artistEvent == null) throw new NoArtistInEvent();

            if (events.StartDate <= DateTime.Now) throw new EventAlreadyStarted();

            if (request.PerformanceDate < events.StartDate && request.PerformanceDate > events.EndDate)
                throw new NotInTheTimeOfEvent();

            artistEvent.PerformanceDate = request.PerformanceDate;
            _dbcontext.ArtistEvent.Update(artistEvent);
            _dbcontext.SaveChanges();

            return new PutArtistTimeResponse 
            { 
                IdArtist = artist.IdArtist, 
                IdEvent = events.IdEvent, 
                PerformanceDate = artistEvent.PerformanceDate
            };
            

            

        }

    }
}
