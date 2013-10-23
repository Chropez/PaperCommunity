using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperCommunity.Models
{
    public class GamingSession
    {

        public GamingSession ()
        {
            Games = new List<Game>();
        }

        public int id { get; set; }
        public DateTime? Date { get; set; }
        public virtual List<Game> Games { get; set; }

        

    }
}