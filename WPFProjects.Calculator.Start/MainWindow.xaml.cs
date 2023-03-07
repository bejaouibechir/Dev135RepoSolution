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

namespace WPFProjects.Calculator.Start
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region champs privés
        Calcul _model;
        string _display = "0";
        string _firstOperand = string.Empty;
        string _secondOperand = string.Empty;
        string _operation = string.Empty;
        string _lastoperation = string.Empty;
        string _fullExpression = string.Empty;
        private bool new_displayRequired = true;
        private bool _isfirstoperandset;

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            _model = new Calcul
            {
                FirstOperand = _firstOperand,
                SecondOperand = _secondOperand,
                Operation = _operation,
            };

        }

        public void Singular_operationButtonPress(string operation)
        {
            try
            {
                _model.FirstOperand = _display;
                _model.Operation = operation;
                switch (operation)
                {
                    case "Sin(x)":
                        _model.Operation = "sin";
                        break;
                    case "Cos(x)":
                        _model.Operation = "cos";
                        break;
                    case "Tan(x)":
                        _model.Operation = "tan";
                        break;
                    default:
                        throw new ArgumentException();
                }

                _model.CalculateResult();

                _fullExpression = _operation + "(" + Math.Round(Convert.ToDouble(_firstOperand), 10) + ") = "
                    + Math.Round(Convert.ToDouble(_model.Result), 10);

                _lastoperation = "=";
                _display = _model.Result;
                _firstOperand = _display;
                new_displayRequired = true;
                DisplayBox.Text = _display;
            }
            catch (Exception ex)
            {
                _display = _model.Result == string.Empty ? "Error - see event log" : _model.Result;
                DisplayBox.Text = _display;
                LogExceptionInformation(ex);
            }
        }

        private void LogExceptionInformation(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }



        //Le gestionnaire d'événement principal
        public void Calculate_Handler(object sender, EventArgs args)
        {

            DisplayBox.Text = "0";
            Button current = sender as Button;
            string content = current.Content.ToString();
            if (isdigit(content) == true) DigitButtonPress(content);
            else if (isoperation(content) == true)
            {
                _display = string.Empty;
                DisplayBox.Text = string.Empty;
                ExpressionBox.Text = _model.FirstOperand + _operation;
                OperationButtonPress(content);
            }
            else if (istrigo(content) == true)
                Singular_operationButtonPress(content);

        }


        public void OperationButtonPress(string operation)
        {
            if (operation != "=")
                _model.Operation = operation;

            if (_isfirstoperandset == false)
            {
                _model.FirstOperand = _firstOperand;
                _isfirstoperandset = true;
                _issecondoperadset = false;
            }
            else
            {
                _model.SecondOperand = _secondOperand;
                _isfirstoperandset = true;
                _issecondoperadset = true;
            }

            _lastoperation = operation;
            ExpressionBox.Text = _fullExpression;
            try
            {
                if (_lastoperation == "=")
                {
                    _model.CalculateResult();
                    _display = _model.Result;
                    DisplayBox.Text = _display;
                    //Reset first operand
                    _isfirstoperandset = true;
                    _issecondoperadset = false;
                    _model.FirstOperand = _display;
                    ExpressionBox.Text = _fullExpression;
                }
            }
            catch (Exception ex)
            {
                _display = _model.Result == string.Empty ? "Error - see event log" : _model.Result;
                DisplayBox.Text = _display;
                LogExceptionInformation(ex);
            }
        }





        //For pressing digit buttons
        public void DigitButtonPress(string buttoncontent)
        {
            switch (buttoncontent)
            {
                case "C":
                case "CE":
                    {
                        _display = "0";
                        _firstOperand = string.Empty;
                        _secondOperand = string.Empty;
                        _operation = string.Empty;
                        _lastoperation = string.Empty;
                        _fullExpression = string.Empty;
                        DisplayBox.Text = "0";
                        ExpressionBox.Text = string.Empty;
                        break;
                    }

                case "Del":
                    if (_display.Length > 1)
                        _display = _display.Substring(0, _display.Length - 1);
                    else _display = "0";
                    break;
                case "+/-":
                    if (_display != "0" || _display.Contains("-"))
                    {
                        _display = _display.Remove(_display.IndexOf("-"), 1);
                    }
                    else if (_display == "0")
                    {

                    }
                    else _display = "-" + _display;
                    break;
                case ".":
                    if (new_displayRequired)
                    {
                        _display = "0.";
                    }
                    else
                    {
                        if (!_display.Contains("."))
                        {
                            _display = _display + ".";
                        }
                    }
                    break;
                default:
                    if (_display == "0" || new_displayRequired)
                    {
                        _display = _fullExpression = buttoncontent;
                        DisplayBox.Text = _display;
                        ExpressionBox.Text = _fullExpression;
                    }

                    else
                    {
                        _display = _fullExpression = _display + buttoncontent;
                        DisplayBox.Text = _display;
                        ExpressionBox.Text = _fullExpression;
                    }

                    break;
            }
            new_displayRequired = false;

            if (_isfirstoperandset == false)
            {
                _firstOperand = _display;
            }
            else
            {
                _secondOperand = _display;
            }


        }


        private bool isdigit(string input)
        {
            return (input == ("1") || input == ("2") || input == ("3") || input == ("4") || input == ("5") ||
                input == ("6") || input == ("7") || input == ("8") || input == ("9") || input == ("0")
                || input == ("C") || input == ("CE") || input == ("+/-"))
                ? true
                : false;
        }
        private bool isoperation(string input)
        {
            return (input == ("+") || input == ("-") || input == ("/") || input == ("*") || input == ("="))
                ? true
                : false;
        }
        private bool istrigo(string input)
        {
            return (input.Contains("Cos(x)") || input == ("Tan(x)") || input == ("Sin(x)"))
                ? true
                : false;
        }








    }
}
