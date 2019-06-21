using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjektZespolowy.Models;
using ProjektZespolowy.Services;

namespace ProjektZespolowy.Services
{
    public interface IMatchService
    {
        IEnumerable<Match> GetAllMatchs();
        //void AddScore ( string Opponent1_name, int Opponent1_score, string Opponent2_name, int Opponent2_score);

        Match GetMatchById(int id);
        void AddMatch(Match match);
    }
}