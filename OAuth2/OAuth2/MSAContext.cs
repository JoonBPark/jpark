using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2
{
    class MSAContext:DbContext
    {
        public MSAContext()
            : base("name=MsaModel")
        {

        }


        public virtual DbSet<Cbpmsadeliveryconfpayload> Cbpsadeliveryconfpayloads { get; set; }
//        public DbSet<Msapayloads> Msapayloads { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          //  Database.SetInitializer(new MigrateDatabaseToLatestVersion<MSAContext, Migrations.Configuration>());

            //throw new UnintentionalCodeFirstException();
        }

    }
}
