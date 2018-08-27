using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace ProjetTC
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            // Create a request for the URL.   
            WebRequest requestLines = WebRequest.Create("http://data.metromobilite.fr/api/linesNear/json?x=5.727798&y=45.185638&dist=400&details=true");

            // Get the response. 
            WebResponse TCLines = requestLines.GetResponse();

            // Display the status
            Console.WriteLine(((HttpWebResponse)TCLines).StatusDescription);

            Stream dataStream = TCLines.GetResponseStream();

            // Open the stream using a StreamReader for easy access.  
            StreamReader reader = new StreamReader(dataStream);

            // Read the content.  
            string responseFromServer = reader.ReadToEnd();

            // Display the content.  
            Console.WriteLine(responseFromServer);

            List<Donnees>stationList = JsonConvert.DeserializeObject<List<Donnees>>(responseFromServer);



            foreach (Donnees data in stationList)
            {

                Console.WriteLine("Arrêt : " + data.name);
                Console.WriteLine("Longitude : " + data.lon);
                Console.WriteLine("Latitude : " + data.lat);
                foreach (string line in data.lines)
                {
                    if (!data.lines.Contains(line))
                    {
                        data.lines.Add(line);

                    }
                    Console.WriteLine("Ligne : " + line);
                }
            }

            //-- Create A dictionary with each stop and their lines

            Dictionary<string, List<string>> stationsDict = new Dictionary<string, List<string>>();
            stationsDict = ToolBox.GetListNameWithoutDuplicateAsDictionnary(stationList);

            // Clean up the streams and the response.  
            //reader.Close();
            //TCLines.Close();

        }

            public class Donnees
            {
                public string id { get; set; }
                public string name { get; set; }
                public double lon { get; set; }
                public double lat { get; set; }
                public List<string> lines { get; set; }

           
                
            }

       
    }
}
