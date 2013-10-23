using PaperCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperCommunity.ViewModels
{
    public class GamingSessionViewModel
    {
        public GamingSession GamingSession { get; set; }
        public Game NewGame { get; set; }
    }
}