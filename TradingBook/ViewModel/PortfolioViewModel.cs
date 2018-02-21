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
    class PortfolioViewModel : INotifyPropertyChanged
    {

        private Portfolio portfolio;

        public PortfolioViewModel()
        {
            portfolio = new Portfolio { OwnerName = "Sofiane"};
        }


        public Portfolio Portfolio
        {
            get { return this.portfolio; }
            set { this.portfolio = value; }
        }

        public SeriesCollection PortfolioValue
        {
            get { return Portfolio.ValuePortfolio; }
            set
            {
                if (Portfolio.ValuePortfolio != value)
                {
                    Portfolio.ValuePortfolio = value;
                    RaisePropertyChanged("PortfolioValue");
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




        public void PopulatePortfolioValue()
        {
            ChartValues < double > valueChart = new ChartValues<double>();
            for (int i = 0; i < 20; i++)
            {
                valueChart.Add(i * i);
            }

            PortfolioValue = new SeriesCollection
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
