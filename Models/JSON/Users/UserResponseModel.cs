﻿using Newtonsoft.Json;

namespace GitHubSearch.Models.JSON.Users {
    public class UserResponseModel {
        [JsonProperty("login")]
        public string Username { get; set; }
        public string Location { get; set; }

        [JsonProperty("html_url")]
        public string Url { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("repos_url")]
        public string ReposUrl { get; set; }
    }
}