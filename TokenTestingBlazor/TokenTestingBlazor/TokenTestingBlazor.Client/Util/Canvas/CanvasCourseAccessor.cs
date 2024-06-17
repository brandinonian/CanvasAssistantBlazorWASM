using System.Text.Json;
using TokenTestingBlazor.Client.Models;

namespace TokenTestingBlazor.Client
{
    /// <summary>
    /// Utility class for fetching Canvas courses.
    /// </summary>
    public class CanvasCourseAccessor
    {
        private HttpClient _client;
        private readonly string domain;

        public CanvasCourseAccessor(IConfiguration Config)
        {
            _client = new HttpClient();
            domain = Config["Domain"] ?? throw new ArgumentNullException($"{nameof(domain)}");
        }

        /// <summary>
        /// Fetches all Canvas courses for the user from the server API.
        /// </summary>
        /// <param name="token">Canvas access token</param>
        /// <returns>List of Canvas courses</returns>
        public async Task<List<CanvasCourseDTO>> GetAllCoursesAsync(string token)
        {
            var apiEndpoint = domain + "/api/courses/all";

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("token", token);

            var response = await _client.GetAsync(apiEndpoint);

            return JsonSerializer.Deserialize<List<CanvasCourseDTO>>(response.Content.ReadAsStream());
        }
    }
}
