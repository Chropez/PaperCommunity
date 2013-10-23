using PaperCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaperCommunity.BusinessLogic
{
    public class GamingSessionService
    {

        private ProEntities db = new ProEntities();


        public IList<SelectListItem> getPlayerTeamSelectList()
        {
            return getPlayerTeamSelectList("");
        }

        public IList<SelectListItem> getPlayerTeamSelectList(String HomeOrAway)
        {
            //Game LastPlayedGame = null;
            //if (db.Games.Count() > 0)
            //{
            //    int lastId = db.Games.Max(item => item.id);
            //    LastPlayedGame = db.Games.Find(lastId);
            //}


            //List<PlayerTeam> teams = db.PlayerTeams.ToList();
            //IList<SelectListItem> selectList = new List<SelectListItem>();
            //foreach (PlayerTeam team in teams)
            //{
            //    SelectListItem selectListItem = new SelectListItem();
            //    selectListItem.Value = team.id.ToString();
            //    selectListItem.Text = team.Player.Username + " - " + team.Team.Name;

            //    //Makes selected
            //    if (HomeOrAway == Game.HOME)
            //    {
            //        if (LastPlayedGame != null && LastPlayedGame.HomeTeam.id == team.id)
            //        {
            //            selectListItem.Selected = true;
            //        }
            //    }
            //    else if (LastPlayedGame != null && HomeOrAway == Game.AWAY)
            //    {
            //        if (LastPlayedGame != null && LastPlayedGame.AwayTeam.id == team.id)
            //        {
            //            selectListItem.Selected = true;
            //        }

            //    }

            //    selectList.Add(selectListItem);

            //}

            //return selectList;
            return null;
        }
    }
}