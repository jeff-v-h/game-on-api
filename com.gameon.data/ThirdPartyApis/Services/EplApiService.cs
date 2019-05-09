using com.gameon.data.ThirdPartyApis.Models.Football;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace com.gameon.data.ThirdPartyApis.Services
{
    public class EplApiService : IEplApiService
    {
        private readonly HttpClient _client;
        private IConfigurationSection _settings;
        private string _host;
        public bool IsError = false;
        public string ErrorMessage;

        public EplApiService(IConfiguration config, HttpClient client)
        {
            _client = client;
            _settings = config.GetSection("EplApi");
            _host = _settings["Host"];

            _client.BaseAddress = new Uri(_host);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("User-Agent", "Game-On-Api");
        }

        public async Task<List<Fixture>> GetSchedule()
        {
            var path = _settings["Schedule"];
            var response = await _client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<IEnumerable<FootballApi>>();
                return result.FirstOrDefault().Api.Fixtures;
            }
            else
            {
                IsError = true;
                ErrorMessage = response.ReasonPhrase;
                return null;
            }
        }

        public async Task<List<Team>> GetTeams()
        {
            var path = _settings["Teams"];
            var response = await _client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<IEnumerable<FootballApi>>();
                return result.FirstOrDefault().Api.Teams;
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
