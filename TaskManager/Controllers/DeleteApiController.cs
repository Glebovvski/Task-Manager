using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class DeleteApiController : ApiController
    {
        // GET: Delete
        public IHttpActionResult Delete()
        {
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var context = new TaskContext();

            var task = context.Task.Find(id);

            if (task != null)
            {
                context.Task.Remove(task);
                context.SaveChanges();
            }

            return Ok();
        }
    }
}