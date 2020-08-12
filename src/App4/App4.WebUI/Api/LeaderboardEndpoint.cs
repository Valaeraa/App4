using App4.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App4.WebUI.Api
{
    public class LeaderboardEndpoint : ILeaderboardEndpoint
    {
        private readonly IAPIHelper _apiHelper;

        public LeaderboardEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public Task Create(LeaderboardModel leaderboard)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LeaderboardModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<LeaderboardModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, LeaderboardModel leaderboard)
        {
            throw new NotImplementedException();
        }
    }
}
