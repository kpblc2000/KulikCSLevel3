using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace KulikCSLevel3.Data
{
    class MailSenderDBContextInitializer : IDesignTimeDbContextFactory<MailSenderDB>
    {
        public MailSenderDB CreateDbContext(string[] args)
        {
            const string connString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=MailSenderDB; Integrated Security=True;";

            DbContextOptionsBuilder<MailSenderDB> optionsBuilder = new DbContextOptionsBuilder<MailSenderDB>();
            optionsBuilder.UseSqlServer(connString);
            return new MailSenderDB(optionsBuilder.Options);
        }
    }
}
