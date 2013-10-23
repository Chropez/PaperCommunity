using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PaperCommunity.Models
{
    //Match
    public class Game
    {
        public int id {get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual Team AwayTeam { get; set; }

        public virtual Player HomePlayer { get; set; }
        public virtual Player AwayPlayer { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }



        //Constants
        public static String HOME = "home";
        public static String AWAY = "away";

    }
}