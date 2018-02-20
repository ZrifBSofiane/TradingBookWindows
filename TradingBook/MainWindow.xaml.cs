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

namespace TradingBook
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ResearchLayout.Visibility = Visibility.Hidden;
            HomeLaout.Visibility = Visibility.Visible;
            TradeLayout.Visibility = Visibility.Hidden;
            ExportLayout.Visibility = Visibility.Hidden;
        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            ResearchLayout.Visibility = Visibility.Hidden;
            HomeLaout.Visibility = Visibility.Visible;
            TradeLayout.Visibility = Visibility.Hidden;
            ExportLayout.Visibility = Visibility.Hidden;
        }

        private void tradeButton_Click(object sender, RoutedEventArgs e)
        {
            ResearchLayout.Visibility = Visibility.Hidden;
            HomeLaout.Visibility = Visibility.Hidden;
            TradeLayout.Visibility = Visibility.Visible;
            ExportLayout.Visibility = Visibility.Hidden;
        }

        private void exportButton_Click(object sender, RoutedEventArgs e)
        {
            ResearchLayout.Visibility = Visibility.Hidden;
            HomeLaout.Visibility = Visibility.Hidden;
            TradeLayout.Visibility = Visibility.Hidden;
            ExportLayout.Visibility = Visibility.Visible;
        }

        private void researchButton_Click(object sender, RoutedEventArgs e)
        {
            ResearchLayout.Visibility = Visibility.Visible;
            HomeLaout.Visibility = Visibility.Hidden;
            TradeLayout.Visibility = Visibility.Hidden;
            ExportLayout.Visibility = Visibility.Hidden;
        }
    }
}
