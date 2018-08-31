using Library;
using ProjetTC;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTC
{
    class TransportViewModel
    {
        GetData getData = new GetData();

        public ObservableCollection<GetStationforWPF> _getStationDictionary
        {
            get;
            set;
        }
        public TransportViewModel()
        {
            this._getStationDictionary = new ObservableCollection<GetStationforWPF>();
            fillView();

        }
        public void fillView()
        {
            Dictionary <string , List<DetailsOfLine>>list =  getData.GetStationDataToDictionary();
            foreach (var item in list)
            {
                this._getStationDictionary.Add(new GetStationforWPF(item.Key, item.Value));

            }            
        }
        
    }
}
