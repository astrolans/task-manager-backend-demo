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
        public async Task<IActionResult> GetAll() => Ok(await repository.GetAllTasksAsync());

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Task_))]
        public async Task<IActionResult> GetById(int id)
        {
            var existingTask = await repository.GetTaskByIdAsync(id);
            if (existingTask == null) return NotFound();
            return Ok(existingTask);
        }
    }
}
