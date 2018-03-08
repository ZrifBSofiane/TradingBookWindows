using Bloomberglp.Blpapi;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TradingBook.Model;

namespace TradingBook.ViewModel
{
    public class TradeAccountViewModel : INotifyPropertyChanged
    {
        private Asset asset;
        private BloombergHistorical bbH;
        public TradeAccountViewModel()
        {
            asset = new Asset { Name = "Samsung", Currency="USD"};
            bbH = new BloombergHistorical();
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
                    RaisePropertyChanged("NameAsset");
                }
                
            }
        }


        public SeriesCollection ValueAsset
        {
            get { return Asset.Value; }
            set
            {
                if(Asset.Value != value)
                {
                    Asset.Value = value;
                    RaisePropertyChanged("ValueAsset");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public void ModifyName()
        {
            NameAsset = "Helllooooo";
            ValueAsset = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Serie 1",
                    Values = new ChartValues<double> {4,6,8 },
                   
                }
            };
        }


        public void PaintX2(int j)
        {
            ChartValues<double> valueChart = new ChartValues<double>();
            ChartValues<double> test = new ChartValues<double>();

            for (int i=0;i<20;i++)
            {
                valueChart.Add(Math.Sin(i * i * j));
                test.Add(Math.Cos(i));
                
            }

            ValueAsset = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Serie 1",
                    Values = valueChart,
                    ScalesYAt = 0
                }
            };


            if (GeneralSetting.MovingAverageList.Count!=0) // If there is some Moving average ...
            {
                for(int i = 0; i< GeneralSetting.MovingAverageList.Count; i++)
                {
                    int period = GeneralSetting.MovingAverageList[i].Period;
                    if(period < valueChart.Count)
                    {
                        ChartValues<double> valueChartMovingAverageTemp = new ChartValues<double>();
                        // because for the beginning sma is equal to value chart until we can compute the average
                        for (int k = 0; k < period; k++)
                            valueChartMovingAverageTemp.Add(valueChart[k]);
                        // compute average for the rest of data
                        for (int k = period; k < valueChart.Count; k++)
                        {
                            valueChartMovingAverageTemp.Add(valueChart.Skip(k).Take(period).Sum() / period);
                        }

                        // adding sma
                        ValueAsset.Add(new LineSeries
                        {
                            Title = "SMA" + period,
                            Values = valueChartMovingAverageTemp,
                            Fill = System.Windows.Media.Brushes.Transparent
                        });
                    }
                }   
            }

            if(GeneralSetting.isBollingerBands)
            {
                ChartValues<double> bollingerAverage = new ChartValues<double>();
                int period = GeneralSetting.BollingerBand.Period;
                for (int k = 0; k < period; k++)
                    bollingerAverage.Add(valueChart[k]);
                // compute average for the rest of data
                for (int k = period; k < valueChart.Count; k++)
                {
                   bollingerAverage.Add(valueChart.Skip(k).Take(period).Sum() / period);
                }


                ChartValues<double> bollingerTop = new ChartValues<double>();
                for(int i=1; i< bollingerAverage.Count; i++)
                {
                    double result = bollingerAverage[i] + StandardDeviation(bollingerAverage.Take(i).ToList(), bollingerAverage.Take(i).Count());
                    bollingerTop.Add(result);
                }

                ChartValues<double> bollingerDown = new ChartValues<double>();
                for (int i = 1; i < bollingerAverage.Count; i++)
                {
                    double result = bollingerAverage[i] - StandardDeviation(bollingerAverage.Take(i).ToList(), bollingerAverage.Take(i).Count());
                    bollingerDown.Add(result);
                }


                ValueAsset.Add(new LineSeries
                {
                    Title = "BollingerAverage",
                    Values = bollingerAverage,
                    Stroke = Brushes.Green,
                    Fill = System.Windows.Media.Brushes.Transparent


                });

                ValueAsset.Add(new LineSeries
                {
                    Title = "BollingerTop",
                    Values = bollingerTop,
                    Stroke = Brushes.Green,
                    Fill = System.Windows.Media.Brushes.Transparent
                });

                ValueAsset.Add(new LineSeries
                {
                    Title = "BollingerDown",
                    Values = bollingerDown,
                    Stroke = Brushes.Green,
                    Fill = System.Windows.Media.Brushes.Transparent
                });


            }


           

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


        public void PopulateChartPrice(string ticker)
        {
            List<Object> result = bbH.GetPriceVolumeValue(ticker, null, "20180101","20180220");
            List<double> price = (List<double>)result[1];
            ChartValues<double> valueChart = new ChartValues<double>();
            for(int i =0; i< price.Count;i++)
            {
                valueChart.Add(price[i]);
            }

            NameAsset = ticker;
            ValueAsset = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Price",
                    Values = valueChart
                }
            };

        }

    }
}
