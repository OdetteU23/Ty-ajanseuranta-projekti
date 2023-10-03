using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        private const string FileName = "user_data.csv";
        private List<UserData> userDataList = new List<UserData>();

        public MainWindow()
        {
            InitializeComponent();
            userDataList = CsvDataReader.ReadCsv(FileName);
            PopulateUserComboBox();
        }

        public class UserData
        {
            public string? Username { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
        }

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
                                DateTime.TryParseExact(values[1], "dd.MM.yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime startTime) &&
                                DateTime.TryParseExact(values[2], "dd.MM.yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime endTime))
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

        private void PopulateUserComboBox()
        {
            var distinctUsernames = userDataList.Select(data => data.Username).Distinct().ToList();
            userComboBox.ItemsSource = distinctUsernames;
        }

        private void SeeUserData(object sender, RoutedEventArgs e)
        {
            try
            {
                string? selectedUsername = userComboBox?.SelectedItem as string;

                if (string.IsNullOrEmpty(selectedUsername))
                {
                    MessageBox.Show("Please select a username.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var userDataForSelectedUser = userDataList.Where(data => data.Username == selectedUsername);
                double totalHours = 0;

                StringBuilder userDataBuilder = new StringBuilder();
                foreach (var data in userDataForSelectedUser)
                {
                    double hoursWorked = (data.EndTime - data.StartTime).TotalHours;
                    totalHours += hoursWorked;
                    userDataBuilder.AppendLine($"Start Time: {data.StartTime}, End Time: {data.EndTime}, Hours Worked: {hoursWorked:F2} hours");
                }

                MessageBox.Show($"User: {selectedUsername}\n\n{userDataBuilder.ToString()}\nTotal Hours Worked: {totalHours:F2} hours", "User Data", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading and processing CSV data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool TryParseTime(string timeString, out DateTime result)
        {
            return DateTime.TryParseExact(timeString, "dd.MM.yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out result);
        }

        private void OnSaveButtonClick(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            DateTime startTime;
            DateTime endTime;

            // Parse start time
            if (!TryParseTime(startTimeTextBox.Text, out startTime))
            {
                MessageBox.Show("Please enter a valid start time.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Parse end time
            if (!TryParseTime(endTimeTextBox.Text, out endTime))
            {
                MessageBox.Show("Please enter a valid end time.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string csvLine = $"{username},{startTime.ToString("dd.MM.yyyy HH:mm")},{endTime.ToString("dd.MM.yyyy HH:mm")}";

            try
            {
                File.AppendAllLines(FileName, new[] { csvLine }, Encoding.UTF8);

                // Update the user data list and the ComboBox
                userDataList.Add(new UserData
                {
                    Username = username,
                    StartTime = startTime,
                    EndTime = endTime
                });
                PopulateUserComboBox();

                string filePath = Path.GetFullPath(FileName);
                MessageBox.Show($"Data saved to: {filePath}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
