using GitHubSearch.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitHubSearch.Models.Users {
    public class IndexViewModel : ViewModelBase {
        public UserSearchDto UserSearch { get; set; }
    }
}