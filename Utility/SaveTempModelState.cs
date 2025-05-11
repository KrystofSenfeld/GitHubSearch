using System.Web.Mvc;

namespace GitHubSearch.Utility {
    public class SaveTempModelState : ActionFilterAttribute {
        public override void OnActionExecuted(ActionExecutedContext filterContext) {
            base.OnActionExecuted(filterContext);
            filterContext.Controller.TempData["ModelState"] = filterContext.Controller.ViewData.ModelState;
        }
    }
}