using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace MyHabbits.Services
{
    public class DailyUpdateService
    {
        public void endOfDayUpdate()
        {
            string script = File.ReadAllText("/Query/CustomerTaskArchiveQuery.sql");
            
        }

    }
}