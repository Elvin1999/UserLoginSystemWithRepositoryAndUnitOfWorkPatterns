using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Abstractions
{
   public interface IUnitOfWork
    {
        void SaveChanges();
        IUserRepository UserRepository { get; }
    }
}
