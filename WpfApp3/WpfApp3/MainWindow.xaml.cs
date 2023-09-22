using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        private const string FileName = "user_data.csv";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSaveButtonClick(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            DateTime startTime;
            DateTime endTime;

            if (TryParseTime(startTimeTextBox.Text, out startTime) &&
                TryParseTime(endTimeTextBox.Text, out endTime))
            {
                string csvLine = $"{username},{startTime.ToString("yyyy-MM-ddTHH:mm:ss")},{endTime.ToString("yyyy-MM-ddTHH:mm:ss")}";

                try
                {
                    // Append the CSV line to the file
                    File.AppendAllLines(FileName, new[] { csvLine }, Encoding.UTF8);

                    string filePath = Path.GetFullPath(FileName);
                    MessageBox.Show($"Data saved to: {filePath}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid username, start time, and end time.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool TryParseTime(string timeString, out DateTime result)
        {
            return DateTime.TryParseExact(timeString, "dd.MM.yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out result);
        }
    }
}
