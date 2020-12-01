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

namespace WpfApp2.View
{
    /// <summary>
    /// Interaction logic for ViewItems.xaml
    /// </summary>
    public partial class ViewItems : Window
    {
        TaskListDbContext dbContext;
        Model.TaskList selectedRowTask = new Model.TaskList();
        Model.Item selectedRowItem = new Model.Item();

        public ViewItems(TaskListDbContext dbContext, TaskList _selectedRowTask)
        {
            InitializeComponent();
            this.dbContext = dbContext;

            selectedRowTask = _selectedRowTask;

            headerItemName.Text = "Item List of Task: '" + selectedRowTask.Name + "'";

            GetItems();
        }

        private void GetItems()
        {
            ItemDG.ItemsSource = dbContext.Items.OrderByDescending(i => i.Id).Where(x => x.IdTask == selectedRowTask.Id).ToList();
        }

        private void Add(object s, RoutedEventArgs e)
        {
            CreateUpdateItem cuo = new CreateUpdateItem(dbContext, selectedRowTask, selectedRowItem, "Add");
            cuo.ShowDialog();
            GetItems();
        }

        private void Update(object s, RoutedEventArgs e)
        {
            selectedRowItem = (s as FrameworkElement).DataContext as Model.Item;
            CreateUpdateItem vi = new CreateUpdateItem(dbContext, selectedRowTask, selectedRowItem, "Update");
            vi.ShowDialog();
            GetItems();
        }

        private void Delete(object s, RoutedEventArgs e)
        {
            var rowToBeDeleted = (s as FrameworkElement).DataContext as Model.Item;
            dbContext.Items.Remove(rowToBeDeleted);
            dbContext.SaveChanges();
            GetItems();
            MessageBox.Show(rowToBeDeleted.ItemName + " has been Deleted", "Item Deleted!");
        }
    }
}
