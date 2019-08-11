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
        private string _apiKey;
        private string _apiKeyQuery;

        public TennisApiService(IConfiguration config, HttpClient client)
        {
            _client = client;
            _settings = config.GetSection("TennisApi");
            _host = _settings["Host"];
            _apiKey = _settings["ApiKeyValue"];
            _apiKeyQuery = _settings["ApiKeyQuery"];

            _client.BaseAddress = new Uri(_host);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("User-Agent", "Game-On-Api");
        }

        public async Task<List<TennisTournament>> GetTournamentsAsync()
        {
            // Create the main url pathway
            var mainUrl = _host + _settings["Tournaments"];
            var requestUrl = BuildUrlWithQueryParams(mainUrl);

            var response = await _client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TournamentsApi>(jsonString);
                return result.Tournaments;
            }
            else throw new Exception(response.ReasonPhrase);
        }

        public async Task<InfoApi> GetTournamentInfoAsync(string id)
        {
            // Create the main url pathway
            var mainUrl = _host + _settings["TournamentInfo"].Replace("{id}", id);
            var requestUrl = BuildUrlWithQueryParams(mainUrl);

            var response = await _client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<InfoApi>(jsonString);
                return result;
            }
            else throw new Exception(response.ReasonPhrase);
        }

        public async Task<List<SportEvent>> GetTournamentScheduleAsync(string id)
        {
            // Create the main url pathway
            var mainUrl = _host +  _settings["TournamentSchedule"].Replace("{id}", id);
            var requestUrl = BuildUrlWithQueryParams(mainUrl);

            var response = await _client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ScheduleApi>(jsonString);
                return result.SportEvents;
            }
            else throw new Exception(response.ReasonPhrase);
        }

        public async Task<List<SportEvent>> GetDayScheduleAsync(DateTime? datetime = null)
        {
            // Create date string to be used in request url
            var date = (datetime == null) ? DateTime.UtcNow : datetime.Value;
            var day = (date.Day < 10) ? "0" + date.Day : date.Day.ToString();
            var month = (date.Month < 10) ? "0" + date.Month : date.Month.ToString();
            var dateString = date.Year + "-" + month + "-" + day;

            // Create the request url
            var mainUrl = _host + _settings["DaySchedule"].Replace("{date}", dateString);
            var requestUrl = BuildUrlWithQueryParams(mainUrl);

            var response = await _client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<DailyScheduleApi>(jsonString);
                return result.SportEvents;
            }
            else throw new Exception(response.ReasonPhrase);
        }

        public async Task<List<AssociationRankings>> GetPlayerRankingsAsync()
        {
            // Create the main url pathway
            var mainUrl = _host + _settings["PlayerRankings"];
            var requestUrl = BuildUrlWithQueryParams(mainUrl);

            var response = await _client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<RankingsApi>(jsonString);
                return result.Rankings;
            }
            else throw new Exception(response.ReasonPhrase);
        }

        private string BuildUrlWithQueryParams(string mainUrl)
        {
            var builder = new UriBuilder(mainUrl);
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            query[_apiKeyQuery] = _apiKey;
            builder.Query = query.ToString();
            return builder.ToString();
        }
    }
}
