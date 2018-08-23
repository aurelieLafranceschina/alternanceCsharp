using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helloworld
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime theDate = DateTime.Now;
            var Today = theDate.DayOfWeek;
            int currentHour = theDate.Hour;
            Console.WriteLine("Bonjour " + Environment.UserName  + " " + Today + theDate );
        }
    }

    
}
