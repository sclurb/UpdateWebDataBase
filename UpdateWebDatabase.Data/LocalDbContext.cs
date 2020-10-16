using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography.X509Certificates;
using UpdateWebDataBase.Domain;

namespace UpdateWebDatabase.Data
{
    public class LocalDbContext : DbContext
    {
        public DbSet<Stuff> Stuff { get; set; }
        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    builder.UseSqlServer("Data Source=.\\SQLSERVERFORIIS; AttachDbFilename=Z:\\Web\\App_Data\\Original.mdf; " +
        //        "Integrated Security=false; User = fred; password = Chainsaw1; MultipleActiveResultSets=True;");
        //}
    }
}
