﻿using System;
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
using TradingBook.Model;

namespace TradingBook
{
    /// <summary>
    /// Logique d'interaction pour ExportLayout.xaml
    /// </summary>
    public partial class ExportLayout : UserControl
    {
        public ExportLayout()
        {
            InitializeComponent();
        }

        private void exportToExcelButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            ExcelClass temp = new ExcelClass();
            temp.SaveAsExcel();
        }

        private void exportToPdfButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
