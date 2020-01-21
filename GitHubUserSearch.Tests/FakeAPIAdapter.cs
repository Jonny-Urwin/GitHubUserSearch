using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitHubUserSearch.BusinessLogic.Models;
using GitHubUserSearch.Common;

namespace GitHubUserSearch.Tests
{
    public class FakeApiAdapter : IApiHelper
    {
        public T GetGitHubApiData<T>(string url)
        {
            object obj;
            Type listType = typeof(T);
            if (listType == typeof(GitHubUser))
            {
                obj = new GitHubUser()
                {
                    AvatarUrl = "http://www.example.com",
                    Location = "england",
                    UserName = "ABC"
                };
            }
            else
            {
                var gitHubRepo = new GitHubRepo()
                {
                    RepositoryUrl = "www.example.com",
                    RepositoryName = "example",
                    StarGazersCount = 20
                };

                var listOfRepos = new List<GitHubRepo>();
                listOfRepos.Add(gitHubRepo);
                obj = listOfRepos;
            }

            return (T)obj;

        }
    }
}
