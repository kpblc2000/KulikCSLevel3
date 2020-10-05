using System;
using System.Net.Mail;

namespace KulikCSLevel3.Models
{
    public class Recipient : ModelBase
    {

        public string Name { get; set; }

        public string EmailAdress { get; set; }
    }
}
