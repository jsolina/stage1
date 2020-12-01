using System.Linq;
using System.Windows;
using WpfApp2.Model;

namespace WpfApp2.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        TaskListDbContext dbContext;
        Model.TaskList selectedRow = new Model.TaskList();

        public Window1(TaskListDbContext dbContext)
        {
            InitializeComponent();
            this.dbContext = dbContext;
            GetTasks();
        }

        private void GetTasks()
        {
            OrderDG.ItemsSource = dbContext.Tasks.OrderByDescending(i => i.Id).ToList();
        }

        private void View(object s, RoutedEventArgs e)
        {
            selectedRow = (s as FrameworkElement).DataContext as Model.TaskList;
            ViewItems vi = new ViewItems(dbContext, selectedRow);
            vi.ShowDialog();
            GetTasks();
        }

        private void Add(object s, RoutedEventArgs e)
        {
            CreateUpdateTask cuo = new CreateUpdateTask(dbContext, selectedRow, "Add");
            cuo.ShowDialog();
            GetTasks();
        }

        private void Update(object s, RoutedEventArgs e)
        {
            selectedRow = (s as FrameworkElement).DataContext as Model.TaskList;
            CreateUpdateTask cuo = new CreateUpdateTask(dbContext, selectedRow, "Update");
            cuo.ShowDialog();
            GetTasks();
        }

        private void Delete(object s, RoutedEventArgs e)
        {
            var rowToBeDeleted = (s as FrameworkElement).DataContext as Model.TaskList;
            dbContext.Tasks.Remove(rowToBeDeleted);
            dbContext.SaveChanges();
            GetTasks();
            MessageBox.Show(rowToBeDeleted.Name + " has been Deleted", "Task Deleted!");
        }
    }

}
