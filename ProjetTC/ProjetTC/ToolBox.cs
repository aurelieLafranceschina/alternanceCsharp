using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjetTC.Program;

namespace ProjetTC
{
    class ToolBox
    {
        public static Dictionary<string, List<string>> GetListNameWithoutDuplicateAsDictionnary(List<Donnees> stationList)
        {
            Dictionary<string, List<string>> stationsDict = new Dictionary<string, List<string>>();
            foreach (Donnees station in stationList)
            {
                if (!stationsDict.ContainsKey(station.name))
                {
                    stationsDict.Add(station.name, station.lines);
                }
                else
                {
                    stationsDict[station.name] = (stationsDict[station.name].Concat(station.lines)).Distinct().ToList();
                }
            }
            return stationsDict;
        }
    }
}
