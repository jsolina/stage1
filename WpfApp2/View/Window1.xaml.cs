using System.Linq;
using System.Windows;
using WpfApp2.Model;
using WpfApp2.ViewModel;

namespace WpfApp2.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        TaskListDbContext dbContext;
        TaskList selectedRow = new TaskList();

        public Window1(TaskListDbContext _dbContext)
        {
            this.dbContext = _dbContext;
            InitializeComponent();
            GetTasks();
        }

        private void GetTasks()
        {
            var viewModel = new TaskListViewModel(dbContext);
            DataContext = viewModel;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 vi = new Window2();
            vi.ShowDialog();
        }
    }

}
