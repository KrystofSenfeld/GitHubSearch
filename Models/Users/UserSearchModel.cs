using System.ComponentModel.DataAnnotations;

namespace GitHubSearch.Models.Users {
    public class UserSearchModel {
        [Required(ErrorMessage = "Please provide a username.")]
        public string Username { get; set; }
    }
}