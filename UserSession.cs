using System;

namespace DB_M2_Chat
{
    // Singleton class to store user session information
    public class UserSession
    {
        private static UserSession _instance;
        private static readonly object _lock = new object();

        // User properties
        public string ProviderID { get; private set; }
        public string Username { get; private set; }
        public string ProviderName { get; private set; }

        private UserSession() { }

        public static UserSession Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new UserSession();
                        }
                    }
                }
                return _instance;
            }
        }

        public void SetUserInfo(string providerID, string username, string providerName = "")
        {
            ProviderID = providerID;
            Username = username;
            ProviderName = providerName;
        }

        public void ClearUserInfo()
        {
            ProviderID = null;
            Username = null;
            ProviderName = null;
        }

        public bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(ProviderID);
        }
    }
}