using MyHabbits.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MyHabbits.Services
{
    public class UserGetService
    {
        private readonly ApplicationDbContext _context;

        public UserGetService()
        {
            _context = new ApplicationDbContext();
        }

        public async Task<IEnumerable<CustomerTaskHistory>> getCompletedHistory(string AppId)
        {
            var items = await _context.CustomerTaskHistory
                    .Where(h => h.ApplicationUserId == AppId).ToArrayAsync();
            return items;
        }
    }
}