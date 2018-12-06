using DMSModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSDAL
{
    public class DMSDbContext : DbContext
    {
        public DMSDbContext() : base("name=DMSDbContext")
        {
            //Database.SetInitializer<DMSDbContext>(new DropCreateDatabaseAlways<DMSDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

        public virtual DbSet<DocumentType> DocumentType { get; set; }
        public virtual DbSet<Keyword> Keyword { get; set; }
    }
}
