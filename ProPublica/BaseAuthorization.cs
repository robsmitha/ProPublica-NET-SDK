using AutoMapper;
using ProPublica.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProPublica
{
    public class BaseAuthorization
    {
        private const string Endpoint = "https://api.propublica.org/congress/v1";
        private string ApiKey { get; set; }
        protected readonly IMapper _mapper;
        public BaseAuthorization(string apiKey)
        {
            ApiKey = apiKey;

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            _mapper = mappingConfig.CreateMapper();
        }

        private string GetRequestUri(string function) => Endpoint + (!function.StartsWith("/") ? $"/{function}" : function);
        public T Send<T>(string function)
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            try
            {
                var requestUri = GetRequestUri(function);
                var response = client.GetAsync(requestUri).Result;
                if (response.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<T>(response.Content.ReadAsStringAsync().Result);
                }
                return default;
                
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }

        public async Task<T> SendAsync<T>(string function)
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
            try
            {
                var requestUri = GetRequestUri(function);
                var response = await client.GetAsync(requestUri);
                if (response.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
                }
                return default;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }
    }
}
