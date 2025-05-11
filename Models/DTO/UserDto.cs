using System.Collections.Generic;

namespace GitHubSearch.Models.DTO {
    public class UserDto {
        public string Username { get; set; }
        public string Location { get; set; }
        public string Url { get; set; }
        public string AvatarUrl { get; set; }
        public List<UserRepoDto> Repos { get; set; }
    }
}