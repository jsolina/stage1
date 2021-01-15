using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfApp2.ViewModel;

namespace WpfApp2.Commnds
{
    public class UpdateViewCommand : ICommand
    {
        private TaskListViewModel viewModel;

        public UpdateViewCommand(TaskListViewModel _viewModel)
        {
            this.viewModel = _viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine("test");
            if(parameter.ToString() == "TaskList")
            {
                 
            }
            else
            {
                viewModel.SelectedViewModel = new ItemsViewModel();
            }
        }
    }
}
