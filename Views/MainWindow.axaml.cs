using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace CalculatorApp
{

    public partial class MainWindow : Window
    {

        private string currentExpression = "";

        public MainWindow()
        {
            InitializeComponent();
        }
        //called when a number or operator button is clicked
        private void OnButtonClick(object? sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Content is string value)
            {
                currentExpression += value;
                Display.Text = currentExpression;
            }
        }

        
        //called when "=" is pressed
        private void OnEqualClick(object? sender, RoutedEventArgs e)
        {
            try
            {
                var result = new System.Data.DataTable().Compute(currentExpression, null);
                Display.Text = result.ToString();
                currentExpression = result.ToString(); //let user continue from result

            }
            catch
            {
                Display.Text = "Error";
                currentExpression = "";
            }
        }

        //called void when "C" button is clicked
        private void OnClearClick(object? sender, RoutedEventArgs e)
        {
            currentExpression = "";
            Display.Text = "";
        }
    }

   
}