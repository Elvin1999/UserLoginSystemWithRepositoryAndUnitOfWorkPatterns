using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Commands.UsersCommand;
using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.ViewModels
{
   public class UserViewModel:BaseViewModel
    {
        public AddCommand AddCommand => new AddCommand(this);
        //public UpdateCommand UpdateCommand => new UpdateCommand(this);
        //public DeleteCommand DeleteCommand => new DeleteCommand(this);
        private ObservableCollection<User> allUsers;
        public ObservableCollection<User> AllUsers
        {
            get
            {
                return allUsers;
            }
            set
            {
                allUsers = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(AllUsers)));
            }
        }

        public UserViewModel()
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

        private User selectedUser;
        public User SelectedUser
        {
            get
            {

                return selectedUser;
            }
            set
            {
                selectedUser = value;


                if (value != null)
                {

                    CurrentUser = SelectedUser.Clone();
                }
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedUser)));
            }
        }
    }
}
