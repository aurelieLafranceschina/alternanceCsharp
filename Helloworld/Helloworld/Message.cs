using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helloworld
{
    class Message
    {
       
        public static string CurrentDay()

        {
            DateTime theDate = DateTime.Now;
            string currentDay = theDate.DayOfWeek.ToString();

            return currentDay;
        }

        public static string CurrentHour()

        {
            DateTime theDate = DateTime.Now;
            string currentHour = theDate.Hour.ToString();

            return currentHour;
        }

        public static void SayHello()
        {

           string user = Environment.UserName;
           string currentDay = CurrentDay();
           string currentHour = CurrentHour();
           Console.WriteLine("Bonjour " + user + " " + currentDay + " " + currentHour);
        }
        
    }
}
