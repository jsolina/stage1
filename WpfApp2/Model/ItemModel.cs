using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfApp2.Model
{
    public class ItemModel
    {
        public int Id { get; set; }
        public int IdTask { get; set; }
        public string ItemName { get; set; }
        public string ItemDetails { get; set; }
        public string Status { get; set; }
        /*
        private int _Id;
        private int _IdTask;
        private string _ItemName;
        private string _ItemDetails;
        private string _Status;
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
        public int IdTask
        {
            get
            {
                return _IdTask;
            }
            set
            {
                _IdTask = value;
                OnPropertyChanged("IdTask");
            }
        }
        public string ItemName
        {
            get
            {
                return _ItemName;
            }
            set
            {
                _ItemName = value;
                OnPropertyChanged("ItemName");
            }
        }
        public string ItemDetails
        {
            get
            {
                return _ItemDetails;
            }
            set
            {
                _ItemDetails = value;
                OnPropertyChanged("ItemDetails");
            }
        }
        public string Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
                OnPropertyChanged("Status");
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
        */
    }
}
