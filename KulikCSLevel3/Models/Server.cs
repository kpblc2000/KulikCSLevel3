using System;

namespace KulikCSLevel3.Models
{
    public class Server
    {
        private string _adress;
        private int _port;
        private bool _useSsl;

        public Server(string Adress, int Port, bool UseSSL)
        {

            if (Port < 0 || Port >= 65535)
            {
                throw new ArgumentOutOfRangeException(nameof(Port), Port, "Номер порта должен лежать в пределах 1..65535");
            }

            _adress = Adress;
            _port = Port;
            _useSsl = UseSSL;
        }

        public int Id { get; set; }

        public string Adress { get { return _adress; } set { _adress = value; } }

        public int Port { get { return _port; } set { _port = value; } }

        public bool UseSSL
        {
            get { return _useSsl; }
            set { _useSsl = value; }
        }

        public string Login { get; set; }

        public string Passord { get; set; }

        public string Description { get; set; }

    }
}
