using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using GitHubUserSearch.BusinessLogic;
using GitHubUserSearch.BusinessLogic.Models;
using GitHubUserSearch.Common;
using GitHubUserSearch.Models;

namespace GitHubUserSearch.Controllers.Api
{
    public class GitHubServiceController : ApiController
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpPost]
        public HttpResponseMessage GetUser([FromBody]User user)
        {
            var vm = new GitHubUserViewModel();
            var msg = new JsonMsg();
            var formatter = new JsonMediaTypeFormatter();

            try
            {
                if (string.IsNullOrEmpty(user.UserName))
                    throw new ArgumentNullException("UserName", "Username cannot be empty");

                    var gitHubUser = new UserService(new ApiHelper());
                    var reposToDisplay = Convert.ToInt32(ConfigurationManager.AppSettings["UserReposToDisplay"]);

                    GitHubUserModel userDetails = gitHubUser.GetUserDetails(user.UserName);

                    vm.UserName = userDetails.UserName;
                    vm.AvatarUrl = userDetails.AvatarUrl;
                    vm.Location = userDetails.Location;
                    vm.GitHubRepositories = gitHubUser.GetTopXRepos(userDetails.GitHubRepositories, reposToDisplay)
                                                .Select(item => new GitHubRepoViewModel()
                                                    { RepositoryName = item.RepositoryName,
                                                      RepositoryUrl = item.RepositoryUrl,
                                                      StarGazersCount = item.StarGazersCount}).ToList();

                    msg.result = !string.IsNullOrEmpty(vm.UserName);
                    msg.data = vm;
                    return Request.CreateResponse(HttpStatusCode.OK, msg, formatter);
            }

            catch (Exception ex)
            {
                Log.Error(ex);
                var errorMessage = ex.InnerException.ToString();
                return Request.CreateResponse(errorMessage.Contains("404") ? HttpStatusCode.OK : HttpStatusCode.BadRequest, msg, formatter);
            }
        }
    }

}
