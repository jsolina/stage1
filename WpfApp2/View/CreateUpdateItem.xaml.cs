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

namespace WpfApp2.View
{
    /// <summary>
    /// Interaction logic for CreateUpdateItem.xaml
    /// </summary>
    public partial class CreateUpdateItem : Window
    {

        TaskListDbContext dbContext;

        Model.Item selectedRowItem = new Model.Item();
        Model.TaskList selectedRowTask = new Model.TaskList();

        string updateOrAdd;

        public CreateUpdateItem(TaskListDbContext _dbContext, TaskList _selectedRowTask, Item _selectedRowItem, string _updateOrAdd)
        {
            this.dbContext = _dbContext;

            InitializeComponent();
            updateOrAdd = _updateOrAdd;
            UpdateOrAddType.DataContext = new SelectedRow() { UpdateOrAdd = updateOrAdd + " Task" };

            selectedRowTask = _selectedRowTask;

            if (updateOrAdd == "Update")
            {
                selectedRowItem = _selectedRowItem;

                name.Text = selectedRowItem.ItemName;
                desc.Text = selectedRowItem.ItemDetails;
                status.Text = selectedRowItem.Status;
            }

        }
        private void Submit(object s, RoutedEventArgs e)
        {
            selectedRowItem.ItemName = name.Text;
            selectedRowItem.ItemDetails = desc.Text;
            selectedRowItem.Status = status.Text;
            if (updateOrAdd == "Add")
            {
                selectedRowItem.IdTask = selectedRowTask.Id;
                dbContext.Items.Add(selectedRowItem);
                dbContext.SaveChanges();
                MessageBox.Show("Item has been Added", "Added");
            }
            if (updateOrAdd == "Update")
            {
                dbContext.Update(selectedRowItem);
                dbContext.SaveChanges();
                MessageBox.Show("Item has been Updated", "Updated");
            }
            this.Close();
        }

    }
}
