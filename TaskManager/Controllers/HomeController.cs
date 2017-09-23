using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;
using System.IO;

namespace TaskManager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private TaskContext context;

        public HomeController()
        {
            context = new TaskContext();
        }

        public ActionResult Index()
        {
            var tasks = context.Task.OrderBy(c => c.Id).Take(3);
            return View(tasks);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult LoadMoreTasks(int size)
        {
            var model = context.Task.OrderBy(p => p.Id).Skip(size).Take(3);
            int modelCount = context.Task.Count();
            if (model.Any())
            {
                string modelString = RenderRazorViewToString("_LoadMoreTasks", model);
                return Json(new { ModelString = modelString, ModelCount = modelCount });
            }
            return Json(model);
        }

        public string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext =
                     new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        public ActionResult TaskView(int id)
        {
            var task = context.Task.Find(id);
            return View(task);
        }
    }
}
