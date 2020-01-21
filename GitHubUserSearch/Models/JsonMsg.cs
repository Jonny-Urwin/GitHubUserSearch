using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GitHubUserSearch.Models
{
    public class JsonMsg
    {
        [DefaultValue(false)]
        public bool result;
        public string message;
        public dynamic data;
    }

}