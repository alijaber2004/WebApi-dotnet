using Artists_Reviews.Models;
using System.Text.Json;

namespace Artists_Reviews.Services
{
    public class ArtistService
    {
        private readonly HttpClient _httpClient;

        public ArtistService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Artist>> GetArtistsFromApiAsync()
        {
            var response = await _httpClient.GetStringAsync("https://api.deezer.com/chart/0/artists");
            var json = JsonDocument.Parse(response);
            var artistList = json.RootElement.GetProperty("data")
                .EnumerateArray()
                .Select(static a => new Artist
                {
                    Id = a.GetProperty("id").GetInt32(),
                    Position = a.GetProperty("position").GetInt32(),
                    Name = a.GetProperty("name").GetString(),
                    PictureUrl = a.GetProperty("picture_medium").GetString()
                })
                .ToList();
            return artistList;
        }
    }
}
