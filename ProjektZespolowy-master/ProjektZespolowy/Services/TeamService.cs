using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjektZespolowy.Models;
using ProjektZespolowy.Services;
namespace ProjektZespolowy.Services
{


    public class TeamService : ITeamService
    {

        private AppContext _context;

        public TeamService(AppContext context)
        {
            _context = context;
        }
        
        public Match GetMatchById(int id)
        {
            return _context.Matchs.FirstOrDefault(x => x.Id == id);
        }

        public void WinLoss()
        {
            
            for (int i= 1;i< (_context.Teams.Count()); i++ )
            {
                //_context.Teams.TeamId[i];
                
                var teamFromRepo = GetTeamById(i);
                var matchFromRepo = GetMatchById(i);

                if(matchFromRepo.Opponent1_name==teamFromRepo.Name)
                {
                    if(matchFromRepo.Opponent1_score>matchFromRepo.Opponent2_score)
                    {
                        teamFromRepo.Win++;//jak wygra doliczamy do wygranych
                    }
                    else
                    {
                        teamFromRepo.Loss++;//jak przegra doliczamy do przegranych
                    }


                    /*
                    if(matchFromRepo.Opponent1_Win==1)
                    {
                        teamFromRepo.Win++;
                    }*/


                }
                else if(matchFromRepo.Opponent2_name == teamFromRepo.Name)//sprawdzamy czy nie ejst drugim teamem
                {
                    if (matchFromRepo.Opponent2_score > matchFromRepo.Opponent1_score)
                    {
                        teamFromRepo.Win++;//jak wygra doliczamy do wygranych
                    }
                    else
                    {
                        teamFromRepo.Loss++;//jak przegra doliczamy do przegranych
                    }
                }


                _context.Teams.Update(teamFromRepo);
                _context.SaveChanges();
            }
        }

        public ICollection<Team> GetTeamsList()
        {
            WinLoss();
            var teamsFromRepo = _context.Teams.ToList();

            return teamsFromRepo;
        }

        public Team GetTeamById(int id)
        {
            WinLoss();
            var teamFromRepo = _context.Teams.Include(m => m.TeamMembers).FirstOrDefault(t => t.TeamId == id);

            return teamFromRepo;
        }

        public void AddTeam(Team team)
        {
            _context.Add(team);
            _context.SaveChanges();
        }

        public void UpdateTeam(Team team)
        {
            _context.Teams.Update(team);
            _context.SaveChanges();
        }

        public void DeleteTeam(int id)
        {
            var userToDelete = GetTeamById(id);
            _context.Remove(userToDelete);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetTeamMembers(int teamId)
        {
            return _context.Users.Where(t => t.TeamId == teamId).ToList();
        }

        public User GetTeamMemberById(int teamId, int userId)
        {
            return _context.Users.Where(t => t.TeamId == teamId && t.Id == userId).FirstOrDefault();
        }

        public void DeleteTeamMember(int teamId, int userId)
        {
            var userToDelete = GetTeamMemberById(teamId, userId);
            _context.Users.Remove(userToDelete);
            _context.SaveChanges();

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void AddTeamMember(int cityId, User user)
        {
            var teamFromRepo = GetTeamById(cityId);
            teamFromRepo.TeamMembers.Add(user);
            _context.Teams.Update(teamFromRepo);
            _context.SaveChanges();
        }
        /*
        public void AddMatch(int Id, User user)
        {
            var teamFromRepo = GetTeamById(cityId);
            teamFromRepo.TeamMembers.Add(user);
            _context.Teams.Update(teamFromRepo);
            _context.SaveChanges();
        }*/

    }
}
