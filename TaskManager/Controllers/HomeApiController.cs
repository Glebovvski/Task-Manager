using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Authorize]
    public class HomeApiController : ApiController
    {
        public IHttpActionResult Get()
        {
            var context = new TaskContext();
            var tasks = context.Task.OrderByDescending(c => c.LastModified).ToList();
            return Ok(tasks);
        }

    }
}