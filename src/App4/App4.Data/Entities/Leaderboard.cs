using System;
using System.Collections.Generic;
using System.Text;

namespace App4.Data.Entities
{
    public class Leaderboard
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
        public int GamesPlayed { get; set; }
    }
}
