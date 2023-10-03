using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Core;

namespace WpfApp3.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        
        public RelayCommand CalendarViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public CalendarViewModel CalendarVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { 
                
                _currentView = value; 
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            CalendarVM = new CalendarViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            CalendarViewCommand = new RelayCommand(o =>
            {
                CurrentView = CalendarVM;
            });
        }

    }
}
