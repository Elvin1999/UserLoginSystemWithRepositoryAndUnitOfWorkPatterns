﻿using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.ViewModels;
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
using System.Windows.Shapes;

namespace LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Views
{
    /// <summary>
    /// Interaction logic for RegistriationWindow.xaml
    /// </summary>
    public partial class RegistriationWindow : Window
    {
        public RegisterViewModel RegisterViewModel { get; set; }
        public RegistriationWindow(RegisterViewModel registerViewModel)
        {
            InitializeComponent();
            RegisterViewModel = registerViewModel;
            DataContext = RegisterViewModel;
        }
    }
}
