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
using static WpfApp3.MainWindow;

namespace WpfApp3.MVVM.View
{
    /// <summary>
    /// Interaction logic for CalendarView.xaml
    /// </summary>
    public partial class CalendarView : UserControl
    {
        List<UserData> userDataList = new List<UserData>();

        string username = "Jussi";


        public CalendarView()
        {
            InitializeComponent();
        }
                
        private void TextBlock_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        // nappi. nappi joka jopa ehkä toimii
        void OnButtonAdd_Click(object sender, RoutedEventArgs e)
        {
          new MainWindow().Show();
        }

        //uuuuuuuu oikeesti toimii 
        void OnButtonNext_Click(object sender, RoutedEventArgs e)
        {
          new MainWindow().Show();
            
          new MainWindow().Show();
          
        }

        //eheheheh jeccu? >:D eipä ollukkaan ku en osaa
        
        void OnButtonPrevious_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            
        }

        void OnButtonShow_Click(object sender, RoutedEventArgs e)
        {
            //ö luetaan tietokanta ja haetaan sieltä JUSSIN tiedot
            userDataList = CsvDataReader.ReadCsv("user_data.csv");

            var userDataForSelectedUser = userDataList.Where(data => data.Username == username);
            double totalHours = 0;

            
            foreach (var data in userDataForSelectedUser)
            {
                //täs on vielä se homma joka laskee jussin tiedot
                double hoursWorked = (data.EndTime - data.StartTime).TotalHours;
                totalHours += hoursWorked;
                
            }

            TotalHoursTextBlock.Text = totalHours.ToString();
        }
    }
}
