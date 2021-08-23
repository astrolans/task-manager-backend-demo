using Lab2.DataAccessLayer;
using Lab2.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.TaskManagerApi.Servies
{
    public class Repository : IRepository
    {
        private readonly TaskManagerContext context;

        public Repository(TaskManagerContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all Tasks.
        /// </summary>
        /// <returns>Returns the list of Tasks.</returns>
        public async Task<IEnumerable<Task_>> GetAllTasksAsync() => await context.Tasks
            .Include(t => t.Users)
            .OrderBy(t => t.BeginDateTime)
            .ToListAsync();

        /// <summary>
        /// Get Task by specified ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the Task by ID.</returns>
        public async Task<Task_> GetTaskByIdAsync(int id) => await context.Tasks
            .Include(t => t.Users)
            .FirstOrDefaultAsync(t => t.Id == id);

        /// <summary>
        /// The User takes or resigns the responsibility of a Task.
        /// </summary>
        /// <returns>The Task with the new status of responsibility.</returns>
        public async Task<Task_> TakeResignResponsibility(int taskId, int userId)
        {
            var task = await GetTaskByIdAsync(taskId);
            var user = await context.Users.Where(u => u.Id == userId).SingleAsync();
            
            if (task.Users.Contains(user))
            {
                task.Users.Remove(user);
            }
            task.Users.Add(user);

            await context.SaveChangesAsync();
            return task;
        }
    }
}