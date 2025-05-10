using System.Text.Json.Serialization;

namespace GitHubSearch.Models.JSON.Users {
    public class UserResponseModel {
        public string Name { get; set; }
        public string Location { get; set; }

        public string Url { get; set; }

        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonPropertyName("repos_url")]
        public string ReposUrl { get; set; }
    }
}