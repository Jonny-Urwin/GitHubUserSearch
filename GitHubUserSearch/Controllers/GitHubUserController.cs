using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using GitHubUserSearch.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Web.Compilation;
using GitHubUserSearch.BusinessLogic;
using GitHubUserSearch.BusinessLogic.Models;
using AutoMapper;
using GitHubUserSearch.Common;
using Microsoft.Ajax.Utilities;

namespace GitHubUserSearch.Controllers
{
    public class GitHubUserController : Controller
    {
        [HttpGet]
        public ActionResult GetUser()
        {
            return View(new GitHubUserViewModel());
        }
    }
}