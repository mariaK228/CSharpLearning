using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PasswordApplication.AccountManagement
{
    public class AccountRegistry
    {
        public const int MaxNameLenght = 20;
        public const int MaxPasswordLength = 20;


        private List<Account> _accounts = new List<Account>();

        private string _cryptoPassword;

        public AccountRegistry(string password)
        {
            _cryptoPassword = password;
        }

        public Account[] GetAccounts()
        {
            return _accounts.ToArray();
        }

        public void CreateDefaulRegistry(Stream stream)
        {
            _accounts.Clear();
            Account admin = new Account("ADMIN", "", true, false);
            _accounts.Add(admin);
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


        public Account AddAccount(string username)
        {
            Account acc = new Account(username, "", false, false);

            if (IsUnique(username))
            {
                _accounts.Add(acc);
                return acc;
            }

            throw new ArgumentException((username), "Аккаунт с таким именем уже существует");
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

            throw new ArgumentException((username), "Пользователь не зарегистрирован");
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

            throw new ArgumentException((username), "Пользователь не зарегистрирован");
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

            throw new ArgumentException((username), "Пользователь не зарегистрирован");
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

        public Account FindAccount(string username)
        {
            int index = IndexOf(username);
            if (index != -1)
                return _accounts[index];

            throw new Exception("Пользователь не найден");
        }


        public void WriteAccounts(Stream stream)
        {
            if (stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);

            // Здесь будет зашифровывание
            byte[] salt = new byte[8]; // Необходимо сохранить в файл
            byte[] ivKey; // Необходимо сохранить в файл

            // Intitalizing cryptrographic system
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            // Generating and saving IV
            tdes.GenerateIV();
            ivKey = tdes.IV;

            // Generating and saving salt
            RNGCryptoServiceProvider randomGenerator = new RNGCryptoServiceProvider(); // Random rnd = new Random(); - НЕ БЕЗОПАСЕН С ТОЧКИ ЗРЕНИЯ КРИПТОГРАФИИ
            randomGenerator.GetBytes(salt);

            // Generating cryptographic key from password, salt and IV

            // AES имеет допустимые размеры ключей - 128 (16 байт), 192 (24 байта), 256 (32 байта) бит.

            // Задача: получить ключ требуемой длины из СТРОКИ любой длины.
            // ГРУБО ГОВОРЯ: Получаем HASH от строки с помощью MD5 (128 бит).
            // Для повышения безопасности генерации (усложнить перебор), к ключу до хэширования добавляется соль

            PasswordDeriveBytes passwordDeriver = new PasswordDeriveBytes(_cryptoPassword, salt);
            byte[] cryptoKey = passwordDeriver.CryptDeriveKey("TripleDES", "MD5", tdes.KeySize, ivKey); // Получили массив байт длины 16

            // Setting AES's key
            tdes.Key = cryptoKey;

            tdes.Mode = CipherMode.ECB; // Setting mode to Electronic Code Book

            // Creating CryptoStream
            ICryptoTransform cryptoTransform = tdes.CreateEncryptor();
            CryptoStream cryptoStream = new CryptoStream(stream, cryptoTransform, CryptoStreamMode.Write);
            
            WriteToStream(cryptoStream);

            cryptoStream.Flush();
            cryptoStream.FlushFinalBlock();

            //cryptoStream.Close();

            // Writing salt and IV to FileStream before encryption starts

            stream.Write(salt, 0, salt.Length);
            stream.Write(ivKey, 0, ivKey.Length);
        }

        public void ReadAccounts(Stream stream)
        {
            if (stream.CanSeek) // проверка возможности установки курсора записи 
                stream.Seek(0, SeekOrigin.Begin);

            // Здесь будет расшифрование

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            int ivLength = tdes.BlockSize / 8;

            byte[] salt = new byte[8];
            byte[] iv = new byte[ivLength];

            stream.Seek(-(salt.Length + ivLength), SeekOrigin.End);

            // Считать соль и вектор инициализации
            stream.Read(salt, 0, salt.Length);
            stream.Read(iv, 0, iv.Length);

            stream.Seek(0, SeekOrigin.Begin);

            // Генерируем ключ из пароля
            PasswordDeriveBytes passwordDeriver = new PasswordDeriveBytes(_cryptoPassword, salt);
            byte[] cryptoKey = passwordDeriver.CryptDeriveKey("TripleDES", "MD5", 0, iv); // Получили массив байт длины 16

            tdes.Key = cryptoKey;
            tdes.IV = iv;
            tdes.Mode = CipherMode.ECB;

            byte[] dataBuffer = new byte[stream.Length - salt.Length - ivLength];
            stream.Read(dataBuffer, 0, dataBuffer.Length);

            MemoryStream memStream = new MemoryStream(dataBuffer);

            ICryptoTransform cryptoTransform = tdes.CreateDecryptor();
            CryptoStream cryptoStream = new CryptoStream(memStream, cryptoTransform, CryptoStreamMode.Read);
            ReadFromStream(cryptoStream, stream.Length - salt.Length - iv.Length);

            if (_accounts[0].GetUsername() != "ADMIN")
            {
                throw new InvalidDecryptionException("Ключ расшифрование неверный!");
            }

            if(!cryptoStream.HasFlushedFinalBlock)
                cryptoStream.FlushFinalBlock();

            cryptoStream.Close();
        }

        private void WriteToStream(Stream stream)
        {
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

        private void ReadFromStream(Stream stream, long dataLen)
        {
            byte[] nameBuffer = new byte[MaxNameLenght * sizeof(char)];
            byte[] passBuffer = new byte[MaxPasswordLength * sizeof(char)];

            byte[] infoBuffer = new byte[sizeof(int) * 2 + sizeof(bool) * 2];

            int pos = 0;

            while (dataLen - pos > 90) // TODO FIX ME KOSTIL!
            {
                int lastRead = stream.ReadByte(); // Читаем 1 байт. Если он == -1, то поток завершен
                if(lastRead == -1)
                    break;

                stream.Read(nameBuffer, 1, MaxNameLenght * sizeof(char) - 1); // Username, читаем на один байт меньше
                nameBuffer[0] = (byte)lastRead;

                stream.Read(passBuffer, 0, MaxPasswordLength * sizeof(char)); // Password

                stream.Read(infoBuffer, 0, infoBuffer.Length); // Information / 

                int nameLen = BitConverter.ToInt32(infoBuffer, 0);
                int passLen = BitConverter.ToInt32(infoBuffer, sizeof(int));

                bool banned = BitConverter.ToBoolean(infoBuffer, sizeof(int) * 2);
                bool hasResrt = BitConverter.ToBoolean(infoBuffer, sizeof(int) * 2 + sizeof(bool));

                string username = DecodeString(nameBuffer, nameLen);
                string password = DecodeString(passBuffer, passLen);

                Account acc = new Account(username, password, hasResrt, banned);

                _accounts.Add(acc);

                pos += nameBuffer.Length + passBuffer.Length + infoBuffer.Length;
            }
        }


        private string ByteArrToString(byte[] arr)
        {
            string result = "";
            for (int i = 0; i < arr.Length; i++)
            {
                result += arr[i] + " ";
            }

            return result;
        }

    }
}
