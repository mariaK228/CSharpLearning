using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_application
{
    public struct AccountType
    {
        public byte[] UserName; // имя 

        public byte[] UserPass; // пароль 

        public int PassLen; // длина пароля 

        public bool Block; // признак блокировки уч записи админом 

        public bool Restrict; // признак вкл админом ограничений на выбираемые пользователем пароли 
    }

}
