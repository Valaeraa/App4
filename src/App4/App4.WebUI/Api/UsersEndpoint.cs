using App4.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace App4.WebUI.Api
{
    public class UsersEndpoint : IUsersEndpoint
    {
        private readonly IAPIHelper _apiHelper;

        public UsersEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task Create(UserModel user)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("api/Users", user))
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

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("api/Users"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<UserModel>>();

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<UserModel> GetById(int id)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/Users/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<UserModel>();

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task Update(int id, UserModel user)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PutAsJsonAsync($"api/Users/{id}", user))
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
