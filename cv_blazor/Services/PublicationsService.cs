using System.Net.Http.Json;


namespace cv.Services
{
    public class PublicationService
    {
        private readonly HttpClient _httpClient;

        public PublicationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Method to get the list of publications
        public async Task<List<Publication>> GetPublicationsAsync()
        {
            var publications = await _httpClient.GetFromJsonAsync<List<Publication>>("data/abstracts.json");
            return publications ?? new List<Publication>();
        }
    }

    // Publication model
    public class Publication
    {
        public string Title { get; set; } = string.Empty;
        public string Abstract { get; set; } = string.Empty;
    }
}
