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
        public string Username { get; set; }
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
            throw new NotImplementedException();
        }
    }

}
