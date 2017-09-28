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


        public async Task<IEnumerable<CustomerTask>> getIncompleteTasksAsync(string AppId)
        {

            //@TODO Make  it return just incomplete
            var items = await _context.CustomerTasks
                    .Where(x => x.ApplicationUserId == AppId )
                    .ToArrayAsync();
            return items;

        }

        public async Task<IEnumerable<CustomerTask>> getAllTasksAsync(string AppId)
        {
            var items = await _context.CustomerTasks
                    .Where(x => x.ApplicationUserId == AppId)
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
            var customerId = _context.Customers.FirstOrDefault(c => c.ApplicationUserId == AppId).ApplicationUserId;

            deleteTask.ApplicationUserId = customerId;

            //@TODO Delete based on applicationUserId and Id of CustomerTask
            var elementToDestroy = _context.CustomerTasks.FirstOrDefault(ct => ct.ApplicationUserId == deleteTask.ApplicationUserId && ct.Id == deleteTask.Id);
            _context.CustomerTasks.Remove(elementToDestroy);
            _context.SaveChanges();
        }


        public void AddTimeToTask(CustomerTask task, int timeInSeconds)
        {
            var customerId = _context.Customers.FirstOrDefault(c => c.ApplicationUserId == task.ApplicationUserId);

            var taskToUpdate = _context.CustomerTasks.FirstOrDefault(t => t.ApplicationUserId == task.ApplicationUserId && t.Id == task.Id);

            // Check to see if task was retrived
            if (taskToUpdate != null)
            {
                taskToUpdate.time_completed += TimeSpan.FromSeconds(timeInSeconds);

                // Mark as completed when goal is accomplished
                if(taskToUpdate.time_completed >= taskToUpdate.time_goal)
                {
                    taskToUpdate.is_done = true;
                    taskToUpdate.completed_date = DateTime.Today;
                }     

            }

            _context.SaveChanges();
        }

        public void AdjustTimeGoal(CustomerTask editTask, string AppId)
        {
            var taskToUpdate = _context.CustomerTasks.FirstOrDefault(t => t.ApplicationUserId == AppId && t.Id == editTask.Id);

            if(taskToUpdate != null)
            {
                taskToUpdate.time_goal = editTask.time_goal;
            }

            _context.SaveChanges();
        }
        
    }
}