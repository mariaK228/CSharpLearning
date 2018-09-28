using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordApplication.AccountManagement
{
    class AccountRegistry
    {
        public const int MaxNameLenght = 20;
        public const int MaxPasswordLength = 20;

        private List<Account> _accounts = new List<Account>();

        public Account[] GetAccounts()
        {
            return _accounts.ToArray();
        }

        public void ReadAccounts(Stream stream)
        {
            if(stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);

            byte[] nameBuffer = new byte[MaxNameLenght * sizeof(char)];
            byte[] passBuffer = new byte[MaxPasswordLength * sizeof(char)];

            byte[] infoBuffer = new byte[sizeof(int) * 2 + sizeof(bool) * 2];

            while (stream.Position < stream.Length)
            {
                stream.Read(nameBuffer, 0, MaxNameLenght * sizeof(char)); // Username
                stream.Read(passBuffer, 0, MaxNameLenght * sizeof(char)); // Password

                stream.Read(infoBuffer, 0, infoBuffer.Length); // Inforamtion

                int nameLen = BitConverter.ToInt32(infoBuffer, 0);
                int passLen = BitConverter.ToInt32(infoBuffer, sizeof(int));

                bool banned = BitConverter.ToBoolean(infoBuffer, sizeof(int) * 2);
                bool hasResrt = BitConverter.ToBoolean(infoBuffer, sizeof(int) * 2 + sizeof(bool));

                string username = DecodeString(nameBuffer, nameLen);
                string password = DecodeString(passBuffer, passLen);

                Account acc = new Account(username, password, hasResrt, banned);

                _accounts.Add(acc);
            }
        }

        public void CreateDefaulRegistry(Stream stream)
        {
            _accounts.Clear();
            Account admin = new Account("ADMIN", "", true, false);
            _accounts.Add(admin);
            WriteAccounts(stream);
        }

        private string DecodeString(byte[] bytes, int length)
        {
            return Encoding.Unicode.GetString(bytes, 0, length * sizeof(char));
        }

        private byte[] EncodeString(string str, int finalSize)
        {
            byte[] bytes = new byte[finalSize];
            byte[] strBytes = Encoding.Unicode.GetBytes(str);

            strBytes.CopyTo(bytes, 0);

            return bytes;
        }

        public void WriteAccounts(Stream stream)
        {
            if(stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);

            for (int i = 0; i < _accounts.Count; i++)
            {
                string username = _accounts[i].GetUsername();
                string password = _accounts[i].GetPassword();

                byte[] usernameBytes = EncodeString(username, MaxNameLenght * sizeof(char));
                byte[] passBytes = EncodeString(password, MaxPasswordLength * sizeof(char));
                byte[] nameLenBytes = BitConverter.GetBytes(username.Length);
                byte[] passLenBytes = BitConverter.GetBytes(password.Length);
                byte[] bannedBytes = BitConverter.GetBytes(_accounts[i].IsBanned());
                byte[] passRBytes = BitConverter.GetBytes(_accounts[i].HasPasswordRestrictions());

                stream.Write(usernameBytes, 0, usernameBytes.Length);
                stream.Write(passBytes, 0, passBytes.Length);
                stream.Write(nameLenBytes, 0, nameLenBytes.Length);
                stream.Write(passLenBytes, 0, passLenBytes.Length);
                stream.Write(bannedBytes, 0, bannedBytes.Length);
                stream.Write(passRBytes, 0, passRBytes.Length);
            }

            stream.Flush();
        }

        public Account AddAccount(string username)
        {
            Account acc = new Account(username, "", false, false);

            if (IsUnique(username))
            {
                _accounts.Add(acc);
                return acc;
            }

            throw new ArgumentException(nameof(username), "Аккаунт с таким именем уже существует");
        }

        public Account ChangePassword(string username, string nPassword)
        {
            int index = IndexOf(username);

            if (index != -1)
            {
                Account acc = _accounts[index];
                Account nAcc = new Account(acc.GetUsername(), nPassword, acc.HasPasswordRestrictions(), acc.IsBanned());
                _accounts[index] = nAcc;
                return nAcc;
            }

            throw new ArgumentException(nameof(username), "Пользователь не зарегистрирован");
        }

        public Account SetPasswordRestrictions(string username, bool value)
        {
            int index = IndexOf(username);

            if (index != -1)
            {
                Account acc = _accounts[index];
                Account nAcc = new Account(acc.GetUsername(), acc.GetPassword(), value, acc.IsBanned());
                _accounts[index] = nAcc;
                return nAcc;
            }

            throw new ArgumentException(nameof(username), "Пользователь не зарегистрирован");
        }

        public Account SetBanState(string username, bool value)
        {
            int index = IndexOf(username);

            if (index != -1)
            {
                Account acc = _accounts[index];
                Account nAcc = new Account(acc.GetUsername(), acc.GetPassword(), acc.HasPasswordRestrictions(), value);
                _accounts[index] = nAcc;
                return nAcc;
            }

            throw new ArgumentException(nameof(username), "Пользователь не зарегистрирован");
        }

        private int IndexOf(string username)
        {
            for(int i = 0; i < _accounts.Count; i++)
                if (_accounts[i].GetUsername() == username)
                    return i;

            return -1;
        }

        private bool IsUnique(string username)
        {
            foreach (var acc in _accounts)
            {
                if (acc.GetUsername() == username)
                    return false;
            }

            return true;
        }
    }
}
