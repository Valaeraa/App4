using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App4.WebUI.Models
{
    public class LeaderboardModel
    {
        public int UserId { get; set; }
        public int Score { get; set; }
        public int GamesPlayed { get; set; }
    }
}
