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

namespace TTGenor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Utilities
    {
        public string[] SIZE_NOTATION = {"B", "KB", "MB", "GB", "TB", "PB" };
        public string INPUT_PLACEHOLDER = "<type your input OR turn on automated input>";
        public string OUTPUT_PLACEHOLDER = "<run to see output>";

        public string ConverSizeIntoString(long size)
        {
            string s;
            double reduced_size = size; int reduction_count = 0;
            while (reduction_count < SIZE_NOTATION.Length - 1 && reduced_size >= 1000.00)
            {
                reduced_size /= 1024.00;
                reduction_count++;
            }
            s = reduced_size.ToString("F2") + " " + SIZE_NOTATION[reduction_count];
            return s;
        }
    }

    public partial class MainWindow : Window
    {
        Utilities utilities;
        private string input_size_Str, output_size_str;
        private string input_data, output_data;
        bool is_input_automated, is_input_pregenerated;

        public MainWindow()
        {
            InitializeComponent();
            utilities = new Utilities();
            is_input_automated = is_input_pregenerated = false;
            input_data = utilities.INPUT_PLACEHOLDER;
            output_data = utilities.OUTPUT_PLACEHOLDER;
        }

        
    }
}
