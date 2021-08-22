using Lab2.DataAccessLayer;
using Lab2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.TaskManagerApi.Data
{
    public class SeedData
    {
        /// <summary>
        /// Seeds database with dummy data and resets identity column on each call.
        /// If database contains data, doesn't seed.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TaskManagerContext(
                serviceProvider.GetRequiredService<DbContextOptions<TaskManagerContext>>()))
            {
                if (context.Tasks.Any() || context.Users.Any())
                {
                    return;
                }

                foreach (var entity in context.Model.GetEntityTypes())
                {
                    var schemaName = entity.GetSchema();
                    var tableName = entity.GetTableName();
                    if (tableName == "Assignments") continue;
                    context.Database.ExecuteSqlRaw($"DELETE FROM {schemaName}.{tableName}");
                    context.Database.ExecuteSqlRaw($"DBCC CHECKIDENT (\"{schemaName}.{tableName}\", RESEED, 0);");
                }

                User user1, user2, user3, user4;
                user1 = new() { FirstName = "Thomas", LastName = "Liu" };
                user2 = new() { FirstName = "Simon", LastName = "Siroky" };
                user3 = new() { FirstName = "John", LastName = "Doe" };
                user4 = new() { FirstName = "Jane", LastName = "Doe" };

                context.Tasks.AddRange(
                    new Task_
                    {
                        BeginDateTime = DateTime.UtcNow,
                        DeadlineDateTime = DateTime.UtcNow.AddDays(5),
                        Title = "Programutvecklingsprojekt",
                        Requirements = "Planering",
                        Users = new() { user1 }
                    },
                    new Task_
                    {
                        BeginDateTime = DateTime.UtcNow,
                        DeadlineDateTime = DateTime.UtcNow.AddDays(3).AddHours(14).AddMinutes(15),
                        Title = "Sprint Meeting",
                        Requirements = "Sprinta lite, hoppa bock osv.",
                        Users = new() { user2 }
                    },
                    new Task_
                    {
                        BeginDateTime = new DateTime(2021, 8, 20, 3, 45, 00),
                        DeadlineDateTime = DateTime.UtcNow.AddDays(3).AddHours(14).AddMinutes(15),
                        Title = "Comic Con 2021",
                        Requirements = "Planning and managing the event",
                        Users = new() { user1, user2, user3, user4 }
                    },
                    new Task_
                    {
                        BeginDateTime = DateTime.UtcNow,
                        DeadlineDateTime = DateTime.UtcNow.AddDays(4).AddHours(9),
                        Title = "Cool party 2021",
                        Requirements = "Hosting the coolest party in 2021",
                        Users = new() { user3, user4 }
                    },
                    new Task_
                    {
                        BeginDateTime = DateTime.UtcNow,
                        DeadlineDateTime = DateTime.UtcNow.AddDays(4).AddHours(9),
                        Title = "Book Club Meeting: 50 Shades of Grey",
                        Requirements = "Meeting discussing and reflecting on the lastest read book",
                        Users = new() { }
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
