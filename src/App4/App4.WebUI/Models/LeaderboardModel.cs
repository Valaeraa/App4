using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App4.WebUI.Models
{
    public class LeaderboardModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select a user")]
        [Display(Name = "User Id")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please add a score")]
        public int Score { get; set; }

        [Required(ErrorMessage = "Please add the number of games played")]
        [Display(Name = "Games Played")]
        public int GamesPlayed { get; set; }
    }
}
