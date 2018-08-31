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
        private ToolBox ToolBox;
        private ApiRequest apiRequest;
       
        
        public GetData()
        {
            this.ToolBox = new ToolBox();
            this.apiRequest = new ApiRequest();
        }
        public Dictionary<string, List<DetailsOfLine>> GetStationDataToDictionary()
        {
            string url = "http://data.metromobilite.fr/api/linesNear/json?x=5.727798&y=45.185638&dist=400&details=true";
           
            string responseFromServer = apiRequest.doRequest(url);

          

            List<Donnees> stationList = JsonConvert.DeserializeObject<List<Donnees>>(responseFromServer);
           
            Dictionary<string, List<DetailsOfLine>> stationsDict = new Dictionary<string, List<DetailsOfLine>>();
            stationsDict = ToolBox.GetListNameWithoutDuplicateAsDictionnary(stationList);

            return stationsDict;
        }
        
        

    }
}
