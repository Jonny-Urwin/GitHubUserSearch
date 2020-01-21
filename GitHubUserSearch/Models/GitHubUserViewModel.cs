using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GitHubUserSearch.BusinessLogic.Models;


namespace GitHubUserSearch.Models
{
    public class GitHubUserViewModel
    {
        [Required]
        [StringLength(39, MinimumLength = 1, ErrorMessage = "Username must be between 1 and 39 characters in length.")]
        //[a-zA-Z0-9]+ - 1 or more alphanumeric characters
        //(?:-[a-zA-Z0-9]+)* 0 or more repetitions of - and then 1 or more  alphanumeric characters
        [RegularExpression("^[a-zA-Z0-9]+(?:-[a-zA-Z0-9]+)*$", ErrorMessage = "Username can only contain a-z A-Z 0-9 - and must not start with a dash")]
        public string UserName { get; set; }
        public string Location { get; set; }
        [RegularExpression("(http(s)?://)?([\\w-]+\\.)+[\\w-]+(/[\\w- ;,./?%&=]*)?", ErrorMessage = "")]
        public string AvatarUrl { get; set; }

        public IList<GitHubRepoViewModel> GitHubRepositories { get; set; }
    }

    public class GitHubRepoViewModel
    {
        public string RepositoryName { get; set; }
        public string RepositoryUrl { get; set; }
        public int StarGazersCount { get; set; }
    }


}