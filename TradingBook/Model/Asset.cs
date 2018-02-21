using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingBook.Model
{
    public class Asset
    {
        #region Variable
        private string name;
        private SeriesCollection valueAsset;
#endregion  

      


        public String Name
        {
            get { return this.name; }
            set { this.name = value;  }
        }

        public SeriesCollection Value
        {
            get { return this.valueAsset; }
            set { this.valueAsset = value; }
        }

    }
}
