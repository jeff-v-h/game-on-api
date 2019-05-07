using com.gameon.data.ThirdPartyApis.Interfaces;
using com.gameon.data.ThirdPartyApis.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace com.gameon.data.ThirdPartyApis.Services
{
    public class DotaApiService : IDotaApiService
    {
        private readonly HttpClient _client;
        private IConfigurationSection _settings;
        private string _host;
        public IEnumerable<ProMatch> Schedule;
        public bool IsError = false;
        public string ErrorMessage;

        public DotaApiService(IConfiguration config, HttpClient client)
        {
            _client = client;
            _settings = config.GetSection("DotaApi");
            _host = _settings["Host"];

            _client.BaseAddress = new Uri(_host);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("User-Agent", "Game-On-Api");
        }

        public async Task<IEnumerable<ProMatch>> GetSchedule()
        {
            var path = _settings["Schedule"];
            var response = await _client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<IEnumerable<ProMatch>>();
                return result;
            }
            else
            {
                IsError = true;
                ErrorMessage = response.ReasonPhrase;
                return null;
            }
        }
    }
}
