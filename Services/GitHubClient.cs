using GitHubSearch.Models.JSON;
using GitHubSearch.Models.JSON.Repos;
using GitHubSearch.Models.JSON.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GitHubSearch.Services {
    public class GitHubClient : HttpClient {
        string apiBaseUrl = "https://api.github.com/";

        public GitHubClient() {
            BaseAddress = new Uri(apiBaseUrl);
            DefaultRequestHeaders.Clear();
            DefaultRequestHeaders.Add("User-Agent", "GitHub Search");
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
        }

        public async Task<ApiResponse<T>> GetAsync<T>(string url, bool isUrlAbsolute = false) {
            if (!isUrlAbsolute) {
                url = apiBaseUrl + url;
            }

            var response = await base.GetAsync(url);
            var responseModel = new ApiResponse<T>();

            responseModel.StatusCode = response.StatusCode;
            responseModel.WasSuccessful = response.IsSuccessStatusCode;
            responseModel.Message = response.ReasonPhrase;

            if (response.IsSuccessStatusCode) {
                var data = await response.Content.ReadAsStringAsync();
                responseModel.Result = JsonConvert.DeserializeObject<T>(data);
            }

            return responseModel;
        }

        public async Task<ApiResponse<UserResponseModel>> GetUserByUsername(string username) {
            return await GetAsync<UserResponseModel>($"users/{username}");
        }

        public async Task<ApiResponse<List<RepoResponseModel>>> GetUserReposByAbsoluteUrl(string url) {
            return await GetAsync<List<RepoResponseModel>>(url, true);
        }
    }
}