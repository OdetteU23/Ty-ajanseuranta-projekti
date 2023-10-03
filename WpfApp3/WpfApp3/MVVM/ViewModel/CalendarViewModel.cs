using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Core;

namespace WpfApp3.MVVM.ViewModel
{
    class CalendarViewModel : ObservableObject
    {

        public RelayCommand AddCommand { get; set; }

        
        

        private object _addView;

        public object AddView
        {
            get { return _addView; }
            set
            {

                _addView = value;
                OnPropertyChanged();
            }
        }

    }
}
