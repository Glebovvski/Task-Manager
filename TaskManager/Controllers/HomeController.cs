using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;
using PagedList;
using PagedList.Mvc;

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
        public ActionResult Index(int? page)
        {
            var context = new TaskContext();
            var tasks = context.Task.OrderByDescending(c => c.LastModified).ToList();
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(tasks.ToPagedList(pageNumber,pageSize));
        }

    }
}
