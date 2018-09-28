namespace PasswordApplication.AccountManagement
{
    struct Account
    {
        private string _username;
        private string _password;
        private bool _hasPasswordRestrictions;
        private bool _banned;

        internal Account(string username, string password, bool passRestrictions, bool banned)
        {
            _username = username;
            _password = password;
            _hasPasswordRestrictions = passRestrictions;
            _banned = banned;
        }

        public string GetUsername()
        {
            return _username;
        }

        public string GetPassword()
        {
            return _password;
        }

        public bool HasPasswordRestrictions()
        {
            return _hasPasswordRestrictions;
        }

        public bool IsBanned()
        {
            return _banned;
        }
    }
}
