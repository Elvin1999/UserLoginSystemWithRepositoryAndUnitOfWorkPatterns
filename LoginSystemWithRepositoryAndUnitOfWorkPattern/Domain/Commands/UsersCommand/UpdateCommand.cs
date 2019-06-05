using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Commands.UsersCommand
{
    public class UpdateCommand : ICommand
    {
        public UpdateCommand(UserViewModel userViewModel)
        {
            UserViewModel = userViewModel;
        }

        public event EventHandler CanExecuteChanged;
        public UserViewModel UserViewModel { get; set; }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string password = "";
            if ((parameter as PasswordBox).Password != null)
            {
                password = (parameter as PasswordBox).Password;
            }
            var user = UserViewModel.CurrentUser;
            if(password!="")
            user.Password = password;
            MessageBox.Show(user.Password);
            App.DB.UserRepository.UpdateData(user);
            UserViewModel.AllUsers = App.DB.UserRepository.GetAllData();
        }
    }
}
