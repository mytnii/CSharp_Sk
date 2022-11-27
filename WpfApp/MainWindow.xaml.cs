using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string str;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonCoup_Click(object sender, RoutedEventArgs e)
        {


            str = Text2.Text;

            string reverseStr = "";

            for (int i = str.Length - 1; i >= 0; --i)
            {
                reverseStr += str[i];
            }

            Label.Content = reverseStr;
        }

        private void buttonSeparation_Click(object sender, RoutedEventArgs e)
        {

            str = Txt.Text;

            string[] arr = str.Split(" ").ToArray();

           listBox.ItemsSource = arr;
        }
    }
}
