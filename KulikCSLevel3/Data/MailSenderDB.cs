using KulikCSLevel3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WpfMailSender.Models;

namespace KulikCSLevel3.Data
{
    class MailSenderDB : DbContext
    {

        public DbSet<Message> Messages { get; set; }

        public DbSet<Recipient> Recipients { get; set; }

        public DbSet<Sender> Senders { get; set; }

        public DbSet<Server> Servers { get; set; }

        public DbSet<SchedulerTask> SchedulerTasks { get; set; }

        public MailSenderDB(DbContextOptions<MailSenderDB> opt) : base(opt) { }
    }
}
