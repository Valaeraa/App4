using App4.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App4.WebUI.ViewModels
{
    public class LeaderboardViewModel
    {
        public IEnumerable<UserModel> Users { get; set; }
        public LeaderboardModel Leaderboard { get; set; }
    }
}
