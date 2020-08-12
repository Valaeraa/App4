using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace App4.WebUI.Api
{
    public class APIHelper : IAPIHelper
    {
        public APIHelper(IConfiguration config)
        {
            _config = config;

            InitializeClient();
        }

        private HttpClient _apiClient;
        private readonly IConfiguration _config;

        public HttpClient ApiClient
        {
            get
            {
                return _apiClient;
            }
        }

        private void InitializeClient()
        {
            var api = _config.GetValue<string>("ApiKey");

            _apiClient = new HttpClient();

            _apiClient.BaseAddress = new Uri(api);
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
