using GitHubSearch.Models.Users;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GitHubSearch.Controllers {
    public class UsersController : Controller {
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult Search(UserSearchModel model) {
            if (!ModelState.IsValid) {
                return RedirectToAction("Index");
            }

            return RedirectToAction("UserSearchResult");
        }

        public ActionResult UserSearchResult() {
            return View();
        }
    }
}