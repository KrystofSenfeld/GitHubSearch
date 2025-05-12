using GitHubSearch.Models.DTO;
using GitHubSearch.Models.Users;
using GitHubSearch.Services;
using GitHubSearch.Utility;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GitHubSearch.Controllers {
    public class UsersController : Controller {
        [LoadTempModelState]
        public ActionResult Index(string searchError = null) {
            var viewModel = new IndexViewModel {
                Title = "User Search",
                Error = searchError,
                UserSearch = new UserSearchDto(),
            };

            return View(viewModel);
        }

        [HttpPost]
        [SaveTempModelState]
        public ActionResult Search(UserSearchDto model) {
            if (!ModelState.IsValid) {
                return RedirectToAction("Index");
            }

            return RedirectToAction("SearchResult", model);
        }

        public async Task<ActionResult> SearchResult(UserSearchDto model) {
            if (model == null || string.IsNullOrEmpty(model.Username)) {
                return RedirectToAction("Index");
            }

            var viewModel = new UserSearchResultViewModel();

            using (var client = new GitHubClient()) {
                var user = new UserDto();
                var userResponse = await client.GetUserByUsername(model.Username);

                if (!userResponse.WasSuccessful) {
                    return RedirectToAction("Index", "Users",
                        new { searchError = $"The user '{model.Username}' could not be found." });
                }

                user.Username = userResponse.Result.Username;
                user.Url = userResponse.Result.Url;
                user.AvatarUrl = userResponse.Result.AvatarUrl;
                user.Location = userResponse.Result.Location;

                var reposResponse = await client.GetUserReposByAbsoluteUrl(userResponse.Result.ReposUrl);

                if (reposResponse.WasSuccessful) {
                    user.Repos = reposResponse.Result
                        .OrderByDescending(r => r.StargazersCount)
                        .Take(5)
                        .Select(r => new UserRepoDto {
                            Name = r.Name,
                            Url = r.Url,
                            Description = r.Description,
                            StargazersCount = r.StargazersCount,
                        })
                        .ToList();
                }

                viewModel.User = user;
                viewModel.Title = $"User Search: {model.Username}";
            }

            return View(viewModel);
        }
    }
}