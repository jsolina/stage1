using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp2.Model;
using WpfApp2.ViewModel;

namespace WpfApp2.View
{
    /// <summary>
    /// Interaction logic for CreateUpdateTask.xaml
    /// </summary>
    public partial class AddUpdateTaskView : Window
    {
        TaskListDbContext dbContext;
        TaskListModel selectedRow = new TaskListModel();

        public AddUpdateTaskView(TaskListDbContext _dbContext, TaskListModel _selectedRow, string _updateOrAdd)
        {
            InitializeComponent();

            this.dbContext = _dbContext;
            if (_updateOrAdd == "Update")
            {
                selectedRow = _selectedRow;

            }

            this.DataContext = new AddUpdateTaskViewModel(dbContext, selectedRow, _updateOrAdd);


            var viewModel = new AddUpdateTaskViewModel(dbContext, selectedRow, _updateOrAdd);
            DataContext = viewModel;
        }

    }
}
