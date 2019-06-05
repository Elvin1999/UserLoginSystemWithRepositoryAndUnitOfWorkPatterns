using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.ViewModels
{
   public class MainViewModel:BaseViewModel
    {
        public LoginCommand LoginCommand => new LoginCommand(this);
        private string username;
        public string UserName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(UserName)));
            }
        }
    }
}
