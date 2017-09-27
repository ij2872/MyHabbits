using MyHabbits.Services;
using MyHabbits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace MyHabbits.Controllers
{
    public class HistoryController : Controller
    {
        private UserGetService _UGService = new UserGetService();
        
        [Authorize]
        public async Task<ActionResult> Index()
        {
            string userId = User.Identity.GetUserId();
            var taskItems = await _UGService.getCompletedHistory(userId);

            var model = new CustomerTaskHistoryViewModel
            {
                CustomerTaskHistory = taskItems
            };

            return View(model);
        } 
    }
}