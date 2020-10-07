using WpfMailSender.Models.Base;

namespace KulikCSLevel3.Models
{
    public class Message : Entity
    {
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
