﻿using System.Web.Mvc;

namespace GitHubSearch.Utility {
    public class LoadTempModelState : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            base.OnActionExecuting(filterContext);

            if (filterContext.Controller.TempData.ContainsKey("ModelState")) {
                filterContext.Controller.ViewData.ModelState.Merge(
                    (ModelStateDictionary)filterContext.Controller.TempData["ModelState"]);
            }
        }
    }
}