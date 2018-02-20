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
    /// Logique d'interaction pour TradeAccountLayout.xaml
    /// </summary>
    public partial class TradeAccountLayout : UserControl
    {
        TradeAccountViewModel viewModel = new TradeAccountViewModel();
        public TradeAccountLayout()
        {
            InitializeComponent();
            base.DataContext = viewModel;
        }

        private void volumeMinus_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ModifyName();
            viewModel.PaintX2();
        }
    }
}
