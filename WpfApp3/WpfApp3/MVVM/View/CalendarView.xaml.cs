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
using System.IO;


namespace WpfApp3.MVVM.View
{
    /// <summary>
    /// Interaction logic for CalendarView.xaml
    /// </summary>
    public partial class CalendarView : UserControl
    {


        string username = "Jussi";
        private DateTime mondayDate;
        private DateTime tuesdayDate;
        private DateTime wednesdayDate;
        private DateTime thursdayDate;
        private DateTime fridayDate;
        private DateTime saturdayDate;
        private DateTime sundayDate;
        public string mondayDateLong;
        public string tuesdayDateLong;
        public string wednesdayDateLong;
        public string thursdayDateLong;
        public string fridayDateLong;
        public string saturdayDateLong;
        public string sundayDateLong;




        public CalendarView()
        {
            InitializeComponent();

            mondayDate = GetMondayOfCurrentWeek(DateTime.Now);
            mondayDateLong = mondayDate.ToString("dd.MM.yyyy");
            mondayDateTextBox.Text = mondayDate.ToString("dd/MM");

            tuesdayDate = mondayDate.AddDays(1);
            tuesdayDateLong = tuesdayDate.ToString("dd.MM.yyyy");
            tuesdayDateTextBox.Text = tuesdayDate.ToString("dd/MM");

            wednesdayDate = mondayDate.AddDays(2);
            wednesdayDateLong = wednesdayDate.ToString("dd.MM.yyyy");
            wednesdayDateTextBox.Text = wednesdayDate.ToString("dd/MM");

            thursdayDate = mondayDate.AddDays(3);
            thursdayDateLong = thursdayDate.ToString("dd.MM.yyyy");
            thursdayDateTextBox.Text = thursdayDate.ToString("dd/MM");

            fridayDate = mondayDate.AddDays(4);
            fridayDateLong = fridayDate.ToString("dd.MM.yyyy");
            fridayDateTextBox.Text = fridayDate.ToString("dd/MM");

            saturdayDate = mondayDate.AddDays(5);
            saturdayDateLong = saturdayDate.ToString("dd.MM.yyyy");
            saturdayDateTextBox.Text = saturdayDate.ToString("dd/MM");

            sundayDate = mondayDate.AddDays(6);
            sundayDateLong = sundayDate.ToString("dd.MM.yyyy");
            sundayDateTextBox.Text = sundayDate.ToString("dd/MM");

            UpdateDisplayForCurrentWeek();


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

            MainWindow mainWindow = new MainWindow(this);
            mainWindow.Show();
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

            mondayDateLong = mondayDate.ToString("dd.MM.yyyy");
            tuesdayDateLong = tuesdayDate.ToString("dd.MM.yyyy");
            wednesdayDateLong = wednesdayDate.ToString("dd.MM.yyyy");
            thursdayDateLong = thursdayDate.ToString("dd.MM.yyyy");
            fridayDateLong = fridayDate.ToString("dd.MM.yyyy");
            saturdayDateLong = saturdayDate.ToString("dd.MM.yyyy");
            sundayDateLong = sundayDate.ToString("dd.MM.yyyy");

            // päiviteteen teksti kentät
            mondayDateTextBox.Text = mondayDate.ToString("dd/MM");
            tuesdayDateTextBox.Text = tuesdayDate.ToString("dd/MM");
            wednesdayDateTextBox.Text = wednesdayDate.ToString("dd/MM");
            thursdayDateTextBox.Text = thursdayDate.ToString("dd/MM");
            fridayDateTextBox.Text = fridayDate.ToString("dd/MM");
            saturdayDateTextBox.Text = saturdayDate.ToString("dd/MM");
            sundayDateTextBox.Text = sundayDate.ToString("dd/MM");

            UpdateDisplayForCurrentWeek();
        }


