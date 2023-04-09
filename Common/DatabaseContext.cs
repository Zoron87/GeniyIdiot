using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniyIdiot.Common
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() :
           base(new SQLiteConnection()
           {
               ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = @"DB\GeniyIdiot.db", ForeignKeys = true }.ConnectionString
           }, true)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Question> Question { get; set; }
    }
}
