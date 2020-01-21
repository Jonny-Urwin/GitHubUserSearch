using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace GitHubUserSearch.BusinessLogic.Models
{
    public class GitHubUser : GitUser
    {
        [JsonProperty("repos_url")]
        public string UsersReposUrl { get; set; }
    }
}
