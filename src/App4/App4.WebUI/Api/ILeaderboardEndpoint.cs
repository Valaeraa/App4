using App4.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App4.WebUI.Api
{
    public interface ILeaderboardEndpoint
    {
        Task<IEnumerable<LeaderboardModel>> GetAll();
        Task<LeaderboardModel> GetById(int id);
        Task Update(int id, LeaderboardModel leaderboard);
        Task Create(LeaderboardModel leaderboard);
    }
}
