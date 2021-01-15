using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfApp2.Model
{
    public class TaskList : INotifyPropertyChanged
    {
        /*
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        */
        //public double Amount { get; set; }

        private int _Id;
        private string _Name;
        private string _Description;
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
                OnPropertyChanged("Description");
            }
        }

        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
