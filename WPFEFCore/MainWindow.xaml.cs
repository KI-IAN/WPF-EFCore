﻿using System;
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
    public partial class MainWindow : Window
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

            lvUser.ItemsSource = _studentRepository.GetStudents();

        }

        private void lvUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}