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
        private string currency;
        private string sector;
        private string group;
        private string peer;
#endregion  

      
        public String Currency
        {
            get { return this.currency; }
            set { this.currency = value; }
        }

        public String Sector
        {
            get { return this.sector; }
            set { this.sector = value; }
        }

        public String Group
        {
            get { return this.group; }
            set { this.group = value; }
        }

        public String Peer
        {
            get { return this.peer; }
            set { this.peer = value; }
        }

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
