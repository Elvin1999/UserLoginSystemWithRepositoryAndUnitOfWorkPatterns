using LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.ViewModels
{
   public class MainViewModel:BaseViewModel
    {
        public LoginCommand LoginCommand => new LoginCommand(this);
    }
}
