using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Input;
using WPFProjects.Calculator.MVVM.Helpers.Commands;
using WPFProjects.Calculator.MVVM.Model;


namespace WPFProjects.Calculator.MVVM.ViewModel
{
    public class ViewModel :ViewModelBase
    {
        #region champs privés

        private Calcul model;

        private DelegateCommand<string> _digitButtonPressCommand;
        private DelegateCommand<string> _operationButtonPressCommand;
        private DelegateCommand<string> _singular_operationButtonPressCommand;

        private string lastOperation;
        private bool newDisplayRequired = false;
        private string fullExpression;
        private string display;

        #endregion

        #region Constructeur

        public ViewModel()
        {
            model = new Calcul();
            display = "0";
            FirstOperand = string.Empty;
            SecondOperand = string.Empty;
            Operation = string.Empty;
            lastOperation = string.Empty;
            fullExpression = string.Empty;
        }

        #endregion

        #region Propriétés publiques

        public string FirstOperand
        {
            get { return model.FirstOperand; }
            set { 
                model.FirstOperand = value;
                OnPropertyChanged(nameof(FirstOperand));
            }
        }

        public string SecondOperand
        {
            get { return model.SecondOperand; }
            set {
                model.SecondOperand = value;
                OnPropertyChanged(nameof(SecondOperand));
            }
        }

        public string Operation
        {
            get { return model.Operation; }
            set { model.Operation = value; 
            OnPropertyChanged(nameof(Operation));
            }
        }

        public string LastOperation
        {
            get { return lastOperation; }
            set { lastOperation = value; 
             OnPropertyChanged(nameof(LastOperation));
            }
        }

        public string Result
        {
            get { return model.Result; }
        }

        public string Display
        {
            get { return display; }
            set
            {
                display = value;
                OnPropertyChanged(nameof(Display));
            }
        }

        public string FullExpression
        {
            get { return fullExpression; }
            set
            {
                fullExpression = value;
                OnPropertyChanged(nameof(fullExpression));
            }
        }

        #endregion

        #region Les commandes

        public ICommand OperationButtonPressCommand
        {
            get
            {
                if (_operationButtonPressCommand == null)
                {
                    _operationButtonPressCommand = new DelegateCommand<string>(
                        OperationButtonPress, CanOperationButtonPress);
                }
                return _operationButtonPressCommand;
            }
        }
        private static bool CanOperationButtonPress(string number)
        {
            return true;
        }


        public ICommand Singular_operationButtonPressCommand
        {
            get
            {
                if (_singular_operationButtonPressCommand == null)
                {
                    _singular_operationButtonPressCommand = new DelegateCommand<string>(
                         SingularOperationButtonPress, CanSingularOperationButtonPress);
                }
                return _singular_operationButtonPressCommand;
            }
        }

        private static bool CanSingularOperationButtonPress(string number)
        {
            return true;
        }


        public ICommand DigitButtonPressCommand
        {
            get
            {
                if (_digitButtonPressCommand == null)
                {
                    _digitButtonPressCommand = new DelegateCommand<string>(
                        DigitButtonPress, CanDigitButtonPress);
                }
                return _digitButtonPressCommand;
            }
        }

        private static bool CanDigitButtonPress(string button)
        {
            return true;
        }


        //Gère les entrées numeriques
        public void DigitButtonPress(string button)
        {
            switch (button)
            {
                case "C":
                    Display = "0";
                    FirstOperand = string.Empty;
                    SecondOperand = string.Empty;
                    Operation = string.Empty;
                    LastOperation = string.Empty;
                    FullExpression = string.Empty;
                    break;
                case "Del":
                    if (display.Length > 1)
                        Display = display.Substring(0, display.Length - 1);
                    else Display = "0";
                    break;
                case "+/-":
                    if (display.Contains("-") || display == "0")
                    {
                        Display = display.Remove(display.IndexOf("-"), 1);
                    }
                    else Display = "-" + display;
                    break;
                case ".":
                    if (newDisplayRequired)
                    {
                        Display = "0.";
                    }
                    else
                    {
                        if (!display.Contains("."))
                        {
                            Display = display + ".";
                        }
                    }
                    break;
                default:
                    if (display == "0" || newDisplayRequired)
                        Display = button;
                    else
                        Display = display + button;
                    break;
            }
            newDisplayRequired = false;
        }

        //Gère les opérations binaires
        public void OperationButtonPress(string operation)
        {
            try
            {
                if (FirstOperand == string.Empty || LastOperation == "=")
                {
                    FirstOperand = display;
                    LastOperation = operation;
                }
                else
                {
                    SecondOperand = display;
                    Operation = lastOperation;
                    model.CalculateResult();

                    FullExpression = Math.Round(Convert.ToDouble(FirstOperand), 10) + " " + Operation + " "
                                    + Math.Round(Convert.ToDouble(SecondOperand), 10) + " = "
                                    + Math.Round(Convert.ToDouble(Result), 10);

                    LastOperation = operation;
                    Display = Result;
                    FirstOperand = display;
                }
                newDisplayRequired = true;
            }
            catch (Exception ex)
            {
                Display = Result == string.Empty ? "Error - see event log" : Result;
                LogExceptionInformation(ex);
            }
        }

        //Gère les fonctions trigo
        public void SingularOperationButtonPress(string operation)
        {
            try
            {
                FirstOperand = Display;
                Operation = operation;
                model.CalculateResult();

                FullExpression = Operation + "(" + Math.Round(Convert.ToDouble(FirstOperand), 10) + ") = "
                    + Math.Round(Convert.ToDouble(Result), 10);

                LastOperation = "=";
                Display = Result;
                FirstOperand = display;
                newDisplayRequired = true;
            }
            catch (Exception ex)
            {
                Display = Result == string.Empty ? "Error - see event log" : Result;
                LogExceptionInformation(ex);
            }
        }

        //Trace les erreurs
        private static void LogExceptionInformation(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }

        #endregion
    }
}

