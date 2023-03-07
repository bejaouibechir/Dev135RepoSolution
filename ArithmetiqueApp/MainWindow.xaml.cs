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

namespace ArithmetiqueApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void CalculateBtn_Click(object sender, RoutedEventArgs e)
        {
            double operande1, operande2, resultat;

            try
            {
                switch (operationcmb.Text)
                {
                    case "Addition \"+\"":
                        {
                            double.TryParse(txtoperande1.Text, out operande1);
                            double.TryParse(txtoperande2.Text, out operande2);
                            resultat = operande1 + operande2;
                            lblResultat.Content = $"Le resultat est {resultat}";
                            break;
                        }
                    case "Soustraction \"-\"":
                        {
                            double.TryParse(txtoperande1.Text, out operande1);
                            double.TryParse(txtoperande2.Text, out operande2);
                            resultat = operande1 - operande2;
                            lblResultat.Content = $"Le resultat est {resultat}";
                            break;
                        }
                    case "Multiplcation \"*\"":
                        {
                            double.TryParse(txtoperande1.Text, out operande1);
                            double.TryParse(txtoperande2.Text, out operande2);
                            resultat = operande1 * operande2;
                            lblResultat.Content = $"Le resultat est {resultat}";
                            break;
                        }
                    case "Division \"/\"":
                        {
                            double.TryParse(txtoperande1.Text, out operande1);
                            double.TryParse(txtoperande2.Text, out operande2);
                            if (operande2 != 0)
                            {
                                resultat = operande1 / operande2;
                            }
                            else
                            {
                                return;
                            }
                            lblResultat.Content = $"Le resultat est {resultat}";
                            break;
                        }

                    default:
                        throw new Exception("Il faut choisir une opération ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
