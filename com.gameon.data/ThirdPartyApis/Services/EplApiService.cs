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
            var apiKey = _settings["ApiKey"];
            var apiHostHeader = _settings["ApiHostHeader"];

            _client.BaseAddress = new Uri(_host);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("User-Agent", "Game-On-Api");
            _client.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);
            _client.DefaultRequestHeaders.Add("X-RapidAPI-Host", apiHostHeader);
        }

        public async Task<List<Fixture>> GetSchedule()
        {
            var path = _settings["Schedule"];
            var response = await _client.GetAsync(path);

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

        public async Task<List<Team>> GetTeams()
        {
            var path = _settings["Teams"];
            var response = await _client.GetAsync(path);

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
