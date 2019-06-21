using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjektZespolowy.Models;
using ProjektZespolowy.Services;

namespace ProjektZespolowy.Controllers
{
    /*
    [Route("api/[controller]")]
    [ApiController]*/
    public class MatchsController : Controller//Base
    {
        private IMatchService _matchService;

        public MatchsController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet("api/games")]
        public IActionResult GetMatchs()
        {
            //_matchService.CreateData();
            var matchsFromRepo = _matchService.GetAllMatchs();


            return new JsonResult(matchsFromRepo);
        }


        [HttpPost("api/score")]
        public IActionResult AddScore([FromBody] Match match)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(match);
            }

            _matchService.AddMatch(match);
            //_teamService.AddUsertoTeam(teamId, userNick);
            return Ok();
        }


    }
}