using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using WpfApp3.MVVM.View;

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        private const string FileName = "user_data.csv";
        private string FilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);
        private CalendarView calendarView;

        public MainWindow(CalendarView calendarView)
        {
            InitializeComponent();
            InitializeComponent();
            this.calendarView = calendarView;


        }

        //tallentaa tiedet csv tiedostoon
        private void OnSaveButtonClick(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            DateTime date = datePicker.SelectedDate ?? DateTime.MinValue; // Get the selected date from the DatePicker
            DateTime startTime;
            DateTime endTime;

            if (!TryParseTime(startTimeTextBox.Text, date, out startTime))
            {
                MessageBox.Show("Please enter a valid start time.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!TryParseTime(endTimeTextBox.Text, date, out endTime))
            {
                MessageBox.Show("Please enter a valid end time.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // CSV muoto username, date, starttime, and endtime
            string csvLine = $"{username},{date.ToString("dd.MM.yyyy")},{startTime.ToString("HH:mm")},{endTime.ToString("HH:mm")}";

            try
            {
                // luodaan uusi tiedosto jos vanhaa ei ole
                if (!File.Exists(FilePath))
                {
             
                    string header = "Username,Date,StartTime,EndTime";
                    File.WriteAllText(FilePath, header + Environment.NewLine);
                }

                // Luodaan uusi rivi tietoa
                File.AppendAllText(FilePath, csvLine + Environment.NewLine);

                calendarView.UpdateDisplayForCurrentWeek();
                MessageBox.Show($"Data saved to: {FilePath}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool TryParseTime(string timeString, DateTime date, out DateTime result)
        {
            string combinedDateTimeString = $"{date.ToString("dd.MM.yyyy")} {timeString}";
            return DateTime.TryParseExact(combinedDateTimeString, "dd.MM.yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out result);
        }

    }
}
