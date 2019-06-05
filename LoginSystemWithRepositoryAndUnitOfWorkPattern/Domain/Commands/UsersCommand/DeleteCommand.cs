using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Commands.UsersCommand
{
    public class DeleteCommand : ICommand
    {
        public DeleteCommand(UserViewModel userViewModel)
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
            var user = UserViewModel.SelectedUser;
            if (user != null)
            {

                App.DB.UserRepository.DeleteData(user);
                UserViewModel.AllUsers = App.DB.UserRepository.GetAllData();
            }
        }
    }
}
