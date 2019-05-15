using com.gameon.data.ThirdPartyApis.Interfaces;
using com.gameon.data.ThirdPartyApis.Models.Football;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace com.gameon.data.ThirdPartyApis.Services
{
    public class FootballApiService : IFootballApiService
    {
        private readonly HttpClient _client;
        private IConfigurationSection _settings;
        private string _host;
        public bool IsError = false;
        public string ErrorMessage;

        public FootballApiService(IConfiguration config, HttpClient client)
        {
            _client = client;
            _settings = config.GetSection("FootballApi");
            _host = _settings["Host"];
            var apiKey = _settings["ApiKey"];
            var apiHostHeader = _settings["ApiHostHeader"];

            _client.BaseAddress = new Uri(_host);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("User-Agent", "Game-On-Api");
            _client.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);
            _client.DefaultRequestHeaders.Add("X-RapidAPI-Host", apiHostHeader);
        }

        public async Task<List<Fixture>> GetEplSchedule()
        {
            var path = _settings["Schedule"];
            var id = _settings["EplId"];
            var response = await _client.GetAsync(path + id);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<FootballApi>(jsonString);
                return result.Api.Fixtures;
            }
            else
            {
                IsError = true;
                ErrorMessage = response.ReasonPhrase;
                return null;
            }
        }

        public async Task<List<Team>> GetEplTeams()
        {
            var path = _settings["Teams"];
            var id = _settings["EplId"];
            var response = await _client.GetAsync(path + id);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<FootballApi>(jsonString);
                return result.Api.Teams;
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
