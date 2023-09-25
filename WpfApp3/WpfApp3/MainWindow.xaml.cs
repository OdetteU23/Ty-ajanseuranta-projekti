using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        private const string FileName = "user_data.csv";

        public MainWindow()
        {
            InitializeComponent();
        }
        //alustaa userdatan
        public class UserData
        {
            public string Username { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
        }
        //lukee csv tiedoston ja tallentaa ohjelman dataan
        public class CsvDataReader
        {
            public static List<UserData> ReadCsv(string filePath)
            {
                List<UserData> userDataList = new List<UserData>();

                try
                {
                    using (var reader = new StreamReader(filePath))
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(',');

                            if (values.Length == 3 &&
                                DateTime.TryParse(values[1], out DateTime startTime) &&
                                DateTime.TryParse(values[2], out DateTime endTime))
                            {
                                var userData = new UserData
                                {
                                    Username = values[0],
                                    StartTime = startTime,
                                    EndTime = endTime
                                };

                                userDataList.Add(userData);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading CSV file: {ex.Message}");
                }

                return userDataList;
            }
        }
        //tallentaa syötetyt tiedot riviksi user.data tiedostoon
        private void OnSaveButtonClick(object sender, RoutedEventArgs e)

        {
            string username = usernameTextBox.Text.Trim();
            DateTime startTime;
            DateTime endTime;

            if (TryParseTime(startTimeTextBox.Text, out startTime) &&
                TryParseTime(endTimeTextBox.Text, out endTime))
            {
                string csvLine = $"{username},{startTime.ToString("dd.MM.yyyy HH:mm")},{endTime.ToString("dd.MM.yyyy HH:mm")}";

                try
                {
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

        // See userdata nappi
        private void SeeUserData(object sender, RoutedEventArgs e)
        {
            try
            {
                string csvContent = File.ReadAllText(FileName);
                MessageBox.Show($"CSV Content:\n{csvContent}", "CSV Content", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading CSV content: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // muokkaa pvm ja aikoja oikeaan muotoon
        private bool TryParseTime(string timeString, out DateTime result)
        {
            return DateTime.TryParseExact(timeString, "dd.MM.yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out result);
        }
    }
}