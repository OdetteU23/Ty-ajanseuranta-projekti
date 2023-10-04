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
        DateTime mondayDate;
        DateTime tuesdayDate;
        DateTime wednesdayDate;
        DateTime thursdayDate;
        DateTime fridayDate;
        DateTime saturdayDate;
        DateTime sundayDate;
        



        public CalendarView()
        {
            InitializeComponent();

            DateTime mondayDate = GetMondayOfCurrentWeek(DateTime.Now);
            mondayDateTextBox.Text = mondayDate.ToString("dd/MM");

            DateTime tuesdayDate = mondayDate.AddDays(1);
            tuesdayDateTextBox.Text = tuesdayDate.ToString("dd/MM");

            DateTime wednesdayDate = mondayDate.AddDays(2);
            wednesdayDateTextBox.Text = wednesdayDate.ToString("dd/MM");

            DateTime thursdayDate = mondayDate.AddDays(3);
            thursdayDateTextBox.Text = thursdayDate.ToString("dd/MM");

            DateTime fridayDate = mondayDate.AddDays(4);
            fridayDateTextBox.Text = fridayDate.ToString("dd/MM");

            DateTime saturdayDate = mondayDate.AddDays(5);
            saturdayDateTextBox.Text = saturdayDate.ToString("dd/MM");

            DateTime sundayDate = mondayDate.AddDays(6);
            sundayDateTextBox.Text = sundayDate.ToString("dd/MM");


        }
        private DateTime GetMondayOfCurrentWeek(DateTime currentDate)
        {
            int daysUntilMonday = ((int)currentDate.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
            DateTime mondayOfWeek = currentDate.AddDays(-daysUntilMonday);
            return mondayOfWeek;
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
            // liseteen jokaiseen päivään 7 päivää (ensiviikko)
            mondayDate = mondayDate.AddDays(7);
            tuesdayDate = tuesdayDate.AddDays(7);
            wednesdayDate = wednesdayDate.AddDays(7);
            thursdayDate = thursdayDate.AddDays(7);
            fridayDate = fridayDate.AddDays(7);
            saturdayDate = saturdayDate.AddDays(7);
            sundayDate = sundayDate.AddDays(7);

            // päiviteteen teksti kentät
            mondayDateTextBox.Text = mondayDate.ToString("dd/MM");
            tuesdayDateTextBox.Text = tuesdayDate.ToString("dd/MM");
            wednesdayDateTextBox.Text = wednesdayDate.ToString("dd/MM");
            thursdayDateTextBox.Text = thursdayDate.ToString("dd/MM");
            fridayDateTextBox.Text = fridayDate.ToString("dd/MM");
            saturdayDateTextBox.Text = saturdayDate.ToString("dd/MM");
            sundayDateTextBox.Text = sundayDate.ToString("dd/MM");
        }

        //eheheheh jeccu? >:D eipä ollukkaan ku en osaa

        void OnButtonPrevious_Click(object sender, RoutedEventArgs e)
        {
            
          
           
        }

        void OnButtonShow_Click(object sender, RoutedEventArgs e)
        {

            new Compare().Show();

 
        }
    }
}
