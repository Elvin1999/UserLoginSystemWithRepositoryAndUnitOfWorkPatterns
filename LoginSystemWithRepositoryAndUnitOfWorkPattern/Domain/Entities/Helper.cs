using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystemWithRepositoryAndUnitOfWorkPattern.Domain.Entities
{
   public class Helper
    {
        public string GetHashOfString(string password)
        {
            var data = Encoding.ASCII.GetBytes(password);
            var sha1 = new SHA1CryptoServiceProvider();
            var sha1data = sha1.ComputeHash(data);
            var asci = new ASCIIEncoding();
            var result = asci.GetString(sha1data);
            return result;
        }
        public bool IsEqual(string hash1,string hash2)
        {
            if (hash1 == hash2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
