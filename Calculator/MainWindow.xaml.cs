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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double lastNumber, result;
        public MainWindow()
        {
            InitializeComponent();

            resultLabel.Content = "123";

            //event handler 
            acButton.Click += AcButtonOnClick;
            negativeButton.Click += NegativeButtonOnClick;
            percentageButton.Click += PercentageButtonOnClick;
            equalsButton.Click += EqualsButtonOnClick;
        }

        private void EqualsButtonOnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PercentageButtonOnClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber /100;
                resultLabel.Content = lastNumber.ToString();

            }
        }

        private void NegativeButtonOnClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
                
            }
        }

        private void AcButtonOnClick(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void SevenButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "7";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}7";
            }

        }
    }
}
