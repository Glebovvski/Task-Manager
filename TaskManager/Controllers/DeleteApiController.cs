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
        private TaskContext context;

        public DeleteApiController()
        {
            context = new TaskContext();
        }
        // GET: Delete
        public IHttpActionResult Delete()
        {
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
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
