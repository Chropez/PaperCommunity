using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PaperCommunity.Models;

namespace PaperCommunity.Entities
{
    public class OverallPlayerData
    {
        public Player Player { get; set; }
        public int Played { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int Points { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }

        public OverallPlayerData()
        {
            Played = 0;
            Wins = 0;
            Losses = 0;
            Points = 0;
            GoalsAgainst = 0;
            GoalsFor = 0;
        }


    }
}