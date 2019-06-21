using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjektZespolowy.Models;

namespace ProjektZespolowy.Dtos
{
    public class TeamDto
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<UserDto> TeamMembers { get; set; } = new List<UserDto>();
    }
}
