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
    /// Interaction logic for CreateUpdateTask.xaml
    /// </summary>
    public partial class CreateUpdateTask : Window
    {
        TaskList order = new TaskList();
        TaskListDbContext dbContext;

        Model.TaskList selectedRow = new Model.TaskList();

        string updateOrAdd;

        public CreateUpdateTask(TaskListDbContext _dbContext, TaskList _selectedRow, string _updateOrAdd)
        {
            this.dbContext = _dbContext;

            InitializeComponent();
            updateOrAdd = _updateOrAdd;
            UpdateOrAddType.DataContext = new SelectedRow() { UpdateOrAdd = updateOrAdd + " Task" };

            if (updateOrAdd == "Update")
            {
                selectedRow = _selectedRow;
                SelectedRowDetails.DataContext = selectedRow;

                name.Text = selectedRow.Name;
                desc.Text = selectedRow.Description;
            }
  
        }


        private void Submit(object s, RoutedEventArgs e)
        {
            selectedRow.Name = name.Text;
            selectedRow.Description = desc.Text;
            if (updateOrAdd == "Add")
            {
                dbContext.Tasks.Add(selectedRow);
                dbContext.SaveChanges();
                MessageBox.Show("Task has been Added", "Added");
            }
            if (updateOrAdd == "Update")
            {
                dbContext.Update(selectedRow);
                dbContext.SaveChanges();
                MessageBox.Show("Task has been Updated", "Updated");
            }
            this.Close();
        }
    }
}
