using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for ViewItems.xaml
    /// </summary>
    public partial class ViewItems : Window
    {
        TaskListDbContext dbContext;
        TaskListModel selectedRowTask = new TaskListModel();
        ItemModel selectedRowItem = new ItemModel();

        public ViewItems(TaskListDbContext _dbContext, TaskListModel _selectedRowTask)
        {
            InitializeComponent();
            this.dbContext = _dbContext;
            selectedRowTask = _selectedRowTask;
            headerItemName.Text = "Item List of Task: '" + selectedRowTask.Name + "'";

            var viewModel = new ItemsViewModel(dbContext, selectedRowTask);
            this.DataContext = viewModel;
        }
    }
}
