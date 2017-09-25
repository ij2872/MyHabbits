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

        public async Task<ActionResult> Index()
        {

            var appId = User.Identity.GetUserId();
            var taskItems = await _UTService.getIncompleteTasksAsync();

            var model = new CustomerTasksViewModel
            {
                CustomerTasks = taskItems
            };
            
            return View(model);
        }

        // /POST/
        [HttpPost]
        public ActionResult Index(CustomerTask cTask)
        {
            var newTask = new CustomerTask
            {
                Title = cTask.Title,
                time_completed = new TimeSpan(0, 0, 0),
                time_goal = new TimeSpan(1, 0, 0),
                is_done = false,
                ApplicationUserId = cTask.ApplicationUserId,
                customer = cTask.customer
            }; 
            _UTService.AddTask(newTask);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}