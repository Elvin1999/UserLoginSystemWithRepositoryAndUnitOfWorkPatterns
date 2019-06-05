using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Commands.PersonalUserCommands
{
    public class UpdateCommand : ICommand
    {
        public UpdateCommand(PersonalUserViewModel personalUserViewModel)
        {
            PersonalUserViewModel = personalUserViewModel;
        }

        public event EventHandler CanExecuteChanged;
        public PersonalUserViewModel PersonalUserViewModel { get; set; }
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
            var user = PersonalUserViewModel.CurrentUser;
            if (password != "")
            {

                user.Password = password;
            }
            App.DB.UserRepository.UpdateData(user);
        }
    }
}
