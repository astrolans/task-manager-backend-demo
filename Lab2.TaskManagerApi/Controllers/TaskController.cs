using Lab2.Entities;
using Lab2.TaskManagerApi.Servies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Task_>))]
        public async Task<IActionResult> GetAll() => Ok(await repository.GetAllTasksAsync());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpGet]
        //[Route("{id}")]
        [HttpGet("{id}", Name = nameof(GetById))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Task_))]
        public async Task<IActionResult> GetById(int id)
        {
            var existingTask = await repository.GetTaskByIdAsync(id);
            
            if (existingTask == null)
            {
                return NotFound();
            }
            
            return Ok(existingTask);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Task_))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ChangeResponsibility(int taskId, int userId)
        {
            if (taskId < 1 || userId < 1)
            {
                return BadRequest("Invalid TaskID or UserID");
            }

            var updatedTask = await repository.ChangeResponsibilityAsync(taskId, userId);
            
            return CreatedAtAction(nameof(GetById), new { id = updatedTask.Id }, updatedTask);
        }
    }
}
