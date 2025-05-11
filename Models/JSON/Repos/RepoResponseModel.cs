using Newtonsoft.Json;

namespace GitHubSearch.Models.JSON.Repos {
    public class RepoResponseModel {
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonProperty("html_url")]
        public string Url { get; set; }

        [JsonProperty("stargazers_count")]
        public int StargazersCount { get; set; }
    }
}