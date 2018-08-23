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

        public static int CurrentHour()

        {
            DateTime theDate = DateTime.Now;
            int currentHour = theDate.Hour;

            return currentHour;
        }

        public static void GetHelloMessage()
        {

            string user = Environment.UserName;
            string currentDay = "Tuesday";
            int currentHour = 7;
            //Console.WriteLine("Bonjour " + user + " " + currentDay + " " + currentHour);

            //if (currentDay != "Saturday" && currentDay != "Sunday")
            //{
            //    if (currentHour >= 9 && currentHour <= 13)
            //    {

            //        Console.WriteLine("Bonjour " + user);
            //    }
            //    else if (currentHour >= 13 && currentHour <= 18)
            //    {
            //        Console.WriteLine("Bon aprés-midi " + user);
            //    }

            //}
            // if (currentDay != "Saturday" && currentDay != "Sunday" && currentDay != "Friday")
            //{
            //    if (currentHour >= 18 || currentHour <= 9)
            //    {
            //        Console.WriteLine("Bonsoir " + user);
            //    }
            //    else { Console.WriteLine("ERROR"); }
            //}
            //else
            //{
            //    Console.WriteLine("Bon week-end " + user);
            //}

            if ((currentDay == "Saturday" || currentDay == "Sunday") || ((currentDay == "Monday" && currentHour <= 8) || (currentDay == "Friday" && currentHour >= 18)))
            {
                Console.WriteLine("Bon week-end " + user);
            }
            else if(currentHour >= 9 && currentHour <=13)
            {
                Console.WriteLine("Bonjour " + user); }
            else if (currentHour >= 13 && currentHour <= 18)
            {
                Console.WriteLine("Bon aprés-midi " + user);
            }
            else
            {
                Console.WriteLine("Bonsoir " + user);
            }
        }
    }
}