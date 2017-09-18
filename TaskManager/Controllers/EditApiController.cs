using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Authorize]
    public class EditApiController : ApiController
    {
        // GET: Update/Edit/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var context = new TaskContext();
            var task = context.Task.FirstOrDefault(x => x.Id == id);
            return Ok(task);
        }

        // POST: Update/Edit/5
        [HttpPatch,HttpPut]
        public IHttpActionResult Patch(int id, [FromBody]string content)
        {
            var context = new TaskContext();

            var task = context.Task.FirstOrDefault(x => x.Id == id);
            if (task != null)
            {
                task.Content = content;
                task.LastModified = DateTime.Now.Date;
                context.SaveChanges();
            }
            return Ok(task);
        }
    }
}