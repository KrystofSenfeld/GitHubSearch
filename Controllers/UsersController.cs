using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GitHubSearch.Controllers {
    public class UsersController : Controller {
        public ActionResult Index() {
            return View();
        }
    }
}