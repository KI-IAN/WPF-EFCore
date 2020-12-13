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
    /// Interaction logic for StudentDetailPage.xaml
    /// </summary>
    public partial class StudentDetailPage : Page
    {
        private RepositoryHelper.StudentRepositoryHelper _studentRepo;

        private DAL.Models.Student _selectedStudent;

        public StudentDetailPage(DAL.Models.Student student)
        {
            _selectedStudent = student;

            InitializeComponent();
        }

        public override void BeginInit()
        {
            base.BeginInit();

            _studentRepo = new RepositoryHelper.StudentRepositoryHelper();

        }


        public override void EndInit()
        {
            base.EndInit();

            txtName.Text = _selectedStudent.StudentName;
            txtStandardId.Text = _selectedStudent.StandardId;
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            _selectedStudent.StandardId = txtStandardId.Text;
            _selectedStudent.StudentName = txtName.Text;

            var isUpdateSuccessful = _studentRepo.Update(_selectedStudent);

            var message = isUpdateSuccessful ? "Student data is updated successfully" : "Ops! something went wrong. New student could not be updated. Please try again later.";

            MessageBox.Show(message);
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            var isDeletionSuccessful = _studentRepo.Delete(_selectedStudent.StudentId);

            var message = isDeletionSuccessful ? "Student data is deleted successfully" : "Ops! something went wrong. Student could not be deleted. Please try again later.";

            MessageBox.Show(message);

            this.NavigationService.Navigate(new Uri("MainWindow.xaml", UriKind.Relative));
        }

        private void Button_Click_BackToHomePage(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("MainWindow.xaml", UriKind.Relative));
        }
    }
}
