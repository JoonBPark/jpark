namespace OAuth2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MsaModel : DbContext
    {
        public MsaModel()
            : base("name=MsaModel")
        {
        }

        public virtual DbSet<Cbpmsadeliveryconfpayload> Cbpmsadeliveryconfpayloads { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
