using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Commands;
using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Commands.RegistriationCommands;
using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public AddCommand AddCommand => new AddCommand(this);
        public RegisterViewModel()
        {
            CurrentUser = new User();
        }
        private User currentUser;
        public User CurrentUser
        {
            get
            {
                return currentUser;
            }
            set
            {
                currentUser = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(CurrentUser)));
            }
        }
    }
}
