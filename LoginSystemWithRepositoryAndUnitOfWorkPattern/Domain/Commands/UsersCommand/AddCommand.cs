using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Abstractions;
using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Commands.UsersCommand
{
    public class AddCommand : ICommand
    {
        public IUnitOfWork db { get; set; }
        public AddCommand(UserViewModel userViewModel)
        {
            UserViewModel = userViewModel;
            db = App.DB;
        }

        public event EventHandler CanExecuteChanged;
        public UserViewModel UserViewModel { get; set; }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            var user = UserViewModel.CurrentUser;
            App.DB.UserRepository.AddData(user);
            UserViewModel.AllUsers = App.DB.UserRepository.GetAllData();
        }
    }
}
