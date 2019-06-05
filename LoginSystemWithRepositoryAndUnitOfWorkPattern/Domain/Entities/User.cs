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
        public bool HasAdminPermission { get; set; }
        public string AdminPermission
        {
            get
            {

                if (HasAdminPermission)
                {
                    return "Yes";
                }
                else
                {
                    return "No";
                }
            }
        }
    }

}
