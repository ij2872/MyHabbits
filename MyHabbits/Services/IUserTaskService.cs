using MyHabbits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHabbits.Services
{
    interface IUserTaskService
    {
        Task<IEnumerable<CustomerTask>> getIncompleteTasksAsync();
        void AddTask(CustomerTask newTask);
    }
}
