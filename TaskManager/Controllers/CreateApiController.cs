using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TaskManager.Dto;
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
        public IHttpActionResult Post(PersonalTaskDto personalTask)
        {
            var task = Mapper.Map<PersonalTaskDto, PersonalTask>(personalTask); 
            context.Task.Add(task);
            context.SaveChanges();
            personalTask.Id = task.Id;
            return Ok(task);
        }
    }
}
