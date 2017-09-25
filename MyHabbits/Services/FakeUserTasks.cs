using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MyHabbits.Models;

namespace MyHabbits.Services
{
    public class FakeUserTasks : IUserTaskService
    {
        public Task<IEnumerable<CustomerTask>> getIncompleteTasksAsync()
        {
            IEnumerable<CustomerTask> items = new[]
            {
                //Title: Program, Percent: 60%, Goal: 2 Hours
                new CustomerTask
                {
                    Id = 0,
                    Title = "Program",
                    time_completed = new TimeSpan(1, 12, 0),
                    time_goal = new TimeSpan(2, 0, 0),
                    ApplicationUserId = "bannanansuseride12421"
                },
                //Title: Read, Percent: 0%, Goal: 2 Hours
                new CustomerTask
                {
                    Id = 1,
                    Title = "Read",
                    time_completed = new TimeSpan(0, 0, 0),
                    time_goal = new TimeSpan(1, 30, 0),
                    ApplicationUserId = "bannanansuseride12421"

                },
                //Title: Run, Percent: 50%, Goal: 30 mins
                new CustomerTask
                {
                    Id = 2,
                    Title = "Run",
                    time_completed = new TimeSpan(0, 15, 0),
                    time_goal = new TimeSpan(0, 30, 0),
                    ApplicationUserId = "bannanansuseride12421"

                }
            };
            return Task.FromResult(items);
        }

        public void AddTask(CustomerTask newTask)
        {

        }
    }
}