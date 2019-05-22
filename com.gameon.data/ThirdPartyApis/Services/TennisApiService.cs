using com.gameon.data.ThirdPartyApis.Interfaces;
using com.gameon.data.ThirdPartyApis.Models.Tennis;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace com.gameon.data.ThirdPartyApis.Services
{
    public class TennisApiService : ITennisApiService
    {
        private readonly HttpClient _client;
        private IConfigurationSection _settings;
        private string _host;
        private string _common;
        private string _apiKey;
        public bool IsError = false;
        public string ErrorMessage;

        public TennisApiService(IConfiguration config, HttpClient client)
        {
            _client = client;
            _settings = config.GetSection("TennisApi");
            _host = _settings["Host"];
            _common = _settings["Common"];
            _apiKey = _settings["ApiKey"];

            _client.BaseAddress = new Uri(_host);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("User-Agent", "Game-On-Api");
        }

        public async Task<List<Tournament>> GetTournaments()
        {
            // Create the main url pathway
            var mainUrl = _host + _common + _settings["Tournaments"] + ".json";

            // Add parameters to url
            var builder = new UriBuilder(mainUrl);
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["api_key"] = _apiKey;
            builder.Query = query.ToString();
            string requestUrl = builder.ToString();

            var response = await _client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TournamentsApi>(jsonString);
                return result.Tournaments;
            }
            else
            {
                IsError = true;
                ErrorMessage = response.ReasonPhrase;
                return null;
            }
        }

        public async Task<InfoApi> GetTournamentInfo(string id)
        {
            // Create the main url pathway
            var mainUrl = _host + _common + _settings["Tournaments"] + "/" + id + _settings["Info"] + ".json";

            // Add parameters to url
            var builder = new UriBuilder(mainUrl);
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["api_key"] = _apiKey;
            builder.Query = query.ToString();
            string requestUrl = builder.ToString();

            var response = await _client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<InfoApi>(jsonString);
                return result;
            }
            else
            {
                IsError = true;
                ErrorMessage = response.ReasonPhrase;
                return null;
            }
        }

        public async Task<List<SportEvent>> GetTournamentSchedule(string id)
        {
            // Create the main url pathway
            var mainUrl = _host + _common + _settings["Tournaments"] + "/" + id + _settings["Schedule"] + ".json";

            // Add parameters to url
            var builder = new UriBuilder(mainUrl);
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["api_key"] = _apiKey;
            builder.Query = query.ToString();
            string requestUrl = builder.ToString();

            var response = await _client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ScheduleApi>(jsonString);
                return result.SportEvents;
            }
            else
            {
                IsError = true;
                ErrorMessage = response.ReasonPhrase;
                return null;
            }
        }

        //public async Task<List<Player>> GetPlayerRankings(string id)
        //{
        //    throw new NotImplementedException();
        //    // Create the main url pathway
        //    var mainUrl = _host + _common + _settings["Players"] + "/" + id + _settings["profile"] + ".json";

        //    // Add parameters to url
        //    var builder = new UriBuilder(mainUrl);
        //    builder.Port = -1;
        //    var query = HttpUtility.ParseQueryString(builder.Query);
        //    query["api_key"] = _apiKey;
        //    builder.Query = query.ToString();
        //    string requestUrl = builder.ToString();

        //    var response = await _client.GetAsync(requestUrl);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var jsonString = await response.Content.ReadAsStringAsync();
        //        var result = JsonConvert.DeserializeObject<ScheduleApi>(jsonString);
        //        return result.SportEvents;
        //    }
        //    else
        //    {
        //        IsError = true;
        //        ErrorMessage = response.ReasonPhrase;
        //        return null;
        //    }
        //}
    }
}
