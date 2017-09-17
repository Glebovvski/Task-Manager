using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Authorize]
    public class EditController : Controller
    {
        // GET: Edit
        
        // GET: Update/Edit/5
        public ActionResult Edit(int id)
        {
            var context = new TaskContext();
            var task = context.Task.FirstOrDefault(x => x.Id == id);
            return View(task);
        }

        // POST: Update/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, string content)
        {
            var context = new TaskContext();

            var task = context.Task.FirstOrDefault(x => x.Id == id);
            if (task != null)
            {
                task.Content = content;
                task.LastModified = DateTime.Now.Date;
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}