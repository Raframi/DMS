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
    public class DocumentManagerEntities : DbContext
    {
        public DocumentManagerEntities()
            : base("name=DocumentManagerEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
    }
}
