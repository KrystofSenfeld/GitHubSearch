using System.ComponentModel.DataAnnotations;

namespace GitHubSearch.Models.DTO {
    public class UserSearchDto {
        [Required(ErrorMessage = "Please provide a username.")]
        public string Username { get; set; }
    }
}