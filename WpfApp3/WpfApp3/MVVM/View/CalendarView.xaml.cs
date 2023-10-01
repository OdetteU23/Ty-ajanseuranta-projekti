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

namespace WpfApp3.MVVM.View
{
    /// <summary>
    /// Interaction logic for CalendarView.xaml
    /// </summary>
    public partial class CalendarView : UserControl
    {
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
        
    }
}
