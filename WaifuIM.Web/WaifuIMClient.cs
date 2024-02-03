using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WaifuIM.Web.Models;
using WaifuIM.Web.Utilities;

namespace WaifuIM.Web
{
    public class WaifuIMClient
    {
        private readonly string _url = "https://api.waifu.im";
        private readonly string _acceptVersion = "v5";
        private static HttpClient _httpClient;

        public WaifuIMClient(string token)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Accept-Version", _acceptVersion);
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "WaifuIM-NET/1.0");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public WaifuIMClient()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Accept-Version", "v5");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "WaifuIM-NET/1.0");
        }
        
        public async Task<List<WaifuImage>> GetImages(SearchSettings settings = null)
        {
            string fullUrl = settings == null ? 
                string.Concat(_url, "/search") : 
                string.Concat(_url, "/search", QueryUtility.FormatQueryParams(settings));


            HttpResponseMessage message = await _httpClient.GetAsync(fullUrl);
            if (message.StatusCode == HttpStatusCode.OK)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<WaifuImageList>(response).Images;
            }

            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        public async Task<List<WaifuImage>> GetFavoriteImages(SearchSettings settings = null)
        {
            string fullUrl = settings == null ?
                string.Concat(_url, "/fav") :
                string.Concat(_url, "/fav", QueryUtility.FormatQueryParams(settings));


            HttpResponseMessage message = await _httpClient.GetAsync(fullUrl);
            if (message.StatusCode == HttpStatusCode.OK)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<WaifuImageList>(response).Images;
            }

            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        public async Task<WaifuFavoriteStatus> InsertFavoriteImage(FavoriteSettings settings)
        {
            string fullUrl = string.Concat(_url, "/fav/insert");
            var content = new StringContent(JsonConvert.SerializeObject(settings), Encoding.UTF8, "application/json");
            var message = await _httpClient.PostAsync(fullUrl, content);

            if (message.StatusCode == HttpStatusCode.OK)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<WaifuFavorite>(response).FavoriteStatus;
            }

            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        public async Task<WaifuFavoriteStatus> DeleteFavoriteImage(FavoriteSettings settings)
        {
            string fullUrl = string.Concat(_url, "/fav/delete");
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(fullUrl),
                Content = new StringContent(JsonConvert.SerializeObject(settings), Encoding.UTF8, "application/json")
            };
            var message = await _httpClient.SendAsync(request);
            
            if (message.StatusCode == HttpStatusCode.OK)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<WaifuFavorite>(response).FavoriteStatus;
            }

            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        public async Task<WaifuFavoriteStatus> ToggleFavoriteImage(FavoriteSettings settings)
        {
            string fullUrl = string.Concat(_url, "/fav/toggle");
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(fullUrl),
                Content = new StringContent(JsonConvert.SerializeObject(settings), Encoding.UTF8, "application/json")
            };
            var message = await _httpClient.SendAsync(request);

            if (message.StatusCode == HttpStatusCode.OK)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<WaifuFavorite>(response).FavoriteStatus;
            }

            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        public async Task<WaifuTagList> GetTags()
        {
            string fullUrl = string.Concat(_url, "/tags");


            HttpResponseMessage message = await _httpClient.GetAsync(fullUrl);
            if (message.StatusCode == HttpStatusCode.OK)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<WaifuTagList>(response);
            }

            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        public async Task<WaifuFullTagList> GetFullTags()
        {
            string fullUrl = string.Concat(_url, "/tags?full=true");


            HttpResponseMessage message = await _httpClient.GetAsync(fullUrl);
            if (message.StatusCode == HttpStatusCode.OK)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<WaifuFullTagList>(response);
            }

            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        private static T DeserializeObject<T>(string json)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new StringEnumConverter(new SnakeCaseNamingStrategy()));
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
