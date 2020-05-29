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
using Xceed.Wpf.Toolkit;

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

        bool checkValidFilePath(string path)
        {
            if (String.IsNullOrWhiteSpace(path)) return false;
            System.IO.FileInfo fi = null;
            try
            {
                fi = new System.IO.FileInfo(path);
            }
            catch (ArgumentException) { }
            catch (System.IO.PathTooLongException) { }
            catch (NotSupportedException) { }
            if (ReferenceEquals(fi, null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string getTestNumber (int subtask, int no)
        {
            return "Test_" + subtask.ToString("00") + "_" + no.ToString("000");
        }


    }

    public partial class MainWindow : Window
    {
        Utilities utilities;
        private string input_size_Str, output_size_str, task_name;
        private string input_data, output_data, working_directory, working_test_directory;
        private int subtask, test_number;

        void updateWorkingTestDirectory()
        {
            working_test_directory = working_directory;
            if (working_test_directory.Last<char>() != '\\')
                working_test_directory += '\\';
            working_test_directory += task_name;
            working_test_directory += '\\';
            working_test_directory += utilities.getTestNumber(subtask, test_number);
        }

        private void load_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void run_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        public bool is_automated_input, is_pregenerated_input, is_manual_input;

        public MainWindow()
        {
            InitializeComponent();
            utilities = new Utilities();
            is_automated_input = is_pregenerated_input = false;
            input_data = utilities.INPUT_PLACEHOLDER;
            output_data = utilities.OUTPUT_PLACEHOLDER;
        }

        
    }
}
