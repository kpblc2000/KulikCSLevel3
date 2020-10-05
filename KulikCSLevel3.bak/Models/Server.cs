using System;

namespace KulikCSLevel3.Models
{
    public class Server : ModelBase
    {
        private string _adress;
        private int _port;
        private bool _useSsl;

        public string Adress { get { return _adress; } set { _adress = value; } }

        public int Port
        {
            get { return _port; }
            set
            {
                if (_port <= 0 || _port > 65535)
                {
                    throw new ArgumentOutOfRangeException("Номер порта должен быть от 1 до 65535");
                }
                _port = value;
            }
        }

        public bool UseSSL
        {
            get { return _useSsl; }
            set { _useSsl = value; }
        }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Description { get; set; }

    }
}
