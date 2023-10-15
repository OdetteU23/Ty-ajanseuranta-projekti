using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for AddNoteWindow.xaml
    /// </summary>
    public partial class AddNoteWindow : Window

    {
        private const string FileName = "notes-data.csv";
        private string FilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);

        public AddNoteWindow()
        {
            InitializeComponent();
        }

        

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            string noteText = addNoteTextbox.Text.Trim();
            // date from the DatePicker
            DateTime date = datePicker.SelectedDate ?? DateTime.MinValue;

            


            
            
                string csvLine = $"{date.ToString("dd.MM.yyyy")},{addNoteTextbox.ToString()}";

                try
                {
                    // luodaan uusi tiedosto jos vanhaa ei ole
                    if (!File.Exists(FilePath))
                    {

                        string header = "Date,Notetext";
                        File.WriteAllText(FilePath, header + Environment.NewLine);
                    }

                    // Luodaan uusi rivi tietoa
                    File.AppendAllText(FilePath, csvLine + Environment.NewLine);

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            
        }

        

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    
}
