using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Data;
using WpfApp2.Model;
using WpfApp2.Commnds;

namespace WpfApp2.ViewModel
{
    public class TaskListViewModel : BaseViewModel
    {
    
        private IList<TaskList> _TaskList;
        TaskListDbContext dbContext;

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

        public TaskListViewModel(TaskListDbContext _dbContext)  
        {
            UpdateViewCommand = new UpdateViewCommand(this);

            this.dbContext = _dbContext;
            TaskLists = dbContext.Tasks.OrderByDescending(i => i.Id).ToList();


        }

        public IList<TaskList> TaskLists
        {
            get { return _TaskList; }
            set { _TaskList = value; }
        }

    }      
}
