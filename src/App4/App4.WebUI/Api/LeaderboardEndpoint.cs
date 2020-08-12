using App4.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace App4.WebUI.Api
{
    public class LeaderboardEndpoint : ILeaderboardEndpoint
    {
        private const string _requestUri = "api/Leaderboard";
        private readonly IAPIHelper _apiHelper;

        public LeaderboardEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task Create(LeaderboardModel leaderboard)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync(_requestUri, leaderboard))
            {
                if (response.IsSuccessStatusCode)
                {
                    response.StatusCode = System.Net.HttpStatusCode.Created;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<IEnumerable<LeaderboardModel>> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync(_requestUri))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<LeaderboardModel>>();

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<LeaderboardModel> GetById(int id)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"{_requestUri}/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<LeaderboardModel>();

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task Update(int id, LeaderboardModel leaderboard)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PutAsJsonAsync($"{_requestUri}/{id}", leaderboard))
            {
                if (response.IsSuccessStatusCode)
                {
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
