using WpfMailSender.Models.Base;

namespace KulikCSLevel3.Models
{
    public class Server : NamedEntity
    {
        public string Address { get; set; }
        public int Port { get; set; } = 25;
        public bool UseSSL { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
    }
}
