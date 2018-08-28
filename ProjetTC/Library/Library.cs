using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Library
{
    public class GetData
    {
        public Dictionary<string, List<string>> GetStationData()
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
            //return responseFromServer;
            // Console.WriteLine(responseFromServer);           

            List<Donnees> stationList = JsonConvert.DeserializeObject<List<Donnees>>(responseFromServer);

            //-- Create A dictionary with each stop and their lines
            Dictionary<string, List<string>> stationsDict = new Dictionary<string, List<string>>();
            stationsDict = ToolBox.GetListNameWithoutDuplicateAsDictionnary(stationList);

            return stationsDict;
        }
    }
}
