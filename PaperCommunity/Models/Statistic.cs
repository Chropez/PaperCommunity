using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PaperCommunity.Entities;

namespace PaperCommunity.Models
{
    public class Statistic
    {
        private ProEntities db = new ProEntities();


        public IList<OverallPlayerData> getOverallPlayerData()
        {

            return getOverallPlayerData(new List<Player>());
        }
        public IList<OverallPlayerData> getOverallPlayerData(Player Player)
        {

            return getOverallPlayerData(new List<Player> { Player });
        }

        //If the list is empty gets the whole table
        public IList<OverallPlayerData> getOverallPlayerData(List<Player> Players)
        {

            List<OverallPlayerData> overallPlayerData = new List<OverallPlayerData>();

            //List<Game> Games = db.Games != null && db.Games.Count() > 0 ? db.Games.ToList() : new List<Game>();

            //foreach (Game game in Games)
            //{   
            //    OverallPlayerData homePlayerData = overallPlayerData.Find(item => item.Player == game.HomeTeam.Player);
            //    OverallPlayerData awayPlayerData = overallPlayerData.Find(item => item.Player == game.AwayTeam.Player);

            //    if (Players.Count == 0 || Players.Any(player => player.Username == game.HomeTeam.Player.Username) || Players.Any(player => player.Username == game.AwayTeam.Player.Username))
            //    {

            //        if (homePlayerData == null)
            //        {
            //            homePlayerData = new OverallPlayerData();
            //            homePlayerData.Player = game.HomeTeam.Player;
            //            overallPlayerData.Add(homePlayerData);
            //        }
            //        if (awayPlayerData == null)
            //        {
            //            awayPlayerData = new OverallPlayerData();
            //            awayPlayerData.Player = game.AwayTeam.Player;
            //            overallPlayerData.Add(awayPlayerData);
            //        }

            //        homePlayerData = addMatchToOverallPlayerData(game.HomeGoals, game.AwayGoals, homePlayerData);
            //        awayPlayerData = addMatchToOverallPlayerData(game.AwayGoals, game.HomeGoals, awayPlayerData);

            //    }
                
            //}



            //List<Player> players = db.Players.ToList();

            //foreach (Player player in players)
            //{
            //    OverallPlayerData playerData = new OverallPlayerData();
            //    List<Game> Games = db.Games.Where(game => game.HomeTeam.Player == player || game.AwayTeam.Player == player).ToList() ;

            //    foreach (Game Game in Games)
            //    {
            //        //Adds to games played
            //        playerData.Played++;

            //        if (Game.HomeTeam.Player == player)
            //        {
            //            //If win
            //            if (Game.HomeGoals > Game.AwayGoals)
            //            {
            //                playerData.Points += 3;
            //            }
            //            //If loss
            //            else if (Game.HomeGoals < Game.AwayGoals)
            //            {

            //            }
            //            //IF draw
            //            else
            //            {

            //            }
            //        }
            //        else
            //        {
            //            //If win
            //            if (Game.HomeGoals < Game.AwayGoals)
            //            {
            //                playerData.Points += 3;
            //            }
            //            //If win
            //            else if (Game.HomeGoals > Game.AwayGoals)
            //            {

            //            }
            //            //If draw
            //            else
            //            {

            //            }

            //        }
            //    }
                
            //}
            //overallPlayerData =  overallPlayerData.OrderByDescending(data => data.Points).ToList();
            return overallPlayerData;
        }


        private OverallPlayerData addMatchToOverallPlayerData(int playerGoals, int opponentGoals, OverallPlayerData data)
        {
            data.Played++; //Adds to played games
            data.GoalsFor += playerGoals;
            data.GoalsAgainst += opponentGoals;


            if(playerGoals > opponentGoals){
                data.Wins++;
                data.Points += 3;
            }
            else if (playerGoals == opponentGoals)
            {
                data.Draws++;
                data.Points += 1;
            }
            else
                data.Losses++;
                



            return data;
        }


    }
}