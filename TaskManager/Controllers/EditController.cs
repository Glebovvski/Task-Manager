using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Helpers;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Authorize]
    public class EditController : Controller
    {
        private TaskContext context;

        public EditController()
        {
            context = new TaskContext();
        }
        
        // GET: Update/Edit/5
        public ActionResult Edit(int id)
        {
            var task = context.Task.FirstOrDefault(x => x.Id == id);
            return View(task);
        }

        // POST: Update/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, string content,string title,List<string> tags)
        {
            var task = context.Task.FirstOrDefault(x => x.Id == id);
            List<string> temp = CreateTagList.TagsList(tags);
            if (task != null)
            {
                task.Title = title;
                task.Tags = temp;
                task.Content = content;
                task.LastModified = DateTime.Now.Date;
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
