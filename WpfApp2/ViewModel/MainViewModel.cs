using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WpfApp2.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; set; }
        private BaseViewModel selectedViewModel;

        public BaseViewModel SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
    }
}
