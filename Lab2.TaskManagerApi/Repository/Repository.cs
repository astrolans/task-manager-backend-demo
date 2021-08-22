using Lab2.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.TaskManagerApi.Repository
{
    public class Repository : IRepository
    {
        private readonly TaskManagerContext context;

        public Repository(TaskManagerContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Lab2.Entities.Task>> GetAllTasks
        {

        }
    }
}
