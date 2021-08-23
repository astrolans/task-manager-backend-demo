using Lab2.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab2.TaskManagerApi.Servies
{
    public interface IRepository
    {
        Task<IEnumerable<Task_>> GetAllTasksAsync();

        Task<Task_> GetTaskByIdAsync(int id);

        Task<Task_> TakeResignResponsibility(int taskId, int userId);
    }
}
