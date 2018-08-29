using Newtonsoft.Json;
using ProjetTC;
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
        public Dictionary<string, List<DetailsOfLine>> GetStationData()
        {
            string url = "http://data.metromobilite.fr/api/linesNear/json?x=5.727798&y=45.185638&dist=400&details=true";
           
            string responseFromServer = doRequest(url);

            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            //string UrlOptions = String.Empty;
            //// Create a request for the URL.   
            //WebRequest requestLines = WebRequest.Create("http://data.metromobilite.fr/api/linesNear/json?x=5.727798&y=45.185638&dist=400&details=true");
            //WebRequest requestDetails = WebRequest.Create("http://data.metromobilite.fr/api/routers/default/index/routes?code={0}",UrlOptions);
            //// Get the response. 
            //WebResponse TCLines = requestLines.GetResponse();
            //WebResponse TCDetails = requestDetails.GetResponse();

            //// Display the status
            //Console.WriteLine(((HttpWebResponse)TCLines).StatusDescription);
            //Console.WriteLine(((HttpWebResponse)TCDetails).StatusDescription);

            //Stream dataStream = TCLines.GetResponseStream();
            //Stream dataDetailsStream = TCDetails.GetResponseStream();

            //// Open the stream using a StreamReader for easy access.  
            //StreamReader reader = new StreamReader(dataStream);
            //StreamReader detailsReader = new StreamReader(dataDetailsStream);

            //// Read the content.  
            //string responseFromServer = reader.ReadToEnd();
            //string detailsResponse = detailsReader.ReadToEnd();

            //// Display the content.
            ////return responseFromServer;
            //// Console.WriteLine(responseFromServer);           

            List<Donnees> stationList = JsonConvert.DeserializeObject<List<Donnees>>(responseFromServer);
            //List<ObjectDetails>objectDetails = JsonConvert.DeserializeObject<List<ObjectDetails>>(detailsResponse);

            String UrlOptions = UrlLinesDetails(stationList);
            string urlDetails = string.Format("http://data.metromobilite.fr/api/routers/default/index/routes?codes={0}", UrlOptions);
            string linesDetails = doRequest(urlDetails);

            ////List<allData> stationAndDetails = stationList.AddRange(objectDetails);

            //-- Create A dictionary with each stop and their lines
            Dictionary<string, List<DetailsOfLine>> stationsDict = new Dictionary<string, List<DetailsOfLine>>();
            Console.WriteLine(linesDetails);
            stationsDict = ToolBox.GetListNameWithoutDuplicateAsDictionnary(stationList);

            return stationsDict;
        }
        public string doRequest(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            string UrlOptions = String.Empty;
            // Create a request for the URL.   
            WebRequest requestLines = WebRequest.Create(url);
            // Get the response. 
            WebResponse TCLines = requestLines.GetResponse();

            // Display the status
            Console.WriteLine(((HttpWebResponse)TCLines).StatusDescription);

            Stream dataStream = TCLines.GetResponseStream();

            // Open the stream using a StreamReader for easy access.  
            StreamReader reader = new StreamReader(dataStream);

            // Read the content.  
            string responseFromServer = reader.ReadToEnd();           

            return responseFromServer;

        }
        public string UrlLinesDetails (List<Donnees> stationList)
        {
            string finalUrl = "";
            foreach (Donnees item in stationList)
            {
                foreach (var line in item.lines)
                {
                    if (!finalUrl.Contains(line))
                    {
                        finalUrl+= "," + line;
                    }
                }
            }
            return finalUrl;
        }


    }
}
