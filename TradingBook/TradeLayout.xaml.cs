using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TradingBook.ViewModel;

namespace TradingBook
{
    /// <summary>
    /// Logique d'interaction pour TradeLayout.xaml
    /// </summary>
    public partial class TradeLayout : UserControl
    {
        public TradeLayout()
        {
            InitializeComponent();
            TradeAccountViewModel vm1 = new TradeAccountViewModel();
            TradeAccountViewModel vm2 = new TradeAccountViewModel();
            TradeAccountViewModel vm3 = new TradeAccountViewModel();
            TradeAccountViewModel vm4 = new TradeAccountViewModel();

            trade1.DataContext = vm1;
            trade2.DataContext = vm2;
            trade3.DataContext = vm3;
            trade4.DataContext = vm4;

            vm1.PopulateChartPrice("AAPL US EQUITY");
            vm2.PopulateChartPrice("IBM US EQUITY");
            vm3.PopulateChartPrice("NESN SW EQUITY");
            vm4.PopulateChartPrice("SMSN LI EQUITY");
        }
    }
}
