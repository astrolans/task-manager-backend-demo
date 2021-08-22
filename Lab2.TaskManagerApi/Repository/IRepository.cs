using Lab2.Entities;
using System.Collections.Generic;

namespace Lab2.TaskManagerApi.Repository
{
    interface IRepository
    {
        IEnumerable<Task_> GetAllTasks();

        Task_ GetTaskById(int id);
    }
}
