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
    public class EsportsApiService : IEsportsApiService
    {
        private readonly HttpClient _client;
        private IConfigurationSection _settings;
        private string _host;
        private string _apiKey;
        private string _apiKeyQuery;

        public EsportsApiService(IConfiguration config, HttpClient client)
        {
            _client = client;
            _settings = config.GetSection("EsportsApi");
            _host = _settings["Host"];
            _apiKey = _settings["ApiKeyValue"];
            _apiKeyQuery = _settings["ApiKeyQuery"];

            _client.BaseAddress = new Uri(_host);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("User-Agent", "Game-On-Api");
        }

        public async Task<List<EsportsTournament>> GetTournamentsAsync(string game = null, string timeFrame = null)
        {
            // Create the main url pathway
            var mainUrl = _host;
            if (game == null) mainUrl += _settings[game];
            mainUrl += _settings["Tournaments"];
            if (timeFrame != null) mainUrl += "/" + timeFrame;

            string requestUrl = (timeFrame == "upcoming") ? BuildUrlWithQueryParams(mainUrl, sortBy: "begin_at")
                : BuildUrlWithQueryParams(mainUrl);
            requestUrl += "&per_page=100";

            var response = await _client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<EsportsTournament>>(jsonString);
                return result;
            }
            else throw new Exception(response.ReasonPhrase);
        }

        public async Task<List<EsportsTeam>> GetTeamsAsync(string game)
        {
            // Create the main url pathway
            var mainUrl = _host + _settings[game] + _settings["Teams"];
            string requestUrl = BuildUrlWithQueryParams(mainUrl);

            var response = await _client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<EsportsTeam>>(jsonString);
                return result;
            }
            else throw new Exception(response.ReasonPhrase);
        }

        public async Task<List<Series>> GetSeriesAsync(string game)
        {
            // Create the main url pathway
            var mainUrl = _host + _settings[game] + _settings["Series"];
            string requestUrl = BuildUrlWithQueryParams(url: mainUrl, sortBy: "-end_at");

            var response = await _client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Series>>(jsonString);
                return result;
            }
            else throw new Exception(response.ReasonPhrase);
        }

        public async Task<List<Match>> GetMatchesAsync(string game = null, string timeFrame = null)
        {
            // Create the main url pathway
            var mainUrl = _host;
            if (game != null) mainUrl += _settings[game];
            mainUrl += _settings["Matches"];
            if (timeFrame != null) mainUrl += "/" + timeFrame;

            string requestUrl = (timeFrame == "upcoming") ? BuildUrlWithQueryParams(mainUrl, sortBy: "begin_at")
                : BuildUrlWithQueryParams(mainUrl);
                //: BuildUrlWithQueryParams(mainUrl, sortBy: "-begin_at", thenBy: "-end_at");
            requestUrl += "&per_page=100";
            var response = await _client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Match>>(jsonString);
                return result;
            }
            else throw new Exception(response.ReasonPhrase);
        }

        // Separate to GetMatchesAsync since having a tournamentId means needing a game specified
        public async Task<List<Match>> GetTournamentMatchesAsync(string game, int tournamentId, string timeFrame = null)
        {
            // Create the main url pathway
            var mainUrl = _host + _settings[game] + _settings["Matches"];
            if (timeFrame != null) mainUrl += "/" + timeFrame;
            string requestUrl = BuildUrlWithQueryParams(mainUrl, tournamentId);

            var response = await _client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Match>>(jsonString);
                return result;
            }
            else throw new Exception(response.ReasonPhrase);
        }

        public async Task<List<LiveMatch>> GetLiveMatchesAsync()
        {
            // Create the main url pathway
            var mainUrl = _host + "/lives";
            string requestUrl = BuildUrlWithQueryParams(mainUrl, sortBy: "-begin_at");

            var response = await _client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<LiveMatch>>(jsonString);
                return result;
            }
            else throw new Exception(response.ReasonPhrase);
        }

        // Add parameters to url
        private string BuildUrlWithQueryParams(string url, int? tournamentId = null, string sortBy = null, string thenBy = null)
        {
            var builder = new UriBuilder(url);
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            query[_apiKeyQuery] = _apiKey;
            //query["filter[per_page]"] = "100";
            if (tournamentId.HasValue) query["filter[tournament_id]"] = tournamentId.Value.ToString();
            if (sortBy != null) query["sort"] = sortBy;
            if (thenBy != null) query["sort"] += "," + thenBy;
            builder.Query = query.ToString();
            return builder.ToString();
        }
    }
}
