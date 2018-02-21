using LiveCharts;
using LiveCharts.Wpf;
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
        private Asset asset;
        BloombergHistorical bbH = new BloombergHistorical();

        public ReasearchViewModel()
        {
            asset = new Asset{ Name="Unknown" };
        }


        public Asset Asset
        {
            get { return this.asset; }
            set { this.asset = value; }
        }

        public String NameAsset
        {
            get { return Asset.Name; }
            set
            {
                if(Asset.Name != value)
                {
                    Asset.Name = value;
                }
            }
        }

        public SeriesCollection AssetValue
        {
            get { return Asset.Value; }
            set
            {
                if (Asset.Value != value)
                {
                    Asset.Value = value;
                    RaisePropertyChanged("AssetValue");
                }

            }
        }

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

        public void PopulateChartPrice(string ticker)
        {
            List<Object> result = bbH.GetPriceVolumeValue(ticker, null, "20180101", "20180220");
            List<double> price = (List<double>)result[1];
            ChartValues<double> valueChart = new ChartValues<double>();
            for (int i = 0; i < price.Count; i++)
            {
                valueChart.Add(price[i]);
            }

            NameAsset = ticker;
            AssetValue = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Serie 1",
                    Values = valueChart
                }
            };

        }



    }
}
