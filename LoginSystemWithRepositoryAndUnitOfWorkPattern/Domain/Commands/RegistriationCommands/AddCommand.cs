using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Abstractions;
using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Entities;
using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Commands.RegistriationCommands
{
   public class AddCommand:ICommand
    {
        public IUnitOfWork db { get; set; }
        public AddCommand(RegisterViewModel registerViewModel)
        {
            RegisterViewModel = registerViewModel;
            db = App.DB;
        }

        public event EventHandler CanExecuteChanged;
        public RegisterViewModel RegisterViewModel { get; set; }
        public object Message { get; private set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var users= App.DB.UserRepository.GetAllData();
            var password = (parameter as PasswordBox).Password;
            var user = RegisterViewModel.CurrentUser;
            var item = users.FirstOrDefault(x => x.UserName == user.UserName);
            if (item == null)
            {
                Helper helper = new Helper();
                user.Password = helper.GetHashOfString(password);
                try
                {
                    App.DB.UserRepository.AddData(user);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Username is already exist . . . ");
            }

        }
    }
}
