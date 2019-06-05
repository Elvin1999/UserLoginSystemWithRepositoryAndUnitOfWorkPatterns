using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.ViewModels;
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
    /// Interaction logic for PersonalUserWindow.xaml
    /// </summary>
    public partial class PersonalUserWindow : Window
    {
        public PersonalUserViewModel PersonalUserViewModel { get; set; }
        public PersonalUserWindow(PersonalUserViewModel personalUserViewModel)
        {
            InitializeComponent();
            PersonalUserViewModel = personalUserViewModel;
            DataContext = PersonalUserViewModel;
        }
    }
}
