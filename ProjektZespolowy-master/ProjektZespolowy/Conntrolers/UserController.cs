using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjektZespolowy.Dtos;
using ProjektZespolowy.Models;
using ProjektZespolowy.Services;

namespace ProjektZespolowy.Conntrolers
{
    [Route("api/team")]
    public class UserController : Controller
    {
        private IUserService _userService;
        private ITeamService _teamService;

        public UserController(IUserService userService, ITeamService teamService)
        {
            _userService = userService;
            _teamService = teamService;
        }

        [HttpGet("/user/{teamId}")]
        public IActionResult GetTeamMembers(int teamId)
        {
            var teamFromRepo = _teamService.GetTeamById(teamId);
            if (teamFromRepo == null)
            {
                return BadRequest();
            }

            
            var teamMembers = _teamService.GetTeamMembers(teamId);
            var results = Mapper.Map<IEnumerable<UserDto>>(teamMembers);

            return Ok(results);
        }

        [HttpPost("{teamId}/user")]
        public IActionResult AddUser(int teamId, [FromBody] UserForCreationDto userForCreationDto)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            var teamFromRepo = _teamService.GetTeamById(teamId);
            if (teamFromRepo == null)
            {
                return BadRequest();
            }

            var userToAdd = Mapper.Map<User>(userForCreationDto);
            _teamService.AddTeamMember(teamId, userToAdd);
            

            return Ok(userToAdd);
        }
        [HttpPut("{teamId}/user/{userId}")]
        public IActionResult UpdateUser(int teamId, int userId, [FromBody] UserForUpdateDto userForUpdateDto)
        {
            
            var userFromRepo = _teamService.GetTeamMemberById(teamId, userId);
            if (userFromRepo == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var updatedUser = Mapper.Map(userForUpdateDto, userFromRepo);
            
            _teamService.Save();
            return NoContent();
        }
        [HttpDelete("{teamId}/user/{userId}")]
        public IActionResult DeleteUser(int teamId, int userId)
        {
            var userToDelete = _teamService.GetTeamMemberById(teamId, userId);
            if (userToDelete == null)
            {
                return BadRequest();
            }
            
            _teamService.DeleteTeamMember(teamId, userId);
            //_userService.DeleteUser(id);

            return NoContent();
        }


    }
}
