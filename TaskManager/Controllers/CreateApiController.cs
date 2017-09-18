using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Authorize]
    public class CreateApiController : ApiController
    {
        // GET: Update
        public IHttpActionResult Get()
        {
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult Post([FromBody]string content, [FromBody]string title)
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

            return Ok(task);

        }
    }
}
