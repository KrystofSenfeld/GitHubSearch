using GitHubSearch.Models.DTO;

namespace GitHubSearch.Models.Users {
    public class UserSearchResultViewModel : ViewModelBase {
        public UserDto User { get; set; }
        public bool HasRepos => User?.Repos != null && User.Repos.Count > 0;
    }
}