using Lab2.Entities;
using Lab2.TaskManagerApi.Servies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.TaskManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IRepository repository;

        public TaskController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Task_>))]
        public IActionResult GetAll() => Ok(repository.GetAllTasks());
    }
}
