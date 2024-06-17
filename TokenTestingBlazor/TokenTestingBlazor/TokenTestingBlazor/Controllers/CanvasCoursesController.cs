using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
using TokenTestingBlazor.Models;

namespace TokenTestingBlazor.Controllers
{
    /// <summary>
    /// Controller class for fetching Canvas course data.
    /// </summary>
    [Route("api/courses")]
    [ApiController]
    public class CanvasCoursesController : ControllerBase
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly Uri _endpoint = new Uri("https://davistech.instructure.com/api/graphql");

        /// <summary>
        /// Fetches all Canvas courses for a user. Endpoint[GET]: /api/courses/all
        /// </summary>
        /// <param name="token"></param>
        /// <returns>List of Canvas courses</returns>
        [HttpGet, Route("all")]
        public async Task<ActionResult> GetAllCoursesAsync([FromHeader] string token)
        {
            GraphQLRequest gql = new GraphQLRequest
            {
                query = "query GetAllCourses {\n\tallCourses {\n\t\tid\n\t\tname\n\t}\n}",
                operationName = "getAllCourses",
                variables = null
            };

            StringContent json = new (JsonSerializer.Serialize(gql), new MediaTypeHeaderValue("application/graphql"));

            Console.WriteLine(await json.ReadAsStringAsync());

            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            HttpResponseMessage response = await _client.PostAsync(_endpoint, json);

            response.EnsureSuccessStatusCode();

            var resJson = await response.Content.ReadAsStringAsync();
            Console.WriteLine(resJson);

            return Ok();
            //return Ok(JsonSerializer.Deserialize<List<ServerCanvasCourseDTO>>(response.Content.ReadAsStream()));
        }
    }
}