        void OnButtonPrevious_Click(object sender, RoutedEventArgs e)
        {
            mondayDate = mondayDate.AddDays(-7);

            tuesdayDate = tuesdayDate.AddDays(-7);
            wednesdayDate = wednesdayDate.AddDays(-7);
            thursdayDate = thursdayDate.AddDays(-7);
            fridayDate = fridayDate.AddDays(-7);
            saturdayDate = saturdayDate.AddDays(-7);
            sundayDate = sundayDate.AddDays(-7);

            mondayDateLong = mondayDate.ToString("dd.MM.yyyy");
            tuesdayDateLong = tuesdayDate.ToString("dd.MM.yyyy");
            wednesdayDateLong = wednesdayDate.ToString("dd.MM.yyyy");
            thursdayDateLong = thursdayDate.ToString("dd.MM.yyyy");
            fridayDateLong = fridayDate.ToString("dd.MM.yyyy");
            saturdayDateLong = saturdayDate.ToString("dd.MM.yyyy");
            sundayDateLong = sundayDate.ToString("dd.MM.yyyy");

            // päiviteteen teksti kentät
            mondayDateTextBox.Text = mondayDate.ToString("dd/MM");
            tuesdayDateTextBox.Text = tuesdayDate.ToString("dd/MM");
            wednesdayDateTextBox.Text = wednesdayDate.ToString("dd/MM");
            thursdayDateTextBox.Text = thursdayDate.ToString("dd/MM");
            fridayDateTextBox.Text = fridayDate.ToString("dd/MM");
            saturdayDateTextBox.Text = saturdayDate.ToString("dd/MM");
            sundayDateTextBox.Text = sundayDate.ToString("dd/MM");

            UpdateDisplayForCurrentWeek();
        }
        private void ReadCsvAndDisplayTimesMon(string username)
        {
            // sanoo että user.data on samassa kansiossa kui exe
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string csvFilePath = "user_data.csv";
            csvFilePath = System.IO.Path.Combine(executablePath, csvFilePath);
            // lukee csv tiedosten
            string[] csvLines = File.ReadAllLines(csvFilePath);

            // listaa  täsmäävät ajat
            List<string> matchingEntries = new List<string>();

            matchingEntries = csvLines
                .Where(line =>
                {
                    string[] parts = line.Split(',');
                    return parts.Length == 4 && parts[0] == username && parts[1] == mondayDateLong;
                })
                .ToList();

            // päivitetään maanantai laatikko täsmäävän ajan aloitus-lopetus ajalla
            if (matchingEntries.Count > 0)
            {
                string[] parts = matchingEntries[0].Split(',');
                string startTime = parts[2];
                string endTime = parts[3];
                string formattedTimes = $"{startTime}-{endTime}";

                Mondayworktimes.Text = formattedTimes;


            }
            else
            {
                // ei löydetty aikaa
                Mondayworktimes.Text = "no time found";
            }
        }
        private void ReadCsvAndDisplayTimesTue(string username)
        {
            // sanoo että user.data on samassa kansiossa kui exe
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string csvFilePath = "user_data.csv";
            csvFilePath = System.IO.Path.Combine(executablePath, csvFilePath);
            // lukee csv tiedosten
            string[] csvLines = File.ReadAllLines(csvFilePath);

            // listaa  täsmäävät ajat
            List<string> matchingEntries = new List<string>();

            matchingEntries = csvLines
                .Where(line =>
                {
                    string[] parts = line.Split(',');
                    return parts.Length == 4 && parts[0] == username && parts[1] == tuesdayDateLong;
                })
                .ToList();

            // päivitetään maanantai laatikko täsmäävän ajan aloitus-lopetus ajalla
            if (matchingEntries.Count > 0)
            {
                string[] parts = matchingEntries[0].Split(',');
                string startTime = parts[2];
                string endTime = parts[3];
                string formattedTimes = $"{startTime}-{endTime}";

                Tuesdayworktimes.Text = formattedTimes;


            }
            else
            {
                // ei löydetty aikaa
                Tuesdayworktimes.Text = "no time found";
            }
        }
        private void ReadCsvAndDisplayTimesWed(string username)
        {
            // sanoo että user.data on samassa kansiossa kui exe
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string csvFilePath = "user_data.csv";
            csvFilePath = System.IO.Path.Combine(executablePath, csvFilePath);
            // lukee csv tiedosten
            string[] csvLines = File.ReadAllLines(csvFilePath);

            // listaa  täsmäävät ajat
            List<string> matchingEntries = new List<string>();

            matchingEntries = csvLines
                .Where(line =>
                {
                    string[] parts = line.Split(',');
                    return parts.Length == 4 && parts[0] == username && parts[1] == wednesdayDateLong;
                })
                .ToList();

            // päivitetään maanantai laatikko täsmäävän ajan aloitus-lopetus ajalla
            if (matchingEntries.Count > 0)
            {
                string[] parts = matchingEntries[0].Split(',');
                string startTime = parts[2];
                string endTime = parts[3];
                string formattedTimes = $"{startTime}-{endTime}";

                Wednesdayworktimes.Text = formattedTimes;


            }
            else
            {
                // ei löydetty aikaa
                Wednesdayworktimes.Text = "no time found";
            }
        }
        private void ReadCsvAndDisplayTimesThu(string username)
        {
            // sanoo että user.data on samassa kansiossa kui exe
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string csvFilePath = "user_data.csv";
            csvFilePath = System.IO.Path.Combine(executablePath, csvFilePath);
            // lukee csv tiedosten
            string[] csvLines = File.ReadAllLines(csvFilePath);

            // listaa  täsmäävät ajat
            List<string> matchingEntries = new List<string>();

            matchingEntries = csvLines
                .Where(line =>
                {
                    string[] parts = line.Split(',');
                    return parts.Length == 4 && parts[0] == username && parts[1] == thursdayDateLong;
                })
                .ToList();

            // päivitetään maanantai laatikko täsmäävän ajan aloitus-lopetus ajalla
            if (matchingEntries.Count > 0)
            {
                string[] parts = matchingEntries[0].Split(',');
                string startTime = parts[2];
                string endTime = parts[3];
                string formattedTimes = $"{startTime}-{endTime}";

                Thursdayworktimes.Text = formattedTimes;


            }
            else
            {
                // ei löydetty aikaa
                Thursdayworktimes.Text = "no time found";
            }
        }
        private void ReadCsvAndDisplayTimesFri(string username)
        {
            // sanoo että user.data on samassa kansiossa kui exe
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string csvFilePath = "user_data.csv";
            csvFilePath = System.IO.Path.Combine(executablePath, csvFilePath);
            // lukee csv tiedosten
            string[] csvLines = File.ReadAllLines(csvFilePath);

            // listaa  täsmäävät ajat
            List<string> matchingEntries = new List<string>();

            matchingEntries = csvLines
                .Where(line =>
                {
                    string[] parts = line.Split(',');
                    return parts.Length == 4 && parts[0] == username && parts[1] == fridayDateLong;
                })
                .ToList();

            // päivitetään maanantai laatikko täsmäävän ajan aloitus-lopetus ajalla
            if (matchingEntries.Count > 0)
            {
                string[] parts = matchingEntries[0].Split(',');
                string startTime = parts[2];
                string endTime = parts[3];
                string formattedTimes = $"{startTime}-{endTime}";

                Fridayworktimes.Text = formattedTimes;


            }
            else
            {
                // ei löydetty aikaa
                Fridayworktimes.Text = "no time found";
            }
        }
        private void ReadCsvAndDisplayTimesSat(string username)
        {
            // sanoo että user.data on samassa kansiossa kui exe
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string csvFilePath = "user_data.csv";
            csvFilePath = System.IO.Path.Combine(executablePath, csvFilePath);
            // lukee csv tiedosten
            string[] csvLines = File.ReadAllLines(csvFilePath);

            // listaa  täsmäävät ajat
            List<string> matchingEntries = new List<string>();

            matchingEntries = csvLines
                .Where(line =>
                {
                    string[] parts = line.Split(',');
                    return parts.Length == 4 && parts[0] == username && parts[1] == saturdayDateLong;
                })
                .ToList();

            // päivitetään maanantai laatikko täsmäävän ajan aloitus-lopetus ajalla
            if (matchingEntries.Count > 0)
            {
                string[] parts = matchingEntries[0].Split(',');
                string startTime = parts[2];
                string endTime = parts[3];
                string formattedTimes = $"{startTime}-{endTime}";

                Saturdayworktimes.Text = formattedTimes;


            }
            else
            {
                // ei löydetty aikaa
                Saturdayworktimes.Text = "no time found";
            }
        }
        private void ReadCsvAndDisplayTimesSun(string username)
        {
            // sanoo että user.data on samassa kansiossa kui exe
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string csvFilePath = "user_data.csv";
            csvFilePath = System.IO.Path.Combine(executablePath, csvFilePath);
            // lukee csv tiedosten
            string[] csvLines = File.ReadAllLines(csvFilePath);

            // listaa  täsmäävät ajat
            List<string> matchingEntries = new List<string>();

            matchingEntries = csvLines
                .Where(line =>
                {
                    string[] parts = line.Split(',');
                    return parts.Length == 4 && parts[0] == username && parts[1] == sundayDateLong;
                })
                .ToList();

            // päivitetään maanantai laatikko täsmäävän ajan aloitus-lopetus ajalla
            if (matchingEntries.Count > 0)
            {
                string[] parts = matchingEntries[0].Split(',');
                string startTime = parts[2];
                string endTime = parts[3];
                string formattedTimes = $"{startTime}-{endTime}";

                Sundayworktimes.Text = formattedTimes;


            }
            else
            {
                // ei löydetty aikaa
                Sundayworktimes.Text = "no time found";
            }
        }

        internal void UpdateDisplayForCurrentWeek()
        {
            ReadCsvAndDisplayTimesMon(username);
            ReadCsvAndDisplayTimesTue(username);
            ReadCsvAndDisplayTimesWed(username);
            ReadCsvAndDisplayTimesThu(username);
            ReadCsvAndDisplayTimesFri(username);
            ReadCsvAndDisplayTimesSat(username);
            ReadCsvAndDisplayTimesSun(username);
        }

        void OnButtonShow_Click(object sender, RoutedEventArgs e)
        {

            new Compare().Show();

 
        }
    }
}
