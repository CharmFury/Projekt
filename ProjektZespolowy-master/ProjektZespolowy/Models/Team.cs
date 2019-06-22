using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektZespolowy.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Win { get; set; }
        public int Loss { get; set; }
        public ICollection<User> TeamMembers { get; set; } = new List<User>();
        //public ICollection<Match> TeamMatches { get; set; } = new List<Match>();
        

    }
}
