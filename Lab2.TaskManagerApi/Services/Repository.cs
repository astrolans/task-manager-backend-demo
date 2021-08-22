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

        public async Task<IEnumerable<Task_>> GetAllTasksAsync() => await context.Tasks
            .Include(t => t.Users)
            .ToListAsync();

        public async Task<Task_> GetTaskByIdAsync(int id) => await context.Tasks
            .Include(t => t.Users)
            .FirstOrDefaultAsync(t => t.Id == id);
    }
}
