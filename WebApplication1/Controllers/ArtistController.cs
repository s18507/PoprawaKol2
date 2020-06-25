using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Requestes;
using WebApplication1.DTOs.Responses;
using WebApplication1.Exceptions;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IDbService _service;
        public ArtistController(IDbService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetArtist(string id)
        {
            try
            {
                var response = _service.GetArtist(id);
                return Ok(response);
            }
            catch (NotFoundArtist ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut("{idArtist}/events/{idEvent}")]
        public IActionResult PutPerformanceDate(PutArtistTimeRequest request, string idArtist, string idEvent)
        {
            try
            {
                var response = _service.PutArtist(request, idArtist, idEvent);
                return Ok(response);
            }
            catch (NotFoundArtist ex)
            {
                return NotFound(ex.Message);
            }
            catch (NotFoundEvent ex)
            {
                return NotFound(ex.Message);
            }
            catch(NoArtistInEvent ex)
            {
                return NotFound(ex.Message);
            }
            catch(EventAlreadyStarted ex)
            {
                return BadRequest(ex.Message);
            }
            catch(NotInTheTimeOfEvent ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}