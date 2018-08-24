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

            do
            {
                Message m1 = new Message(9, 13, 18);
                m1.GetHelloMessage();
                

            } while (
                Console.ReadLine() != "exit"
            );
            
                
            
        }


    }

    
}
