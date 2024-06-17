using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TokenTestingBlazor.Models;

namespace TokenTestingBlazor.Controllers
{
    /// <summary>
    /// Controller class for accessing the user's profile data.
    /// </summary>
    [ApiController]
    public class CanvasProfileController : ControllerBase
    {

        private readonly HttpClient _client = new HttpClient();

        /// <summary>
        /// Get the user's profile. Endpoint[GET]: /api/profile/getProfile
        /// </summary>
        /// <param name="token">Canvas refresh token</param>
        /// <returns>Canvas user</returns>
        [HttpGet, Route("api/profile")]
        public async Task<ActionResult<ServerCanvasProfileDTO>> GetCanvasProfileAsync([FromHeader] string token)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://davistech.instructure.com/api/v1/users/self/profile");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Authorization", "Bearer " + token);

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            return Ok(JsonSerializer.Deserialize<ServerCanvasProfileDTO>(response.Content.ReadAsStream()));
        }

    }
}
