using Lab2.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.DataAccessLayer
{
    public class TaskManagerContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Entities.Task> Tasks { get; set; }

        public TaskManagerContext(DbContextOptions<TaskManagerContext> options)
            : base(options) { }
    }
}
