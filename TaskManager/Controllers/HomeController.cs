using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;
using System.IO;
using PagedList;
using PagedList.Mvc;

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

        public ActionResult Index(int? page=1)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var tasks = context.Task.ToList();
            return View(tasks.ToPagedList(pageNumber,pageSize));
        }

        public ActionResult TaskView(int id)
        {
            var task = context.Task.Find(id);
            return View(task);
        }
    }
}
