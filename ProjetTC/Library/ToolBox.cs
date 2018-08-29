using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Library;
using System.Text;
using System.Threading.Tasks;
using ProjetTC;

namespace Library
{
    class ToolBox
    {
        public static Dictionary<string, List<DetailsOfLine>> GetListNameWithoutDuplicateAsDictionnary(List<Donnees> stationList)
        {
            Dictionary<string, List<DetailsOfLine>> stationsDict = new Dictionary<string, List<DetailsOfLine>>();
            foreach (Donnees station in stationList)
            {
                if (!stationsDict.ContainsKey(station.name))
                {
                    stationsDict.Add(station.name, new List<DetailsOfLine>());
                    
                }
                foreach (String line in station.lines)
                {
                        GetData gd = new GetData();
                        string result = gd.doRequest("http://data.metromobilite.fr/api/routers/default/index/routes?codes=" + line);
                        List<DetailsOfLine> detail = JsonConvert.DeserializeObject<List<DetailsOfLine>>(result);

                        if (!stationsDict[station.name].Contains(detail[0]))
                        {
                            stationsDict[station.name].Add(detail[0]);
                        }

                      //  stationsDict[station.name] = (stationsDict[station.name].Concat(station.lines)).Distinct().ToList();
                }

            }
            return stationsDict;
        }
    }
}
