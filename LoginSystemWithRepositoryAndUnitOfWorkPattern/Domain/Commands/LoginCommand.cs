using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Entities;
using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.ViewModels;
using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Commands
{
    public class LoginCommand : ICommand
    {
        public LoginCommand(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public MainViewModel MainViewModel { get; set; }
        public void Execute(object parameter)
        {

            UserViewModel userViewModel = new UserViewModel();
            userViewModel.AllUsers = App.DB.UserRepository.GetAllData();
            var username = MainViewModel.UserName;
            var password = (parameter as PasswordBox).Password;
            Helper helper = new Helper();
            var password1 = helper.GetHashOfString(password);
            var user = userViewModel.AllUsers.FirstOrDefault(x => x.UserName == username);

            if (user != null)
            {
                var isEqual = helper.IsEqual(password1, user.Password);
                if (isEqual)
                {
                    if (user.HasAdminRule)
                    {
                        UserWindow userWindow = new UserWindow(userViewModel);
                        userWindow.ShowDialog();
                    }
                    else
                    {
                        PersonalUserViewModel viewModel = new PersonalUserViewModel();
                        viewModel.CurrentUser = user;
                        PersonalUserWindow personalUserWindow = new PersonalUserWindow(viewModel);
                        personalUserWindow.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Password is not okay");
                }

            }
            else
            {
                MessageBox.Show("User did not find");
            }
        }
    }
}
