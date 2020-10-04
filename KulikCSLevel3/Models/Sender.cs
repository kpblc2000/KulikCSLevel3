using System;
using System.Net.Mail;
using System.Security;

namespace KulikCSLevel3.Models
{
    /// <summary>
    /// Объект автора письма
    /// </summary>
    public class Sender
    {
        public string Name { get; set; }

        public string EmailAdress { get; set; }
    }
}
