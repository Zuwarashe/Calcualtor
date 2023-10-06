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
        private string currentNumber = string.Empty;
        private Boolean done = false;
        private string numberone = string.Empty;
        private string numbertwo = string.Empty;
        private string operation = string.Empty;
        private double result = 0;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string content = (sender as Button).Content.ToString();

            if (content == "Clear")
            {
                resultTextBox.Text = string.Empty;
                currentNumber = string.Empty;
                result = 0;
                operation = string.Empty;
            }
            else if (content == "+" || content == "/" || content == "*" || content == "-")
            {
                operation = content;
                numberone = currentNumber;
                resultTextBox.Text += content;
                currentNumber = string.Empty;
                //  MessageBox.Show(currentNumber + " cur num " + content);
            }
            else if (content == "=")
            { 
                
               
                double newNumber;
                if ((double.TryParse(currentNumber, out newNumber)))
                {
                    double NumberOne;
                    double.TryParse(numberone, out NumberOne);

                    switch (operation)
                    {
                        case "+":
                            result =  NumberOne + newNumber;
                            break;
                        case "-":
                            result = newNumber - NumberOne;
                            break;
                        case "*":
                            result *= NumberOne * newNumber;
                            break;
                        case "/":
                            if (newNumber != 0)
                                result /= newNumber;
                            else
                                MessageBox.Show("Cannot divide by zero!");
                            break;
                    }                  
                    resultTextBox.Text = result.ToString();
                    currentNumber = result.ToString();
                    done = true;
                }
            }
            else
            {
                if (done)
                {
                    resultTextBox.Text = string.Empty;
                    currentNumber = string.Empty;
                    result = 0;
                    operation = string.Empty;
                    done = false;
                }
                currentNumber += content;
                resultTextBox.Text += content;
             //   resultTextBox.Text = result.ToString();
            }
        }
}
}
