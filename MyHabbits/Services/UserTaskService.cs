using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MyHabbits.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace MyHabbits.Services
{
    public class UserTaskService : IUserTaskService
    {
        private readonly ApplicationDbContext _context;

        public UserTaskService()
        {
            _context = new ApplicationDbContext();
        }


        public async Task<IEnumerable<CustomerTask>> getIncompleteTasksAsync()
        {

            var items = await _context.CustomerTasks
                    .Where(x => x.is_done == false)
                    .ToArrayAsync();
            return items;

        }


        public void AddTask(CustomerTask newTask, String AppId)
        {
            //ApplicationUser currentUser = _context.Users.FirstOrDefault(u => u.Id == AppId);
            //Get Customer Id
            var customerId = _context.Customers.FirstOrDefault(c => c.ApplicationUserId == AppId);

            newTask.customer = customerId;
            newTask.ApplicationUserId = AppId;

            _context.CustomerTasks.Add(newTask);
            _context.SaveChanges();
        }

        public void DeleteTask(CustomerTask deleteTask, string AppId)
        {
            //@TODO Delete based on applicationUserId and Id of CustomerTask
            var elementToDestroy = _context.CustomerTasks.Where(ct => ct.ApplicationUserId == AppId && ct.Title == deleteTask.Title).First();
            _context.CustomerTasks.Remove(elementToDestroy);
        }

    }
}