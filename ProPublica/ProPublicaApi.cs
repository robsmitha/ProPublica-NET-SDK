using ProPublica.Entities;
using ProPublica.Entities.Members;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProPublica
{
    public class ProPublicaApi
    {
        private string Endpoint { get; set; }
        private string APIKey { get; set; }

        public ProPublicaApi(string endpoint, string apiKey = null)
        {
            Endpoint = endpoint;
            APIKey = apiKey;
        }

        private string FormatRequestUri(string function) => Endpoint + (!function.StartsWith("/") ? $"/{function}" : function);
        
        private T SendRequest<T>(string function)
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-API-Key", APIKey);
            try
            {
                var requestUri = FormatRequestUri(function);
                var response = client.GetStringAsync(requestUri).Result;
                return JsonSerializer.Deserialize<T>(response);
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }

        private async Task<T> SendRequestAsync<T>(string function)
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-API-Key", APIKey);
            try
            {
                var requestUri = FormatRequestUri(function);
                var response = await client.GetStringAsync(requestUri);
                return JsonSerializer.Deserialize<T>(response);
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }

        public async Task<Response<IEnumerable<MemberListResult>>> GetMembers(string congress, string chamber)
        {
            return await SendRequestAsync<Response<IEnumerable<MemberListResult>>>($"{congress}/{chamber}/members.json");
        }
    }
}
