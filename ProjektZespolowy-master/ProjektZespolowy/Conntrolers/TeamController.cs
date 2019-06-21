using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjektZespolowy.Dtos;
using ProjektZespolowy.Models;
using ProjektZespolowy.Services;

namespace ProjektZespolowy.Conntrolers
{
    [Route("api/team")]
    public class TeamController : Controller
    {
        private ITeamService _teamService;
        private IUserService _userService;

        public TeamController(ITeamService teamService, IUserService userService)
        {
            _teamService = teamService;
            _userService = userService;
        }
        [HttpGet]
        public IActionResult GetTeams()
        {
            var teamsFromRepo = _teamService.GetTeamsList();
            var result = Mapper.Map<IEnumerable<TeamDto>>(teamsFromRepo);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetTeamById(int id)
        {
            var teamFromRepo = _teamService.GetTeamById(id);
            if (teamFromRepo == null)
            {
                return BadRequest();
            }

            var result = Mapper.Map<TeamDto>(teamFromRepo);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddTeam([FromBody]TeamForCreationDto teamForCreationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var teamToAdd = Mapper.Map<Team>(teamForCreationDto);
            _teamService.AddTeam(teamToAdd);

            return Ok(teamToAdd);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTeam(int id, [FromBody] TeamForUpdateDto teamForUpdateDto)
        {
            var teamFromRepo = _teamService.GetTeamById(id);

            if (teamFromRepo == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var teamToUpadte = Mapper.Map(teamForUpdateDto, teamFromRepo);
            _teamService.UpdateTeam(teamToUpadte);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            var teamToDelete = _teamService.GetTeamById(id);
            if (teamToDelete == null)
            {
                return BadRequest();
            }
            _teamService.DeleteTeam(id);

            return NoContent();
        }
        [HttpGet("{teamId}")]
        public IActionResult ShowTeamMembers(int teamId)
        {
            var teamFromRepo = _teamService.GetTeamById(teamId);
            if (teamFromRepo == null)
            {
                return BadRequest();
            }

            var usersFromRepo = teamFromRepo.TeamMembers.ToList();
            var results = Mapper.Map<IEnumerable<UserDto>>(usersFromRepo);

            return Ok(results);
        }
    }
}
