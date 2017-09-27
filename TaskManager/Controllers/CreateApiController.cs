using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TaskManager.Helpers;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Authorize]
    public class CreateApiController : ApiController
    {
        private TaskContext context;

        public CreateApiController()
        {
            context = new TaskContext();
        }
        // GET: Update
        public IHttpActionResult Get()
        {
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult Post([FromBody]string content, [FromBody]string title,[FromBody]string tags)
        {
            var task = new PersonalTask()
            {
                Title = title,
                Content = content,
                LastModified = DateTime.Now,
                Tags = tags
            };
            context.Task.Add(task);
            context.SaveChanges();

            return Ok(task);

        }
    }
}
