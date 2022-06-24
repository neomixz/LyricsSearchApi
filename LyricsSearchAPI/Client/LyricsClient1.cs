using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

using LyricsSearchAPI.Constant;
using LyricsSearchAPI.Model;
using Newtonsoft.Json;

namespace LyricsSearchAPI.Client
{
    public class LyricsClient1
    {
        private HttpClient _httpClient;
        private string _address;

        public LyricsClient1()
        {
            _httpClient = new HttpClient();
            _address = Constants.address;
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", "57d87350b0msh1b6350ce649b1b0p13fd04jsne6bf1ef73376");
            _httpClient.BaseAddress = new Uri(_address);
        }

        public async Task<List<ArtistByLetterResponseModel>> GetArtistByLetterAsync(string word)
        {
            var response = await _httpClient.GetAsync($"/artists/name/{word}");
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<List<ArtistByLetterResponseModel>>(content);
            return result;            
        }
        public async Task<List<ArtistMusicResponseModel>> GetArtistMusicAsync(string artist)
        {
            var response = await _httpClient.GetAsync($"/artists/{artist}");
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<List<ArtistMusicResponseModel>>(content);
            return result;
        }
        public async Task<List<LyricsResponseModel>> GetLyricsAsync(string artist, string song)
        {
            var response = await _httpClient.GetAsync($"/{artist}/{song}");
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<List<LyricsResponseModel>>(content);
            return result;
        }
    }
}
