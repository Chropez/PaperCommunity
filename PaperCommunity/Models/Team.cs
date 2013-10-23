using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaperCommunity.Models
{
    public class Team
    {
        [Key]
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}