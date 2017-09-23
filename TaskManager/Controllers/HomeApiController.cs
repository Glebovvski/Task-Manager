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
        private TaskContext context;

        public HomeApiController()
        {
            context = new TaskContext();
        }
        public IHttpActionResult Get()
        {
            var tasks = context.Task.OrderByDescending(c => c.LastModified).ToList();
            return Ok(tasks);
        }

    }
}
