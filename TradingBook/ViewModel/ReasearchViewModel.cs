using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TradingBook.Model;

namespace TradingBook.ViewModel
{
    class ReasearchViewModel : INotifyPropertyChanged
    {
        private Asset asset;
        BloombergHistorical bbH = new BloombergHistorical();
        BloombergInformationEquity bbInfo = new BloombergInformationEquity();

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

        public String AssetCurrency
        {
            get { return Asset.Currency; }
            set
            {
                if(Asset.Currency != value)
                {
                    Asset.Currency = value;
                    RaisePropertyChanged("AssetCurrency");
                } 
            }
        }

        public String AssetSector
        {
            get { return Asset.Sector; }
            set
            {
                if (Asset.Sector != value)
                {
                    Asset.Sector = value;
                    RaisePropertyChanged("AssetSector");
                }
            }
        }

        public String AssetGroup
        {
            get { return Asset.Group; }
            set
            {
                if (Asset.Group != value)
                {
                    Asset.Group = value;
                    RaisePropertyChanged("AssetGroup");
                }
            }
        }

        public String AssetPeer
        {
            get { return Asset.Peer; }
            set
            {
                if (Asset.Peer != value)
                {
                    Asset.Peer = value;
                    RaisePropertyChanged("AssetPeer");
                }
            }
        }

        public SeriesCollection AssetValuePerformance
        {
            get { return Asset.ValuePerformance; }
            set
            {
                if (Asset.ValuePerformance != value)
                {
                    Asset.ValuePerformance = value;
                    RaisePropertyChanged("AssetValuePerformance");
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

            ChartValues<double> valuePerformance = new ChartValues<double>();
            double V0 = price[0];
            for(int i=0; i<price.Count; i++)
            {
                double Vt = price[i];
                valuePerformance.Add(( (Vt / V0) - 1) *100); // peut etre *100 à voir selon le résultat 
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

            AssetValuePerformance = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Serie 1",
                    Values = valuePerformance
                }
            };
        }

        public void SearchInfo(String ticker)
        {
            Dictionary<String, String> resultInfo = bbInfo.SearchInformation(ticker);
            AssetCurrency = resultInfo.ContainsKey("currency") ? resultInfo["currency"] : "Unknown";
            AssetGroup = resultInfo.ContainsKey("industryGroup") ? resultInfo["industryGroup"] : "Unknown";
            AssetSector = resultInfo.ContainsKey("industrySector") ? resultInfo["industrySector"] : "Unknown";
            AssetPeer = bbInfo.GetNameCompanyOfEquity(ticker);   
        }

        



    }
}
