﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Data;
using WpfApp2.Model;
using WpfApp2.Commnds;
using WpfApp2.View;
using System.Windows;

namespace WpfApp2.ViewModel
{
    public class ItemsViewModel : INotifyPropertyChanged
    {

        private IList<ItemModel> itemModel;
        private ItemModel ItemModelSelectedRow = new ItemModel();
        
        TaskListModel selectedRowTask = new TaskListModel();
        TaskListDbContext dbContext;

        public ItemsViewModel(TaskListDbContext _dbContext, TaskListModel _selectedRowTask)
        {
            this.dbContext = _dbContext;
            selectedRowTask = _selectedRowTask;
            GetData();
        }

        public void GetData()
        {
            ItemModels = dbContext.Items.OrderByDescending(i => i.Id).Where(x => x.IdTask == selectedRowTask.Id).ToList();
        }

        public IList<ItemModel> ItemModels
        {
            get { return itemModel; }
            set
            {
                if (value != itemModel)
                {
                    itemModel = value;
                    NotifyPropertyChanged("ItemModels");
                }
            }
        }


        //para mag update yung changes
        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        //end para mag update ang changes

        public RelayCommand DeleteCommand
        {
            get
            {
                return new RelayCommand(p => Delete(p));
            }
        }

        public RelayCommand UpdateCommands
        {
            get
            {
                return new RelayCommand(p => Updates(p));
            }
        }

        public RelayCommand AddCommands
        {
            get
            {
                return new RelayCommand(p => Add(p));
            }
        }
        public RelayCommand ViewCommands
        {
            get
            {
                return new RelayCommand(p => View(p));
            }
        }

        public void Delete(object o)
        {
            ItemModelSelectedRow = dbContext.Items.FirstOrDefault(d => d.Id.Equals(o));
            dbContext.Items.Remove(ItemModelSelectedRow);
            dbContext.SaveChanges();
            MessageBox.Show(ItemModelSelectedRow.ItemDetails + " has been Deleted");
            GetData();
        }

        public void Updates(object o)
        {
            ItemModelSelectedRow = dbContext.Items.FirstOrDefault(d => d.Id.Equals(o));
            AddUpdateItemView uaivm = new AddUpdateItemView(dbContext, selectedRowTask, ItemModelSelectedRow, "Update");
            uaivm.ShowDialog();
            GetData();

        }

        public void Add(object o)
        {
            AddUpdateItemView uaivm = new AddUpdateItemView(dbContext, selectedRowTask, ItemModelSelectedRow, "Add");
            uaivm.ShowDialog();
            GetData();
        }

        public void View(object o)
        {
            ItemModelSelectedRow = dbContext.Items.FirstOrDefault(d => d.Id.Equals(o));
            //ViewItems vi = new ViewItems(dbContext, taskListSelectedRow);
            //vi.ShowDialog();
            GetData();
        }

        public class RelayCommand : ICommand
        {
            private Action<object> action;
            private Func<bool> canFuncPerform;
            public event EventHandler CanExecuteChanged;
            public RelayCommand(Action<object> executeMethod)
            {
                action = executeMethod;
            }
            public RelayCommand(Action<object> executeMethod, Func<bool> canExecuteMethod)
            {
                action = executeMethod;
                canFuncPerform = canExecuteMethod;
            }
            public void RaiseCanExecuteChanged()
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
            public bool CanExecute(object parameter)
            {
                if (canFuncPerform != null)
                {
                    return canFuncPerform();
                }

                if (action != null)
                {
                    return true;
                }

                return false;
            }

            public void Execute(object parameter)
            {
                if (action != null)
                {
                    action(parameter);
                }
            }
        }

        /*

               public class RelayCommand : ICommand
        {
            readonly Action<object> _execute;
            readonly Predicate<object> _canExecute;

            #region Constructors

            /// <summary>
            /// Creates a new command.
            /// </summary>
            /// <param name="execute">The execution logic.</param>
            /// <param name="canExecute">The execution status logic.</param>
            public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
            {
                _execute = execute ?? throw new ArgumentNullException(nameof(execute));
                _canExecute = canExecute;
            }
            #endregion // Constructors

            #region ICommand Members
            [DebuggerStepThrough]
            public bool CanExecute(object parameter)
            {
                //For Vs 2015+ 
                return _canExecute?.Invoke(parameter) ?? true;
                //For Vs 2013-
                return _canExecute != null ? _canExecute.Invoke(parameter) : true;
            }

            /// <summary>
            /// Can execute changed event handler.
            /// </summary>
            public event EventHandler CanExecuteChanged
            {
                add => CommandManager.RequerySuggested += value;
                remove => CommandManager.RequerySuggested -= value;
            }

            public void Execute(object parameter)
            {
                _execute(parameter);
            }
            #endregion // ICommand Members
        }
        */
    }
}


/*
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using WpfApp2.Model;
using System.Windows.Input;
using WpfApp2.Commnds;

namespace WpfApp2.ViewModel
{
    public class ItemsViewModel : BaseViewModel
    {

        private IList<ItemModel> _ItemModel;
        TaskListModel selectedRowTask = new TaskListModel();
        TaskListDbContext dbContext;

        public ICommand UpdateViewCommand { get; set; }

        private BaseViewModel selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                selectedViewModel = value;
           //     OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ItemsViewModel(TaskListDbContext _dbContext, TaskListModel _selectedRowTask)
        {
            //UpdateViewCommand = new UpdateViewCommand(this);

            this.dbContext = _dbContext;
            selectedRowTask = _selectedRowTask;

            ItemModels = dbContext.Items.OrderByDescending(i => i.Id).Where(x => x.IdTask == selectedRowTask.Id).ToList();
        }

        public IList<ItemModel> ItemModels
        {
            get { return _ItemModel; }
            set { _ItemModel = value; }
        }
    }
 }
*/
