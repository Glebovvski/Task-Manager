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
    public class EditApiController : ApiController
    {
        private TaskContext context;

        public EditApiController()
        {
            context = new TaskContext();
        }
        // GET: Update/Edit/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var task = context.Task.FirstOrDefault(x => x.Id == id);
            return Ok(task);
        }

        // POST: Update/Edit/5
        [HttpPatch,HttpPut]
        public IHttpActionResult Patch(int id, [FromBody]string content, [FromBody]string title, [FromBody]List<string> tags)
        {
            var task = context.Task.FirstOrDefault(x => x.Id == id);
            if (task != null)
            {
                task.Title = title;
                task.Tags = CreateTagList.TagsList(tags);
                task.Content = content;
                task.LastModified = DateTime.Now.Date;
                context.SaveChanges();
            }
            return Ok(task);
        }
    }
}
