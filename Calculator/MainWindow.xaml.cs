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
        private SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();

            resultLabel.Content = "0";

            //event handler 
            acButton.Click += AcButtonOnClick;
            negativeButton.Click += NegativeButtonOnClick;
            percentageButton.Click += PercentageButtonOnClick;
            equalsButton.Click += EqualsButton_OnClick;
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

        //nadpisujemy metode i tworzymy wspólny handler dla wszystkich numerycznych
        //private void SevenButton_OnClick(object sender, RoutedEventArgs e)
        //{
        //    if (resultLabel.Content.ToString() == "0")
        //    {
        //        resultLabel.Content = "7";
        //    }
        //    else
        //    {
        //        resultLabel.Content = $"{resultLabel.Content}7";
        //    }

        //}

        private void OperationButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            if (Equals(sender, multiplyButton))
            {
                selectedOperator = SelectedOperator.Multiplication;
            }

            if (sender == divideButton)
            {
                selectedOperator = SelectedOperator.Division;
            }

            if (sender == plusButton)
            {
                selectedOperator = SelectedOperator.Addition;
            }

            if (sender == minusButton)
            {
                selectedOperator = SelectedOperator.Substraction;
            }
        }

        private void NumberButton_OnClick(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (sender == zeroButton)
            {
                selectedValue = 0;
            }
            if (sender == oneButton)
            {
                selectedValue = 1;
            }
            if (sender == twoButton)
            {
                selectedValue = 2;
            }
            if (sender == threeButton)
            {
                selectedValue = 3;
            }
            if (sender == fourButton)
            {
                selectedValue = 4;
            }
            if (sender == fiveButton)
            {
                selectedValue = 5;
            }
            if (sender == sixButton)
            {
                selectedValue = 6;
            }
            if (sender == sevenButton)
            {
                selectedValue = 7;
            }
            if (sender == eightButton)
            {
                selectedValue = 8;
            }
            if (sender == nineButton)
            {
                selectedValue = 9;
            }

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }

        }

        private void EqualsButton_OnClick(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Substraction:
                        result = SimpleMath.Substract(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                }

                resultLabel.Content = result.ToString();
            }
                
        }

        private void DotButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString().Contains("."))
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
           
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Substraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Substract(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Divide(double n1, double n2)
        {
            return n1 / n2;
        }
    }
}
