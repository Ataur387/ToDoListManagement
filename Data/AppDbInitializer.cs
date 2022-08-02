using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListManagement.Models;

namespace ToDoListManagement.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                if (!context.ToDoList.Any())
                {
                    context.ToDoList.AddRange(new List<ToDoListModel>()
                    {
                        new ToDoListModel()
                        {
                            Title = "Daily Scrum",
                            isChecked = false
                        },
                        new ToDoListModel()
                        {
                            Title = "Playing Football",
                            isChecked = false
                        },
                        new ToDoListModel()
                        {
                            Title = "Reading some pages",
                            isChecked = false
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Users.Any())
                {
                    context.Users.AddRange(new List<UserModel>()
                    {
                        new UserModel()
                        {
                            Name = "Taher Irfan",
                            UserName = "Irfan367",
                            Password = "irfancse",
                            Role = "User"
                        },
                        new UserModel()
                        {
                            Name = "Admin",
                            UserName = "admin",
                            Password = "root",
                            Role = "Admin"
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
