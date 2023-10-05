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
                
                double newNumber;
                if ((double.TryParse(currentNumber, out newNumber)))
                {
                  //  MessageBox.Show(currentNumber);
                    switch (operation)
                    {
                        case "+":
                            result = double.Parse(currentNumber) + newNumber;
                            break;
                        case "-":
                            result -= newNumber;
                            break;
                        case "*":
                            result *= newNumber;
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
                }
            }
            else
            {
                currentNumber += content;
                resultTextBox.Text += content;
             //   resultTextBox.Text = result.ToString();
            }
        }
}
}
