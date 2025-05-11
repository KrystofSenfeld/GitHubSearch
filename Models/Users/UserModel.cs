using System.Collections.Generic;

namespace GitHubSearch.Models.Users {
    public class UserModel {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Url { get; set; }
        public string AvatarUrl { get; set; }
        public List<UserRepoModel> Repos { get; set; }

        public bool HasRepos => Repos != null && Repos.Count > 0;
    }
}