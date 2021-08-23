using Lab2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.TaskManagerApi.Services
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
    }
}
