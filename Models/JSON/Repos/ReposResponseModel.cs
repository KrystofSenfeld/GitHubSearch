using System.Text.Json.Serialization;

namespace GitHubSearch.Models.JSON.Repos {
    public class ReposResponseModel {
        [JsonPropertyName("items")]
        public RepoResponseModel[] Repos { get; set; }
    }
}