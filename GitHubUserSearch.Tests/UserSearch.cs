using System;
using System.Collections.Generic;
using GitHubUserSearch.BusinessLogic;
using GitHubUserSearch.BusinessLogic.Models;
using GitHubUserSearch.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GitHubUserSearch.Tests
{
    [TestClass]
    public class UserSearch
    {
        [TestMethod]
        public void GetRealUserDetails()
        {
            //Act
            var gitHubUser = new UserService(new ApiHelper());

            //Arrange
            GitHubUserModel userDetails = gitHubUser.GetUserDetails("jskeet");

            //Assert
            Assert.AreEqual(userDetails.UserName, "jskeet");
            Assert.AreEqual(userDetails.Location, "London, UK");
            Assert.AreEqual(userDetails.AvatarUrl, "https://avatars1.githubusercontent.com/u/17011?v=4");
        }

        [TestMethod]
        public void CheckGitHubUserDetails()
        {
            var adapter = new ApiHelper();

            var gitHubUser = adapter.GetGitHubApiData<GitHubUser>(string.Format("https://api.github.com/users/{0}","jskeet"));

            Assert.AreEqual(gitHubUser.UserName, "jskeet");
            Assert.AreEqual(gitHubUser.Location, "London, UK");
            Assert.AreEqual(gitHubUser.AvatarUrl, "https://avatars1.githubusercontent.com/u/17011?v=4");
            Assert.AreEqual(gitHubUser.UsersReposUrl, "https://api.github.com/users/jskeet/repos");
        }

        [TestMethod]
        public void CheckGitHubUserRepoDetails()
        {
            var adapter = new ApiHelper();

            var gitHubRepo = adapter.GetGitHubApiData<List<GitHubRepo>>(string.Format("https://api.github.com/users/{0}/repos", "jskeet"));

            Assert.IsNotNull(gitHubRepo);
            Assert.IsTrue(gitHubRepo.Count > 0, "gitHubRepo should have more than zero repos");

        }


        [TestMethod]
        public void GetFakeUserDetails()
        {
            var gitHubUser = new UserService(new FakeApiAdapter());

            GitHubUserModel userDetails = gitHubUser.GetUserDetails("abc");

            Assert.AreEqual(userDetails.UserName, "ABC");
            Assert.AreEqual(userDetails.Location, "england");


        }

        [TestMethod]
        public void CheckFakeAdapterGitHubRepo()
        {
            var adapter = new FakeApiAdapter();

            var gitHubRepo = adapter.GetGitHubApiData<List<GitHubRepo>>(string.Format("abc"));

            Assert.IsNotNull(gitHubRepo);
            Assert.IsTrue(gitHubRepo.Count > 0, "gitHubRepo should have more than zero repos");

        }

        [TestMethod]
        public void CheckFakeAdapterGitHubUser()
        {
            var adapter = new FakeApiAdapter();

            var gitHubUser= adapter.GetGitHubApiData<GitHubUser>(string.Format("abc"));

            Assert.AreEqual(gitHubUser.UserName, "ABC");
            Assert.AreEqual(gitHubUser.Location, "england");
            Assert.AreEqual(gitHubUser.AvatarUrl, "http://www.example.com");
        }



    }
}
