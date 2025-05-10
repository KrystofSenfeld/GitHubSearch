using System.Text.Json.Serialization;

namespace GitHubSearch.Models.JSON.Repos {
    public class RepoResponseModel {
        public string Title { get; set; }
        public string Description { get; set; }

        [JsonPropertyName("stargazers_count")]
        public int StargazersCount { get; set; }
    }
}