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
using System.IO;

namespace WpfApp3.MVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Compare : Window
    {
        public Compare()
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

       

        private void Grid_RowDefinitions(object sender, RoutedEventArgs e)
        {

        }
        private DateTime GetMondayOfCurrentWeek(DateTime currentDate)
        {
            int daysUntilMonday = ((int)currentDate.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
            DateTime mondayOfWeek = currentDate.AddDays(-daysUntilMonday);
            return mondayOfWeek;
        }
        private double GetActualHoursForWeekFromCSV(string username)
        {
            //csv tiedoston sijainti sama kuin exe
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string csvFilePath = "user_data.csv";
            csvFilePath = System.IO.Path.Combine(executablePath, csvFilePath);

            
            DateTime currentWeekStart = GetMondayOfCurrentWeek(DateTime.Now);
            DateTime currentWeekEnd = currentWeekStart.AddDays(6);

            
            string[] csvLines = File.ReadAllLines(csvFilePath);
            double actualHours = 0;

            foreach (var line in csvLines)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 4 && parts[0] == username)
                {
                    if (DateTime.TryParseExact(parts[1], "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime entryDate))
                    {
                        if (entryDate >= currentWeekStart && entryDate <= currentWeekEnd)
                        {
                            if (TimeSpan.TryParse(parts[3], out TimeSpan endTime) && TimeSpan.TryParse(parts[2], out TimeSpan startTime))
                            {
                                actualHours += (endTime - startTime).TotalHours;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error parsing date from CSV.");
                        return -1;
                    }
                }
            }

            return actualHours;
        }
        private double GetActualHoursForLastWeekFromCSV(string username)
        {
            //csv tiedoston sijainti sama kuin exe
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string csvFilePath = "user_data.csv";
            csvFilePath = System.IO.Path.Combine(executablePath, csvFilePath);

            
            DateTime lastWeekStart = GetMondayOfCurrentWeek(DateTime.Now).AddDays(-7);
            DateTime lastWeekEnd = lastWeekStart.AddDays(6);

            
            string[] csvLines = File.ReadAllLines(csvFilePath);
            double actualHours = 0;

            foreach (var line in csvLines)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 4 && parts[0] == username)
                {
                    if (DateTime.TryParseExact(parts[1], "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime entryDate))
                    {
                        if (entryDate >= lastWeekStart && entryDate <= lastWeekEnd)
                        {
                            if (TimeSpan.TryParse(parts[3], out TimeSpan endTime) && TimeSpan.TryParse(parts[2], out TimeSpan startTime))
                            {
                                actualHours += (endTime - startTime).TotalHours;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error parsing date from CSV.");
                        return -1; // Return -1 to indicate an error
                    }
                }
            }

            return actualHours;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = TextBox1.Text;

            if (double.TryParse(TextBox2.Text, out double targetHours))
            {
                double actualHours = GetActualHoursForWeekFromCSV(username);
                double differenceCurrentWeek = actualHours - targetHours;
                double differenceLastWeek = GetActualHoursForLastWeekFromCSV(username) - targetHours;

                string resultText = $"This week:\n";
                resultText += $"  Target hours: {targetHours:F2} hours\n";
                resultText += $"  Actual hours: {actualHours:F2} hours\n";

                if (differenceCurrentWeek < 0)
                    resultText += $"  Underworked by {Math.Abs(differenceCurrentWeek):F2} hours from the target.\n";
                else if (differenceCurrentWeek > 0)
                    resultText += $"  Exceeded by {differenceCurrentWeek:F2} hours from the target.\n";
                else
                    resultText += $"  Achieved the target hours exactly.\n";

                resultText += $"\nLast week:\n";
                resultText += $"  Target hours: {targetHours:F2} hours\n";
                resultText += $"  Actual hours: {GetActualHoursForLastWeekFromCSV(username):F2} hours\n";

                if (differenceLastWeek < 0)
                    resultText += $"  Underworked by {Math.Abs(differenceLastWeek):F2} hours from the target.\n";
                else if (differenceLastWeek > 0)
                    resultText += $"  Exceeded by {differenceLastWeek:F2} hours from the target.\n";
                else
                    resultText += $"  Achieved the target hours exactly.\n";

                TulosBlock.Text = resultText;
            }
            else
            {
                TulosBlock.Text = "Invalid target hour count. Please enter numbers correctly.";
            }
        }

    }
}
