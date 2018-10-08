using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordApplication.AccountManagement
{
    class InvalidDecryptionException : Exception
    {
        public InvalidDecryptionException(string message) : base(message)
        {
            
        }
    }
}
