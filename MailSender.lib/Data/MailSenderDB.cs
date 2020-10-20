using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfMailSender.Data
{
   public  class MailSenderDB : DbContext
    {
        public MailSenderDB(DbContextOptions<MailSenderDB> options) : base(options) { }
    }
}
