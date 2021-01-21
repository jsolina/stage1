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
    /// Interaction logic for CreateUpdateItem.xaml
    /// </summary>
    public partial class AddUpdateItemView : Window
    {

        TaskListDbContext dbContext;
        ItemModel selectedRowItem = new ItemModel();
        TaskListModel selectedRowTask = new TaskListModel();

        public AddUpdateItemView(TaskListDbContext _dbContext, TaskListModel _selectedRowTask, ItemModel _selectedRowItem, string _updateOrAdd)
        {
            InitializeComponent();
            this.dbContext = _dbContext;
            selectedRowTask = _selectedRowTask;

            if (_updateOrAdd == "Update")
            {
                selectedRowItem = _selectedRowItem;
            }

            this.DataContext = new AddUpdateItemViewModel(dbContext, selectedRowTask, selectedRowItem, _updateOrAdd);

             var viewModel = new AddUpdateItemViewModel(dbContext, selectedRowTask, selectedRowItem, _updateOrAdd);
             DataContext = viewModel;
        }

    }
}
