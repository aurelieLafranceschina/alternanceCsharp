using ProjetTC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTC
{
    internal class GetStationforWPF
    {
        public string name { get; set; }
        public List<DetailsOfLine> detailList { get; set; }

        public GetStationforWPF(string key, List<DetailsOfLine> value)
        {
            this.name = key;
            this.detailList = value;
        }
    }

    
}
