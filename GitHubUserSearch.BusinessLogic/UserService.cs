using System;
using System.Collections.Generic;
using System.Linq;
using GitHubUserSearch.BusinessLogic.Interface;
using GitHubUserSearch.BusinessLogic.Models;
using GitHubUserSearch.Common;

namespace GitHubUserSearch.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IApiHelper _apiHelper;

        public UserService(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        private string GetApiLink(string userName)
        {
            if (userName != null)
            {
                return $"https://api.github.com/users/{userName}";
            }
            throw new Exception("Missing User Name");
        }

        /// <summary>
        /// Returns a number of required repos
        /// </summary>
        /// <param name="gitHubUserRepos"></param>
        /// <param name="numberOfRepos"></param>
        /// <returns></returns>
        public IList<GitHubRepo> GetTopXRepos(IList<GitHubRepo> gitHubUserRepos, int numberOfRepos)
        {
            return gitHubUserRepos.OrderByDescending(x => x.StarGazersCount).Take(numberOfRepos).ToList();
        }


        /// <summary>
        /// Returns user details from the http client call
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public GitHubUserModel GetUserDetails(string userName)
        {
            string uri = GetApiLink(userName);

            var gitHubUser = _apiHelper.GetGitHubApiData<GitHubUser>(uri);

            var gitHubUserRepos = _apiHelper.GetGitHubApiData<List<GitHubRepo>>(gitHubUser.UsersReposUrl);

            var gitHubUserModel = new GitHubUserModel()
            {
                UserName = gitHubUser.UserName,
                AvatarUrl = gitHubUser.AvatarUrl,
                Location = gitHubUser.Location,
                GitHubRepositories = gitHubUserRepos
            };
           
            return gitHubUserModel;
        }
    }
}
