using System.Net;

namespace GitHubSearch.Models.JSON {
    public class ApiResponse<T> {
        public HttpStatusCode StatusCode { get; set; }
        public bool WasSuccessful { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
}