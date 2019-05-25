using com.gameon.data.ThirdPartyApis.Interfaces;
using com.gameon.data.ThirdPartyApis.Models.Esports;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace com.gameon.data.ThirdPartyApis.Services
{
    public class ESportsApiService : IESportsApiService
    {
        private readonly HttpClient _client;
        private IConfigurationSection _settings;
        private string _host;
        private string _apiKey;
        private string _apiKeyQuery;
        public bool IsError = false;
        public string ErrorMessage;

        public ESportsApiService(IConfiguration config, HttpClient client)
        {
            _client = client;
            _settings = config.GetSection("ESportsApi");
            _host = _settings["Host"];
            _apiKey = _settings["ApiKeyValue"];
            _apiKeyQuery = _settings["ApiKeyQuery"];

            _client.BaseAddress = new Uri(_host);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("User-Agent", "Game-On-Api");
        }

        public async Task<List<Tournament>> GetDotaTournaments()
        {
            return await GetTournaments("Dota");
        }
        public async Task<List<Team>> GetDotaTeams()
        {
            return await GetTeams("Dota");
        }

        public async Task<List<Tournament>> GetLolTournaments()
        {
            return await GetTournaments("LeagueOfLegends");
        }
        public async Task<List<Team>> GetLolTeams()
        {
            return await GetTeams("LeagueOfLegends");
        }

        public async Task<List<Tournament>> GetOverwatchTournaments()
        {
            return await GetTournaments("Overwatch");
        }

        public async Task<List<Team>> GetOverwatchTeams()
        {
            return await GetTeams("Overwatch");
        }

        public async Task<List<Tournament>> GetCsgoTournaments()
        {
            return await GetTournaments("CounterStrikeGlobalOffensive");
        }

        public async Task<List<Team>> GetCsgoTeams()
        {
            return await GetTeams("CounterStrikeGlobalOffensive");
        }

        private async Task<List<Tournament>> GetTournaments(string game)
        {
            // Create the main url pathway
            var mainUrl = _host + _settings[game] + _settings["Tournaments"];

            // Add parameters to url
            var builder = new UriBuilder(mainUrl);
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            query[_apiKeyQuery] = _apiKey;
            builder.Query = query.ToString();
            string requestUrl = builder.ToString();

            var response = await _client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Tournament>>(jsonString);
                return result;
            }
            else
            {
                IsError = true;
                ErrorMessage = response.ReasonPhrase;
                throw new Exception(ErrorMessage);
            }
        }

        private async Task<List<Team>> GetTeams(string game)
        {
            // Create the main url pathway
            var mainUrl = _host + _settings[game] + _settings["Teams"];

            // Add parameters to url
            var builder = new UriBuilder(mainUrl);
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            query[_apiKeyQuery] = _apiKey;
            builder.Query = query.ToString();
            string requestUrl = builder.ToString();

            var response = await _client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Team>>(jsonString);
                return result;
            }
            else
            {
                IsError = true;
                ErrorMessage = response.ReasonPhrase;
                throw new Exception(ErrorMessage);
            }
        }
    }
}
