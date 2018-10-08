using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
<<<<<<< HEAD
=======

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

<<<<<<< HEAD
=======

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
namespace PasswordApplication.AccountManagement
{
    public class AccountRegistry
    {
<<<<<<< HEAD
        // максимальная длина имени и пароля 
        public const int MaxNameLenght = 20;
        public const int MaxPasswordLength = 20;

        // список аккаунтов 
=======
        public const int MaxNameLenght = 20;
        public const int MaxPasswordLength = 20;


>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
        private List<Account> _accounts = new List<Account>();

        private string _cryptoPassword;

<<<<<<< HEAD
        // конструктор 
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
        public AccountRegistry(string password)
        {
            _cryptoPassword = password;
        }

<<<<<<< HEAD
        // получить список аккаунтов вне класса 
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
        public Account[] GetAccounts()
        {
            return _accounts.ToArray();
        }

<<<<<<< HEAD
        // запись админа по умолчанию 
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
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

<<<<<<< HEAD
        // добавление аккаунта 
        public Account AddAccount(string username)
        {
            // по умолчанию аккаунт без пароля, ограничений и бана 
            Account acc = new Account(username, "", false, false);
            
                // проверка уникальности логина 
                    _accounts.Add(acc);
                    return acc;
        }

        // смена пароля на nPassword
=======

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

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
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

<<<<<<< HEAD
        // установка ограничений на пароль аналогично смене пароля 
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
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

<<<<<<< HEAD
        // бан аналогично 
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
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

<<<<<<< HEAD
        // получение индекса аккаунта зная только логин 
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
        private int IndexOf(string username)
        {
            for(int i = 0; i < _accounts.Count; i++)
                if (_accounts[i].GetUsername() == username)
                    return i;

            return -1;
        }

<<<<<<< HEAD
        //проверка уникальности 
        public bool IsUnique(string username)
=======
        private bool IsUnique(string username)
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
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

<<<<<<< HEAD
=======

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
        public void WriteAccounts(Stream stream)
        {
            if (stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);

            // Здесь будет зашифровывание
            byte[] salt = new byte[8]; // Необходимо сохранить в файл
<<<<<<< HEAD
            // криптографии соль — это строка случайных данных, которая подается на вход хеш-функции вместе с исходными данными. 
            // Основная задача соли — удлинение строки пароля, что значительно осложняет восстановление исходных паролей с помощью предварительно построенных радужных таблиц.


            byte[] ivKey; // Необходимо сохранить в файл
            // Вектор инициализации - случайное число, которое регулярно обновляется, передается по каналу управления и используется для инициализации алгоритма шифрования.


=======
            byte[] ivKey; // Необходимо сохранить в файл
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da

            // Intitalizing cryptrographic system
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            // Generating and saving IV
            tdes.GenerateIV();
            ivKey = tdes.IV;

            // Generating and saving salt
<<<<<<< HEAD
            RNGCryptoServiceProvider randomGenerator = new RNGCryptoServiceProvider(); 
            // Random rnd = new Random(); 
            // Не рандом, потому что рандом не безопасен с точки зрения криптографии. 
            // Рандом использует не криптографически безопасный алгоритм. 
            // Вероятность появляния байта в каждой последоательности можно предугадать. 
            // Для безопасной генерации нужно использовать криптографический генератор случаных чисел. 


=======
            RNGCryptoServiceProvider randomGenerator = new RNGCryptoServiceProvider(); // Random rnd = new Random(); - НЕ БЕЗОПАСЕН С ТОЧКИ ЗРЕНИЯ КРИПТОГРАФИИ
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
            randomGenerator.GetBytes(salt);

            // Generating cryptographic key from password, salt and IV

<<<<<<< HEAD
            // Размер ключа для TripleDES составляет 168 бит.

            // Задача: получить ключ требуемой длины из СТРОКИ любой длины.
            // ГРУБО ГОВОРЯ: Получаем HASH от строки с помощью MD5.
=======
            // AES имеет допустимые размеры ключей - 128 (16 байт), 192 (24 байта), 256 (32 байта) бит.

            // Задача: получить ключ требуемой длины из СТРОКИ любой длины.
            // ГРУБО ГОВОРЯ: Получаем HASH от строки с помощью MD5 (128 бит).
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
            // Для повышения безопасности генерации (усложнить перебор), к ключу до хэширования добавляется соль

            PasswordDeriveBytes passwordDeriver = new PasswordDeriveBytes(_cryptoPassword, salt);
            byte[] cryptoKey = passwordDeriver.CryptDeriveKey("TripleDES", "MD5", tdes.KeySize, ivKey); // Получили массив байт длины 16

<<<<<<< HEAD
            // Setting TripleDES's key
=======
            // Setting AES's key
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
            tdes.Key = cryptoKey;

            tdes.Mode = CipherMode.ECB; // Setting mode to Electronic Code Book

            // Creating CryptoStream
            ICryptoTransform cryptoTransform = tdes.CreateEncryptor();
            CryptoStream cryptoStream = new CryptoStream(stream, cryptoTransform, CryptoStreamMode.Write);
            
            WriteToStream(cryptoStream);

<<<<<<< HEAD
            cryptoStream.Flush(); // очищение буферов текущего потока 
=======
            cryptoStream.Flush();
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
            cryptoStream.FlushFinalBlock();

            //cryptoStream.Close();

            // Writing salt and IV to FileStream before encryption starts
<<<<<<< HEAD
            // соль и вектор надо записывать, потому что иначе ключ будет другим
=======

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
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

<<<<<<< HEAD
            // задание текущей позиции в потоке 
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
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
<<<<<<< HEAD
            // создание объекта дешифратора 
            ICryptoTransform cryptoTransform = tdes.CreateDecryptor();

=======

            ICryptoTransform cryptoTransform = tdes.CreateDecryptor();
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
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

<<<<<<< HEAD
            while (dataLen - pos > 90)
=======
            while (dataLen - pos > 90) // TODO FIX ME KOSTIL!
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
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
<<<<<<< HEAD
=======

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
    }
}
