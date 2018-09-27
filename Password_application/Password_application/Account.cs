using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Password_application
{
    public class Account
    {
        public const int MAXNAME = 20; // макс. длина имени учетной записи 

        public const int MAXPASS = 20; // макс. длина пароля 

        public const string SECFILE = "security.db"; // имя файла с уч записями пользователей 


        public AccountType UserAcc; // объект для хранения одной уч записи 

        public FileStream AccFile; // поток для чтения и записи в файл с уч записями 

        public int RecCount; // Номер текущей учетной записи 

        public byte[] buf; // буфер для учетной записи 

        public int pos; // текущая длина буфера для уч записи 

        public int AccLen; // длина данных учетной записи 


        public Account()
        {
            // создание объекта для учетной записи

            UserAcc = new AccountType();
            UserAcc.UserName = new byte[MAXNAME * 2];
            UserAcc.UserPass = new byte[MAXPASS * 2];
            AccLen = MAXNAME * 2 + MAXPASS * 2 + sizeof(int) + sizeof(int) + sizeof(bool) * 2;
            buf = new byte[AccLen];
        }

        public void WriteAccount() // преобразование уч записи в массив байт 
        {

            pos = 0; // сброс текущей позиции в буфере для учетной записи 

            UserAcc.UserName.CopyTo(buf, pos);  // запись в буфер имени пользователя 
            pos += UserAcc.UserName.Length;

            UserAcc.UserPass.CopyTo(buf, pos);
            pos += UserAcc.UserPass.Length;

            BitConverter.GetBytes(UserAcc.PassLen).CopyTo(buf, pos);
            pos += sizeof(int);

            BitConverter.GetBytes(UserAcc.NameLength).CopyTo(buf, pos);
            pos += sizeof(int);

            // преобразование и запись признака блокировки учетной записи 
            BitConverter.GetBytes(UserAcc.Block).CopyTo(buf, pos);
            pos += sizeof(bool);

            // преобразование и запись признака ограничений на пароль 
            BitConverter.GetBytes(UserAcc.Restrict).CopyTo(buf, pos);
            pos += sizeof(bool);

            // запись буфера с учетной записью в файл 
            AccFile.Write(buf, 0, pos); 
        }

        public void ReadAccount()
        {
            // чтение имени пользователя 
            AccFile.Read(UserAcc.UserName, 0, UserAcc.UserName.Length);

            // чтение пароля 
            AccFile.Read(UserAcc.UserPass, 0, UserAcc.UserPass.Length);

            // выделение памяти под временный буфер  
            byte[] tmp = new byte[sizeof(int)];

            // чтение и преобразование длины пароля 
            AccFile.Read(tmp, 0, sizeof(int));
            UserAcc.PassLen = BitConverter.ToInt32(tmp, 0);

            AccFile.Read(tmp, 0, sizeof(int));
            UserAcc.NameLength = BitConverter.ToInt32(tmp, 0);
            

            // чтение и преобразование признака блокировки учетной записи 
            AccFile.Read(tmp, 0, sizeof(bool));
            UserAcc.Block = BitConverter.ToBoolean(tmp, 0);

            // чтение и преобразование признака ограничений на пароль
            AccFile.Read(tmp, 0, sizeof(bool));
            UserAcc.Restrict = BitConverter.ToBoolean(tmp, 0);
        }

    }
}
