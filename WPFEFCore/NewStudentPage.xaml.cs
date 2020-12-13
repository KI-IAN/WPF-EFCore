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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFEFCore
{
    /// <summary>
    /// Interaction logic for NewStudentPage.xaml
    /// </summary>
    public partial class NewStudentPage : Page
    {

        private RepositoryHelper.StudentRepositoryHelper _studentRepo;

        public NewStudentPage()
        {
            InitializeComponent();

        }


        public override void BeginInit()
        {
            base.BeginInit();

            _studentRepo = new RepositoryHelper.StudentRepositoryHelper();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var student = new DAL.Models.Student()
            {
                StandardId = txtStandardId.Text,
                StudentName = txtName.Text,
            
            };

            var isInsertSuccessful = _studentRepo.Create(student);

            var message = isInsertSuccessful ? "New student is creted successfully" : "Ops! something went wrong. New student could not be created. Please try again later.";

            MessageBox.Show(message);

            this.NavigationService.Navigate(new Uri("MainWindow.xaml", UriKind.Relative));
        }
    }
}
