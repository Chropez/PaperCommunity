using System.ComponentModel.DataAnnotations;

namespace PaperCommunity.Models
{
    public class Player
    {
        [Key]
        [Required]
        public string Username { get; set; }
        [Display(Name = "Favorite team")]
        public virtual Team DefaultTeam { get; set; }
    }
}