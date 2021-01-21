using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfApp2.Model
{
    public class TaskListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        /*
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
                NotifyPropertyChanged("Id");
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
                if (value != _Name)
                {
                    _Name = value;
                    NotifyPropertyChanged("Name");
                }
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
                NotifyPropertyChanged("Description");
            }
        }

        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName )
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        */
    }
}
