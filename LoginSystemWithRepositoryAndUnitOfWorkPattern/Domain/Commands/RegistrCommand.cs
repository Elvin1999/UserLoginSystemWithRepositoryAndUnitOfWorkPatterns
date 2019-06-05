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
    public class RegistrCommand : ICommand
    {
        public RegistrCommand(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }

        public MainViewModel MainViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();
            RegistriationWindow registriationWindow = new RegistriationWindow(registerViewModel);
            registriationWindow.ShowDialog();
        }
    }
}
