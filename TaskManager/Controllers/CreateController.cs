using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class CreateController : Controller
    {
        // GET: Update
        public ActionResult Create()
        {
            return PartialView();
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
                task.LastModified = DateTime.Now;
                context.SaveChanges();
            }
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
