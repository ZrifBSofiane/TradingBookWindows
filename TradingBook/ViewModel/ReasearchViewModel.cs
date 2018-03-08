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

        public SeriesCollection AssetValueVolatility
        {
            get { return Asset.ValueVolatility; }
            set
            {
                if (Asset.ValueVolatility != value)
                {
                    Asset.ValueVolatility = value;
                    RaisePropertyChanged("AssetValueVolatility");
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
            // Get historical data
            List<Object> result = bbH.GetPriceVolumeValue(ticker, null, "20180101", "20180220");
            List<double> price = (List<double>)result[1];

            ChartValues<double> valueChart = new ChartValues<double>();
            for (int i = 0; i < price.Count; i++)
            {
                valueChart.Add(price[i]);
            }
              
            // Compute Volatility
            ChartValues<double> valueVolatility = new ChartValues<double>();
            double V0 = price[0];
            for(int i=0; i<price.Count; i++)
            {
                double Vt = price[i];
                valueVolatility.Add(( (Vt / V0) - 1) *100); // peut etre *100 à voir selon le résultat 
            }

            NameAsset = ticker;

            // Compute Performance
            ChartValues<double> valuePerformance= new ChartValues<double>();
            for(int i=0; i<price.Count; i++)
            {
                double resultPerf = PopulationStandardDeviation(valueVolatility.Take(i).ToList());
                valuePerformance.Add(resultPerf);
            }

           
            AssetValue = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Asset Value",
                    Values = valueChart
                }
            };

            AssetValuePerformance = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Performance",
                    Values = valuePerformance
                }
            };

            AssetValueVolatility = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Volatility",
                    Values = valueVolatility
                }
            };


            // Here for AssetReaserch
            AssetResarch.ValuePerformance = valuePerformance.ToList();
            AssetResarch.Value = valueChart.ToList();
            AssetResarch.ValueVolatility = valueVolatility.ToList();
            




        }

        public void SearchInfo(String ticker)
        {
            Dictionary<String, String> resultInfo = bbInfo.SearchInformation(ticker);
            String peer = bbInfo.GetNameCompanyOfEquity(ticker);

            AssetCurrency = resultInfo.ContainsKey("currency") ? resultInfo["currency"] : "Unknown";
            AssetGroup = resultInfo.ContainsKey("industryGroup") ? resultInfo["industryGroup"] : "Unknown";
            AssetSector = resultInfo.ContainsKey("industrySector") ? resultInfo["industrySector"] : "Unknown";
            AssetPeer = peer;


            AssetResarch.Ticker = ticker;
            AssetResarch.Currency = resultInfo.ContainsKey("currency") ? resultInfo["currency"] : "Unknown";
            AssetResarch.Sector = resultInfo.ContainsKey("industrySector") ? resultInfo["industrySector"] : "Unknown";
            AssetResarch.Group = resultInfo.ContainsKey("industryGroup") ? resultInfo["industryGroup"] : "Unknown";
            AssetResarch.Peer = peer;
        }



        private static double StandardDeviation(List<double> numberSet, double divisor)
        {
            double mean = numberSet.Average();
            return Math.Sqrt(numberSet.Sum(x => Math.Pow(x - mean, 2)) / divisor);
        }

        static double PopulationStandardDeviation(List<double> numberSet)
        {
            return StandardDeviation(numberSet, numberSet.Count);
        }

        static double SampleStandardDeviation(List<double> numberSet)
        {
            return StandardDeviation(numberSet, numberSet.Count - 1);
        }





    }
}
