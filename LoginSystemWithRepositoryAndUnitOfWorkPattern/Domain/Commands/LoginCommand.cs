using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.ViewModels;
using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            UserWindow userWindow = new UserWindow(userViewModel);
            userWindow.ShowDialog();
        }
    }
}
