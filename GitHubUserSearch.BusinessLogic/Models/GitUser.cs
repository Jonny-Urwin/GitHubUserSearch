using Newtonsoft.Json;

namespace GitHubUserSearch.BusinessLogic.Models
{
    public class GitUser
    {
      
        [JsonProperty("login")]
        public string UserName { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
    }
}