using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingBook.Model
{
    public static class AssetResarch
    {
        public static String Currency { get; set; }

        public static String Ticker { get; set; }

        public static String Sector { get; set; }

        public static String Group { get; set; }

        public static String Peer { get; set; }

        public static String Name { get; set; }

        public static List<double> Value { get; set; }

        public static List<double> ValuePerformance { get; set; }

        public static List<double> ValueVolatility { get; set; }
    }
}
