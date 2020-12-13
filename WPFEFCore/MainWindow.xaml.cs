using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFEFCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        private RepositoryHelper.StudentRepositoryHelper _studentRepository;

        public MainWindow()
        {
            InitializeComponent();
        }


        public override void BeginInit()
        {
            base.BeginInit();
            _studentRepository = new RepositoryHelper.StudentRepositoryHelper();
        }


        public override void EndInit()
        {
            base.EndInit();
            lvUser.ItemsSource = _studentRepository.GetAll();
        }

        private void lvUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedData = e.AddedItems[0] as DAL.Models.Student;

            StudentDetailPage detailPage = new StudentDetailPage(selectedData);
            this.NavigationService.Navigate(detailPage);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("NewStudentPage.xaml", UriKind.Relative));
        }
    }
}
