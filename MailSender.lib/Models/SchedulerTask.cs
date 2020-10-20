using KulikCSLevel3.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WpfMailSender.Models.Base;

namespace WpfMailSender.Models
{
    public class SchedulerTask : Entity
    {
        public DateTime Time { get; set; }
        public Server Server { get; set; }
        public Sender Sender { get; set; }
        public ICollection<Recipient> Recipients { get; set; }
        public Message Message { get; set; }
    }
}
