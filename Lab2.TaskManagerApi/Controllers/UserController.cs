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
    public class UserController : ControllerBase
    {
        private readonly IRepository repository;

        public UserController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("{id}")]
        //[HttpGet("{id}", Name = nameof(GetById))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type= typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        public async Task<IActionResult> GetById(int id)
        {
            var existingUser = await repository.GetUserByIdAsync(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            return Ok(existingUser);
        }
    }
}
