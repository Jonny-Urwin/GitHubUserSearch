using Newtonsoft.Json;

namespace GitHubUserSearch.BusinessLogic.Models
{
    public class GitHubRepo
    {
        [JsonProperty("name")]
        public string RepositoryName { get; set; }
        [JsonProperty("html_url")]
        public string RepositoryUrl { get; set; }
        [JsonProperty("stargazers_count")]
        public int StarGazersCount { get; set; }
    }
}

