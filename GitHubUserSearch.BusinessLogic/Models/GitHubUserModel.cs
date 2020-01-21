using System.Collections.Generic;


namespace GitHubUserSearch.BusinessLogic.Models
{
    public class GitHubUserModel : GitUser
    { 
        public IList<GitHubRepo> GitHubRepositories { get; set; }
    }


}