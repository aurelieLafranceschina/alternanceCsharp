using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Library;

namespace ProjetTC
{
    class Program
    {
        static void Main(string[] args)
        {
            GetData getData = new GetData();
            Dictionary<string, List<DetailsOfLine>> stationsDict = getData.GetStationData();
            foreach (var data in stationsDict)
            {
                Console.WriteLine("Arrêt : " + data.Key);
                foreach (DetailsOfLine line in data.Value)
                {
                    Console.WriteLine("Ligne : " + line.type +" "+  line.mode + " " + line.textColor);
                }
            }            

            // Clean up the streams and the response.  
            //reader.Close();
            //TCLines.Close();

        }                  
    }
}
