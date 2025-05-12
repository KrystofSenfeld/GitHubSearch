using GitHubSearch.Controllers;
using GitHubSearch.Models.DTO;
using GitHubSearch.Models.Users;
using GitHubSearch.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GitHubSearch.Tests.Controllers {
    [TestClass]
    public class UsersControllerTest {

        #region Index

        [TestMethod]
        public void Index_NoError_ReturnsViewWithoutError() {
            UsersController controller = new UsersController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsInstanceOfType(result.Model, typeof(IndexViewModel));

            var resultModel = (IndexViewModel)result.Model;
            Assert.IsNull(resultModel.Error);
        }

        [TestMethod]
        public void Index_WithError_ReturnsViewWithError() {
            UsersController controller = new UsersController();

            ViewResult result = controller.Index("Test") as ViewResult;

            Assert.IsInstanceOfType(result.Model, typeof(IndexViewModel));

            var resultModel = (IndexViewModel)result.Model;
            Assert.IsNotNull(resultModel.Error);
        }

        [TestMethod]
        public void Index_WithTempData_TempDataPersists() {
            UsersController controller = new UsersController();
            var modelState = new ModelStateDictionary();
            modelState.AddModelError("Test", "Test Error Message");

            // Mock the LoadTempModelState action filter attribute
            var filter = new LoadTempModelState();
            var context = new ActionExecutingContext {
                Controller = controller,
            };

            context.Controller.TempData.Add("ModelState", modelState);

            filter.OnActionExecuting(context);
            controller.Index();

            Assert.IsTrue(controller.TempData.ContainsKey("ModelState"));
            Assert.IsFalse(controller.ModelState.IsValid);
        }

        #endregion

        #region Search

        [TestMethod]
        public void Search_NoUsername_ModelIsInvalid() {
            var userSearch = GetInvalidUserSearchDto();

            var context = new ValidationContext(userSearch);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(userSearch, context, results);

            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void Search_ValidState_RedirectsToSearchResult() {
            UsersController controller = new UsersController();
            var userSearch = GetValidUserSearchDto();

            var result = (RedirectToRouteResult)controller.Search(userSearch);

            Assert.AreEqual("SearchResult", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Search_InvalidState_RedirectsToIndex() {
            UsersController controller = new UsersController();
            controller.ModelState.AddModelError("Test", "Test Error Message");

            var userSearch = GetInvalidUserSearchDto();
            var result = (RedirectToRouteResult)controller.Search(userSearch);

            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        #endregion

        #region SearchResult

        [TestMethod]
        public async Task SearchResult_ValidUsername_ReturnsView() {
            UsersController controller = new UsersController();
            var userSearch = GetValidUserSearchDto();
            userSearch.Username = "octocat";

            var result = (await controller.SearchResult(userSearch)) as ViewResult;

            Assert.IsInstanceOfType(result.Model, typeof(UserSearchResultViewModel));

            var resultModel = (UserSearchResultViewModel)result.Model;
            Assert.IsNotNull(resultModel.User);
            Assert.IsTrue(resultModel.HasRepos);
        }

        [TestMethod]
        public async Task SearchResult_NoUsername_RedirectsToIndex() {
            UsersController controller = new UsersController();

            var userSearch = GetInvalidUserSearchDto();
            var result = (await controller.SearchResult(userSearch)) as RedirectToRouteResult;

            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public async Task SearchResult_InvalidUsername_RedirectsToIndex() {
            UsersController controller = new UsersController();
            var userSearch = GetInvalidUserSearchDto();

            // GitHub usernames can only contain alphanumeric characters, so the below should
            // never be found as a valid GitHub username.
            userSearch.Username = "#";

            var result = (await controller.SearchResult(userSearch)) as RedirectToRouteResult;

            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        #endregion

        #region Utility

        private UserSearchDto GetValidUserSearchDto() {
            return new UserSearchDto {
                Username = "Test",
            };
        }

        private UserSearchDto GetInvalidUserSearchDto() {
            return new UserSearchDto {
                Username = string.Empty,
            };
        }

        #endregion
    }
}
