using com.gameon.data.ThirdPartyApis.Interfaces;
using com.gameon.data.ThirdPartyApis.Models.Nba;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace com.gameon.data.ThirdPartyApis.Services
{
    public class NbaApiService : INbaApiService
    {
        private readonly HttpClient _client;
        private IConfigurationSection _settings;
        private string _host;

        public NbaApiService(IConfiguration config, HttpClient client)
        {
            _client = client;
            _settings = config.GetSection("NbaApi");
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

        public async Task<List<NbaGame>> GetNbaScheduleAsync()
        {
            var path = _settings["Schedule"];
            var response = await _client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<NbaApi>(jsonString);
                return result.Api.Games;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound) return new List<NbaGame>();
            else throw new Exception(response.ReasonPhrase);
        }

        public async Task<List<NbaGame>> GetNbaLiveGamesAsync()
        {
            string path = _settings["Live"];
            var response = await _client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<NbaApi>(jsonString);
                return result.Api.Games;
            } 
            else if (response.StatusCode == HttpStatusCode.NotFound) return new List<NbaGame>();
            else throw new Exception(response.ReasonPhrase); 
        }

        public async Task<List<NbaGame>> GetNbaGames(DateTime? datetime = null)
        {
            string path;
            if (datetime == null) path = _settings["Schedule"];
            else
            {
                var date = datetime.Value;
                var day = (date.Day < 10) ? "0" + date.Day : date.Day.ToString();
                var month = (date.Month < 10) ? "0" + date.Month : date.Month.ToString();
                var dateString = date.Year + "-" + month + "-" + day;
                path = _settings["Games"].Replace("{date}", dateString);
            }

            var response = await _client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<NbaApi>(jsonString);
                return result.Api.Games;
            } 
            else if (response.StatusCode == HttpStatusCode.NotFound) return new List<NbaGame>();
            else throw new Exception(response.ReasonPhrase); 
        }

        public async Task<List<NbaTeam>> GetNbaTeamsAsync()
        {
            var path = _settings["Teams"];
            var response = await _client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<NbaApi>(jsonString);
                return result.Api.Teams.FindAll(t => t.NbaFranchise == "1");
            }
            else throw new Exception(response.ReasonPhrase);
        }
    }
}
