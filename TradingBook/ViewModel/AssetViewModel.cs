using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TradingBook.Model;

namespace TradingBook.ViewModel
{
    class AssetViewModel : INotifyPropertyChanged
    {
        private Asset asset;

        public AssetViewModel()
        {
            asset = new Asset { Name = "Samsung" };
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
    }
}
