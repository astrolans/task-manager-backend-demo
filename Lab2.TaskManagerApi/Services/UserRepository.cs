using Lab2.DataAccessLayer;
using Lab2.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Lab2.TaskManagerApi.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskManagerContext context;

        public UserRepository(TaskManagerContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get User by specified ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the Task by ID or null if no User found.</returns>
        public async Task<User> GetUserByIdAsync(int id) => await context.Users.FirstOrDefaultAsync(t => t.Id == id);
    }
}
