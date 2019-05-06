using com.gameon.data.ThirdPartyApis.Interfaces;
using com.gameon.data.ThirdPartyApis.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace com.gameon.data.ThirdPartyApis.Repositories
{
    public class DotaApiRepository : IDotaApiRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        private IConfigurationSection _settings;
        private string _host;
        public IEnumerable<ProMatch> Schedule;
        public bool IsError = false;
        public string ErrorMessage;

        public DotaApiRepository(IConfiguration config, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _settings = config.GetSection("DotaApi");
            _host = _settings["Host"];
        }

        public async Task<IEnumerable<ProMatch>> GetSchedule()
        {
            var url = _host + _settings["Schedule"];

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "Game-On-Api");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Schedule = await response.Content.ReadAsAsync<IEnumerable<ProMatch>>();
                return Schedule;
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
