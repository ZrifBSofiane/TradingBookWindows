using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingBook.Model
{
    public static class GeneralSetting
    {


        public static String StartDate { get; set; }  //Date to start historical 
        public static String EndDate { get; set; }  // StringFormat YYYYMMDD
        public static String Periodicity { get; set; } // Periodicity of Chart Value

        public static List<MovingAverage> MovingAverageList { get; set; }

        




    }
}
