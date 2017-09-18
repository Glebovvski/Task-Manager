using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult TaskView(int id)
        {
            var context = new TaskContext();
            var task = context.Task.Find(id);
            return View(task);
        }
        public ActionResult Index()
        {
            var context = new TaskContext();
            var tasks = context.Task.OrderByDescending(c => c.LastModified).ToList();
            return View(tasks);
        }

    }
}
