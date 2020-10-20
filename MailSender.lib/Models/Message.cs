using System.ComponentModel.DataAnnotations;
using WpfMailSender.Models.Base;

namespace KulikCSLevel3.Models
{
    public class Message : Entity
    {

        [Required, MaxLength(120)]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }
    }
}
