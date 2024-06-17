namespace TokenTestingBlazor.Models
{
    /// <summary>
    /// GraphQL request object for serializing/deserializing to JSON
    /// </summary>
    public class GraphQLRequest
    {
        public string query { get; set; }
        public string operationName { get; set; }
        public Dictionary<string, string> variables { get; set; }
    }
}
