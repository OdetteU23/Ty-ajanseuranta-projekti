using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace WpfApp3.MVVM.View
{
    /// <summary>
    /// Interaction logic for NotesView.xaml
    /// </summary>
    public partial class NotesView : UserControl
    {
        

        public NotesView()
        {
            InitializeComponent();
        }

        private void ButtonLoadNote_Click(object sender, RoutedEventArgs e)
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string csvFilePath = "notes-data.csv";
            csvFilePath = System.IO.Path.Combine(executablePath, csvFilePath);
            
            // now read it
            
            //if (DatePicker == DateTime.Today)
            //{
            //    noteDisplay.Text = textContent;
            //}

            if (File.Exists(csvFilePath)) 
            {
                string textContent = File.ReadAllText(csvFilePath);

                noteDisplay.Text = textContent;
            }

        }

        private void ButtonEditNote_Click(object sender, RoutedEventArgs e)
        {
            new AddNoteWindow().Show();
        }

        
    }
}
