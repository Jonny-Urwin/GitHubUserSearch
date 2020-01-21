using System;
using System.Collections.Generic;
using System.Text;
using GitHubUserSearch.BusinessLogic.Models;

namespace GitHubUserSearch.BusinessLogic.Interface
{
    public interface IUserService
    {
        GitHubUserModel GetUserDetails(string userName);
    }
}
