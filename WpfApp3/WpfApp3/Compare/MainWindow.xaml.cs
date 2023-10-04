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

namespace Tavoiteltut_ja_toteutuneet
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {


        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Text_Input(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TextBox1.Text, out double totalHours) && double.TryParse(TextBox2.Text, out double targetHours))

            {
                double Tunti = totalHours - targetHours;
                string TulosText = $"  Tavoitellut tunnit: {targetHours:F2} Tunnit\n";
                TulosText += $"  Toteutuneet tunnit: {totalHours:F2} Tunnit\n";
                TulosText += $" Ylitehty/Alitehty: {Tunti:F2} Tunnit\n";
                TulosText += $" Mikäli luku on negatiivinen, se tarkoittaa, että tavoitetunteja ei ole saavutettu.\n";
                TulosText += $" Ja jos luku on positiivinen, se tarkoittaa, että tavoitetunnit on ylitetty.";
                TulosBlock.Text = TulosText;
            }
            else
            {
                TulosBlock.Text = "Varaa syöte. Kirjoita numerot oikein";
            }
        }

        private void Grid_RowDefinitions(object sender, RoutedEventArgs e)
        {

        }
    }
}
