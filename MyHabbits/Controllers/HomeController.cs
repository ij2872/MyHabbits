using MyHabbits.Models;
using MyHabbits.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MyHabbits.Controllers
{
    public class HomeController : Controller
    {
        private IUserTaskService _UTService = new UserTaskService();

        [Authorize]
        public async Task<ActionResult> Index()
        {

            //var appId = User.Identity.GetUserId();
            string currentUserId = User.Identity.GetUserId();
            var taskItems = await _UTService.getIncompleteTasksAsync(currentUserId);

            var model = new CustomerTasksViewModel
            {
                CustomerTasks = taskItems
            };
            
            return View(model);
        }

        // /POST/
        [HttpPost]
        [Authorize]
        public ActionResult Index(CustomerTask cTask)
        {

            var newTask = new CustomerTask
            {
                Title = cTask.Title,
                time_completed = new TimeSpan(0, 0, 0),
                time_goal = cTask.time_goal,
                is_done = false,
                ApplicationUserId = cTask.ApplicationUserId,
                customer = cTask.customer
            };

            //get logged in user applicationUserId
            string currentUserId = User.Identity.GetUserId();
            _UTService.AddTask(newTask, currentUserId);

            return RedirectToAction("Index", "Home");
        }

        // UPDATE: /Home/Update
        [HttpPost]
        [Authorize]
        public ActionResult Update(CustomerTask eTask, int secondsCompleted)
        {
            var currentUserId = User.Identity.GetUserId();

            var updateTask = new CustomerTask
            {
                ApplicationUserId = currentUserId,
                Id = eTask.Id,
                
            };

            _UTService.AddTimeToTask(updateTask, secondsCompleted);
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<ActionResult> Edit()
        {
            string currentUserId = User.Identity.GetUserId();
            var taskItems = await _UTService.getAllTasksAsync(currentUserId);

            var model = new CustomerTasksViewModel
            {
                CustomerTasks = taskItems
            };

            return View(model);
        }

         
        
        // DELETE: /Home/Edit
        [HttpDelete]
        public JsonResult Edit(CustomerTask dTask)
        {
            var deleteTask = new CustomerTask
            {
                Title = dTask.Title,
                Id = dTask.Id
            };

            string currentUserId = User.Identity.GetUserId();
            _UTService.DeleteTask(deleteTask, currentUserId);

            return Json("Sucessfully Deleted");
            //return RedirectToAction("Edit", "Home");
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}