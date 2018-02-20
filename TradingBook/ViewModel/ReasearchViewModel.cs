using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingBook.Model;

namespace TradingBook.ViewModel
{
    class ReasearchViewModel : INotifyPropertyChanged
    {
      /*  private AssetTicker assetTicker;

        public ReasearchViewModel()
        {
            assetTicker = new AssetTicker { Ticker = new List<String> { "Hello", "baba", "noo" } };
        }


        public AssetTicker AssetTicker
        {
            get { return this.assetTicker; }
            set { this.assetTicker = value; }
        }

        public List<String> TickerAsset
        {
            get { return AssetTicker.Ticker; }
            set
            {
                if (AssetTicker.Ticker != value)
                {
                    AssetTicker.Ticker = value;
                    RaisePropertyChanged("TestItems");
                }

            }
        }*/

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public void changeList()
        {
            //TickerAsset = new List<String> { "Hello", "baba", "noo" };
        }



    }
}
