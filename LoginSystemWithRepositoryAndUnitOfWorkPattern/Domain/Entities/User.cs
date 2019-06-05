using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool HasAdminRule { get; set; }
        public string AdminRule
        {
            get
            {

                if (HasAdminRule)
                {
                    return "Yes";
                }
                else
                {
                    return "No";
                }
            }
        }

        public User Clone()
        {
            User user = new User()
            {
                  HasAdminRule=this.HasAdminRule,
                   Id=this.Id,
                    No=this.No,
                     Password=this.Password,
                      UserName=this.UserName
            };
            return user;
        }
    }

}
