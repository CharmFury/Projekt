using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektZespolowy.Models
{
    public class Match
    {
        public int Id { get; set; }
        public string Opponent1_name { get; set; }
        public string Opponent2_name { get; set; }

        public int Opponent1_score { get; set; }
        public int Opponent2_score { get; set; }

        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public Team Team { get; set; }


        public int Opponent1_Win { get; set; }// 0 or 1 for loss/win
        public int Opponent2_Win { get; set; }// 0 or 1 for loss/win
       /* public DateTime Date { get; set; }
        public string Place { get; set; }*/
    }
}