using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PaperCommunity.Entities;
using PaperCommunity.Models;

namespace PaperCommunity.ViewModels
{
    public class HomeViewModel
    {
        public IList<OverallPlayerData> overallPlayerData { get; set; }


        public HomeViewModel()
        {
            Statistic st = new Statistic();
            overallPlayerData = st.getOverallPlayerData();

        }

    }
}