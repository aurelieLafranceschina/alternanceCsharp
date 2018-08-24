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
        public int h1;
        public int h2;
        public int h3;


        public Message(int h1 , int h2 , int h3)
        {
            this.h1 = h1;
            this.h2 = h2;
            this.h3 = h3;
        }

        public  void GetHelloMessage()
        {

            string user = Environment.UserName;
            string currentDay = CurrentDay();
            int currentHour = CurrentHour();


            if ((currentDay == "Saturday" || currentDay == "Sunday") || ((currentDay == "Monday" && currentHour <= h1) || (currentDay == "Friday" && currentHour >= h3)))
            {
                Console.WriteLine("Bon week-end " + user);
            }
            else if (currentHour >= h2  && currentHour <= h2)
            {
                Console.WriteLine("Bonjour " + user);
            }
            else if (currentHour >= h2 && currentHour <= h3)
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