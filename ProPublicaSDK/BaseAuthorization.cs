using AutoMapper;
using ProPublicaSDK.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProPublicaSDK
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
                var uri = GetRequestUri(function);
                var response = client.GetAsync(uri).Result;
                return response.IsSuccessStatusCode
                    ? JsonSerializer.Deserialize<T>(response.Content.ReadAsStringAsync().Result)
                    : default;
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
                var uri = GetRequestUri(function);
                var response = await client.GetAsync(uri);
                return response.IsSuccessStatusCode
                       ? JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync())
                       : default;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }
    }
}
