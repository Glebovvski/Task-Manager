using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Authorize]
    public class CreateController : Controller
    {
        // GET: Update
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string content,string title)
        {
            var context = new TaskContext();

            var task = new PersonalTask()
            {
                Title = title,
                Content = content,
                LastModified = DateTime.Now
            };
            context.Task.Add(task);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");

        }

        

        // GET: Update/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Update/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
