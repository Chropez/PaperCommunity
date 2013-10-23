using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PaperCommunity.Models;
using PaperCommunity.Entities;

namespace PaperCommunity.ViewModels
{
    public class PlayerDetailsViewModel
    {
        public Player Player { get; set; }
        public IList<OverallPlayerData> OverallPlayerData { get; set; }
    }
}