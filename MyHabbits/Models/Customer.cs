using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyHabbits.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string first_name { get; set; }
        public string last_name { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser app_user { get; set; }

        public virtual ICollection<CustomerTask> customerTasks { get; set; }

        public string name
        {
            get
            {
                return string.Format("{0} {1}", first_name, last_name);
            }
        }
    }
}