using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHabbits.Models
{
    public class CustomerTasksViewModel
    {
        public IEnumerable<CustomerTask> CustomerTasks { get; set; }
    }
}