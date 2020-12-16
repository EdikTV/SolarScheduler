using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SolarSchedule.AccessLayer.Entities;
using SolarSchedule.AccessLayer.EntityFramework.DbContext;

namespace SolarlabSchedule.Test.Services
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var services = new ServiceCollection();
            DbContextInstaller.ConfigureDbContext(services);
            SchedulerDbContext db = new SchedulerDbContext(new DbContextOptions<SchedulerDbContext>());
            Task task = new Task();
            task.Name = "Пописать";
            User usere = new User();
            usere.Task=new List<Task>();
            usere.Task.Add(task);
            usere.Name = "Валентин Дядька";
            usere.Email = "edik2000@gmail.com";
            usere.Password = "tetriandox";
            //db.Userses.Find(1).Task.Remove(db.Userses.Find(1).Task.Find(t=>t.Id==2)); // я понимаю, что при таком подходе в бд всё равно останется задача. Оно и к лучшему. Будет что фсб показать
            db.Userses.Add(usere);
            db.Taskses.Add(task);
            db.SaveChanges();
            foreach (var user in db.Userses.ToList())
            {
                Console.WriteLine($"{user.Id}.{user.Name}+{user.Password}");
                //Console.WriteLine($"{first}");
            }
        }
    }
}
