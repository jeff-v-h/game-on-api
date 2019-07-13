using com.gameon.data.ThirdPartyApis.Interfaces;
using com.gameon.data.ThirdPartyApis.Models.Football;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace com.gameon.data.ThirdPartyApis.Services
{
    public class FootballApiService : IFootballApiService
    {
        private readonly HttpClient _client;
        private IConfigurationSection _settings;
        private string _host;

        public FootballApiService(IConfiguration config, HttpClient client)
        {
            _client = client;
            _settings = config.GetSection("FootballApi");
            _host = _settings["Host"];
            var apiKey = _settings["ApiKeyValue"];
            var apiHostHeader = _settings["ApiHostHeader"];
            var apiKeyQuery = _settings["ApiKeyQuery"];

            _client.BaseAddress = new Uri(_host);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("User-Agent", "Game-On-Api");
            _client.DefaultRequestHeaders.Add(apiKeyQuery, apiKey);
            _client.DefaultRequestHeaders.Add("X-RapidAPI-Host", apiHostHeader);
        }

        public async Task<List<Fixture>> GetSchedule(string league)
        {
            var path = _settings[GetLeagueNameString(league) + "Schedule"];
            var response = await _client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<FootballApi>(jsonString);
                return result.Api.Fixtures;
            }
            else throw new Exception(response.ReasonPhrase);
        }

        public async Task<List<Fixture>> GetLiveGames(string league)
        {
            var path = _settings[GetLeagueNameString(league) + "Live"];
            var response = await _client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<FootballApi>(jsonString);
                return result.Api.Fixtures;
            }
            else throw new Exception(response.ReasonPhrase);
        }

        public async Task<List<Team>> GetTeams(string league)
        {
            var path = _settings[GetLeagueNameString(league) + "Teams"];
            var response = await _client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<FootballApi>(jsonString);
                return result.Api.Teams;
            }
            else throw new Exception(response.ReasonPhrase);
        }

        private string GetLeagueNameString(string league)
        {
            switch (league.ToLower())
            {
                case "epl":
                    return "Epl";
                case "europaleague":
                    return "EuropaLeague";
                case "championsleague":
                    return "ChampionsLeague";
                default:
                    throw new Exception("error with league");
            }
        }
    }
}
