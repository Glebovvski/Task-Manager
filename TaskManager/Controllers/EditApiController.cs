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
        public IHttpActionResult Patch(int id, PersonalTaskDto pTaskDto)
        {
            var task = context.Task.FirstOrDefault(x => x.Id == id);
            Mapper.Map<PersonalTaskDto, PersonalTask>(pTaskDto, task);
            if (task != null) context.SaveChanges();
            else return NotFound();
            return Ok(task);
        }
    }
}
