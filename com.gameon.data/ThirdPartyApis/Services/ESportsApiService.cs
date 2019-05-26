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

        // Dota
        public async Task<List<Tournament>> GetDotaTournaments()
        {
            return await GetTournaments("Dota");
        }
        public async Task<List<Team>> GetDotaTeams()
        {
            return await GetTeams("Dota");
        }

        public async Task<List<Series>> GetDotaSeries()
        {
            return await GetSeries("Dota");
        }

        // League of Legends
        public async Task<List<Tournament>> GetLolTournaments()
        {
            return await GetTournaments("LeagueOfLegends");
        }
        public async Task<List<Team>> GetLolTeams()
        {
            return await GetTeams("LeagueOfLegends");
        }

        public async Task<List<Series>> GetLolSeries()
        {
            return await GetSeries("Lol");
        }

        // Overwatch
        public async Task<List<Tournament>> GetOverwatchTournaments()
        {
            return await GetTournaments("Overwatch");
        }

        public async Task<List<Team>> GetOverwatchTeams()
        {
            return await GetTeams("Overwatch");
        }

        public async Task<List<Series>> GetOverwatchSeries()
        {
            return await GetSeries("Overwatch");
        }

        // CSGO
        public async Task<List<Tournament>> GetCsgoTournaments()
        {
            return await GetTournaments("CounterStrikeGlobalOffensive");
        }

        public async Task<List<Team>> GetCsgoTeams()
        {
            return await GetTeams("CounterStrikeGlobalOffensive");
        }

        public async Task<List<Series>> GetCsgoSeries()
        {
            return await GetSeries("CounterStrikeGlobalOffensive");
        }

        private async Task<List<Tournament>> GetTournaments(string game)
        {
            // Create the main url pathway
            var mainUrl = _host + _settings[game] + _settings["Tournaments"];
            string requestUrl = BuildUrlWithQueryParams(mainUrl);

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
            string requestUrl = BuildUrlWithQueryParams(mainUrl);

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

        private async Task<List<Series>> GetSeries(string game)
        {
            // Create the main url pathway
            var mainUrl = _host + _settings[game] + _settings["Series"];
            string requestUrl = BuildUrlWithQueryParams(mainUrl);

            var response = await _client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Series>>(jsonString);
                return result;
            }
            else
            {
                IsError = true;
                ErrorMessage = response.ReasonPhrase;
                throw new Exception(ErrorMessage);
            }
        }

        // Add parameters to url
        private string BuildUrlWithQueryParams(string url)
        {
            var builder = new UriBuilder(url);
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            query[_apiKeyQuery] = _apiKey;
            builder.Query = query.ToString();
            return builder.ToString();
        }
    }
}
