using Lab2.DataAccessLayer;
using Lab2.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Lab2.TaskManagerApi.Repository
{
    public class Repository : IRepository
    {
        private readonly TaskManagerContext context;

        public Repository(TaskManagerContext context)
        {
            this.context = context;
        }

        public IEnumerable<Task_> GetAllTasks() => context.Tasks
            .Include(t => t.Users
                .Select(u => u.Id));

        public Task_ GetTaskById(int id) => context.Tasks.FirstOrDefault(t => t.Id == id);
    }
}
