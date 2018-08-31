using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class ApiRequest
    {
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
    }
}
