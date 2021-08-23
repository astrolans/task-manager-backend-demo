using Lab2.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab2.TaskManagerApi.Services
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Task_>> GetAllTasksAsync();

        Task<Task_> GetTaskByIdAsync(int id);

        Task<Task_> ChangeResponsibilityAsync(int taskId, int userId);
    }
}
