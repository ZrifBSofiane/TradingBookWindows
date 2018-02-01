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
using System.Web;

namespace TradingBook
{
    /// <summary>
    /// Logique d'interaction pour HomeLayout.xaml
    /// </summary>
    public partial class HomeLayout : UserControl
    {
        public HomeLayout()
        {
            InitializeComponent();
            statusLabel.Inlines.Add(new Run("Welcome back "));
            statusLabel.Inlines.Add(new Bold(new Run("Sofiane !")));
            statusLabel.Inlines.Add(new Run("\nYour total revenue for this month so far is: "));
            statusLabel.Inlines.Add(new Bold(new Run("15.426,90$")));

            spanAfterCirculation.Inlines.Add(new Run("of your revenue is \nstill in circulation"));
            spanAfterReached.Inlines.Add(new Run("of \nlast days revenue"));
            spanAfterComparaison.Inlines.Add(new Run(" more income \n compared to last month"));



        }
    }
}
