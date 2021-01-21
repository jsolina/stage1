using System.Linq;
using System.Windows;
using WpfApp2.Model;
using WpfApp2.ViewModel;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input; 

namespace WpfApp2.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        TaskListDbContext dbContext;

        public Window1(TaskListDbContext _dbContext)
        {
            this.dbContext = _dbContext;
            InitializeComponent();
            var viewModel = new TaskListViewModel(dbContext);
            DataContext = viewModel;
        }
    }

}
