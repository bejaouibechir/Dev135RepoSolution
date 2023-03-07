using ArithmetiqueAppMVVM.Helpers.Commands;
using ArithmetiqueAppMVVM.Models;
using System;
using System.ComponentModel;
using System.Windows;

namespace ArithmetiqueAppMVVM.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        

        private CalculatorModel _model;

        public ViewModel()
        {
            CancelCmd = new CancelCommand();
            CalculateCmd = new CalculateCommand(this);
            Model = new CalculatorModel();
        }

#region commandes
        public CancelCommand CancelCmd { get; set; }
        public CalculateCommand CalculateCmd { get; set; }

        #endregion

        #region propriétés
        public CalculatorModel Model 
        { 
            get { return _model; }
            set {
                
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

#endregion

        public void Calculate(int operation)
        {
            
            try
            {
                switch (operation)
                {
                    case 0:
                        {
                            Model.Resultat = Model.Operande1 + Model.Operande2;
                            MessageBox.Show($"Le resultat de somme est {Model.Resultat}");
                            break;
                        }
                    case 1:
                        {
                            Model.Resultat = Model.Operande1 - Model.Operande2;
                            MessageBox.Show($"Le resultat de soustraction est {Model.Resultat}");
                            break;
                        }
                    case 2:
                        {
                            Model.Resultat = Model.Operande1 * Model.Operande2;
                            MessageBox.Show($"Le resultat de multiplication est {Model.Resultat}");
                            break;
                        }
                    case 3:
                        {
                            try
                            {
                                if (Model.Operande2 == 0)
                                    throw new DivideByZeroException("La division par zéro n'est pas permise");

                                Model.Resultat = Model.Operande1 / Model.Operande2;
                                MessageBox.Show($"Le resultat de multiplication est {Model.Resultat}");
                            }
                            catch (DivideByZeroException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            break;
                        }
                    default:
                        throw new ArgumentException("Il faut choisir une operation à partir de la liste" +
                            " déroulante");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        


        #region mecanisme de notification

        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged!= null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

    }
}
