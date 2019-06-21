using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjektZespolowy.Models;
using ProjektZespolowy.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ProjektZespolowy.Services
{
    public class MatchService : IMatchService
    {
        private readonly AppContext _appContext;// variable used for sending data to DataBase

        public MatchService(AppContext appContext)
        {
            _appContext = appContext;
        }
        /*
        Match matches = new Match
        {
            Id = 1,
            Opponent1_name = "Dzbany",
            Opponent2_name = "W-4",
            Opponent1_score = 11,
            Opponent2_score = 22
        };
        public void CreateData()
        {
            _appDbContext.Matchs.Add(matches);
            _appDbContext.SaveChanges();
        }
    */

        public IEnumerable<Match> GetAllMatchs()
        {

            return _appContext.Matchs.ToList();
        }

        public Match GetMatchById(int id)
        {
            return _appContext.Matchs.FirstOrDefault(x => x.Id == id); // albo zwraca albo nie jeśli nie to 404
        }

        public void AddMatch(Match match)
        {
            _appContext.Matchs.Add(match);
            _appContext.SaveChanges();
        }
    }
}