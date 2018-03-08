using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Windows;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Media;
using Microsoft.Office.Tools.Excel;


namespace TradingBook.Model
{
    class ExcelClass
    {


        public void SaveAsExcel()
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlApp.Visible = true;
            if(xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed !");
                return;
            }

            string path  = Environment.CurrentDirectory + @"\ReportingBloomberg2.xls";
            if (!File.Exists(path))
            {
                MessageBox.Show("File doesn't exist ... " + path);
                return;
            }




            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(path);
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = xlApp.ActiveSheet;
            object misValue = System.Reflection.Missing.Value;

           

            xlWorkSheet.Range["F8"].Value = AssetResarch.Name;
            xlWorkSheet.Range["F11"].Value = AssetResarch.Ticker;
            xlWorkSheet.Range["I11"].Value = AssetResarch.Currency;
            xlWorkSheet.Range["F13"].Value = AssetResarch.Sector;
            xlWorkSheet.Range["I13"].Value = AssetResarch.Group;




            //Get chart for Performance
            Microsoft.Office.Interop.Excel.ChartObject chartPerformance = (Microsoft.Office.Interop.Excel.ChartObject)xlWorkSheet.ChartObjects("Graphique 10");
            Microsoft.Office.Interop.Excel.Chart chartPagePerformance = chartPerformance.Chart;
            var seriesCollectionPerformance = (SeriesCollection)chartPagePerformance.SeriesCollection();
            var seriesPerformance = seriesCollectionPerformance.NewSeries();
            seriesPerformance.Values = AssetResarch.ValuePerformance.ToArray();
            chartPagePerformance.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlLine;

            //Get chart for Value
            Microsoft.Office.Interop.Excel.ChartObject chartValue = (Microsoft.Office.Interop.Excel.ChartObject)xlWorkSheet.ChartObjects("Graphique 6");
            Microsoft.Office.Interop.Excel.Chart chartPageValue = chartValue.Chart;
            var seriesCollectionValue = (SeriesCollection)chartPageValue.SeriesCollection();
            var seriesValue = seriesCollectionValue.NewSeries();
            seriesValue.Values = AssetResarch.Value.ToArray();
            chartPageValue.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlLine;

            //Get chart for Volatility
            Microsoft.Office.Interop.Excel.ChartObject chartVolatility = (Microsoft.Office.Interop.Excel.ChartObject)xlWorkSheet.ChartObjects("Graphique 11");
            Microsoft.Office.Interop.Excel.Chart chartPageVolatility = chartVolatility.Chart;
            var seriesCollectionVolatility = (SeriesCollection)chartPageVolatility.SeriesCollection();
            var seriesVolatility = seriesCollectionVolatility.NewSeries();
            seriesVolatility.Values = AssetResarch.ValueVolatility.ToArray();
            chartPageVolatility.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlLine;






            // xlWorkBook.SaveAs("heyy.xls");
            xlWorkBook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, Environment.CurrentDirectory + @"\ReportingBloomberg2.pdf");
            xlWorkBook.SaveAs(Environment.CurrentDirectory + @"\ReportingBloomberg2.pdf", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
           
            xlApp.Quit();

           

            //MessageBox.Show("Excel file created , you can find the file d:\\csharp-Excel.xls");

        }



    }
}
