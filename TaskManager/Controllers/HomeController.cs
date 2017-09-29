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

        public ActionResult Index(int? page = 1)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var tasks = context.Task.OrderByDescending(x=>x.LastModified).ToList();
            return View(tasks.ToPagedList(pageNumber,pageSize));
        }

        public ActionResult Search(string search, string type)
        {
            var tasksearch = new List<PersonalTask>();
            if (type.Contains("Title"))
            {
                tasksearch = context.Task.Where(s => s.Title.Contains(search)).ToList();
            }
            if (type.Contains("Tags"))
            {
                tasksearch = context.Task.Where(s => s.Tags.Contains(search)).ToList();
            }
            if (type.Contains("Content"))
            {
                tasksearch = context.Task.Where(s => s.Content.Contains(search)).ToList();
            }
            if (tasksearch.Count == 1)
                return RedirectToAction("TaskView", new { id = tasksearch.FirstOrDefault().Id });
            if (tasksearch.Count==0) throw new HttpException(404, "NotFound");
            else return View(tasksearch);
        }

        public ActionResult TaskView(int id)
        {
            var task = context.Task.Where(x => x.Id == id).FirstOrDefault();
            return View(task);
        }
    }
}
