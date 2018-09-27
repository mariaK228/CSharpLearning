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

        public int NameLength;

        public string GetName()
        {
            return Encoding.Unicode.GetString(UserName, 0, NameLength * 2);
        }

        public string GetPass()
        {
            return Encoding.Unicode.GetString(UserPass, 0, PassLen * 2);
        }

        public void SetNewPassword(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            //UserPass = bytes;
            bytes.CopyTo(UserPass, 0);
            PassLen = password.Length;
        }
    }

}
