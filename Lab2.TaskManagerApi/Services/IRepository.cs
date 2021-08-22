using Lab2.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab2.TaskManagerApi.Servies
{
    public interface IRepository
    {
        Task<IEnumerable<Task_>> GetAllTasks();

        Task<Task_> GetTaskById(int id);
    }
}
