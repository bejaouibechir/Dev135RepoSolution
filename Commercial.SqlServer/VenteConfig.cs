using Commercial.Model;
using System.Data.Entity.ModelConfiguration;

namespace Commercial.SqlServer
{
    internal class VenteConfig : EntityTypeConfiguration<Vente>
    {
        public VenteConfig()
        {
            HasKey(v => v.Code);
            Property(v => v.Tranches).IsRequired();
            Property(v=>v.PremièreEchéance).HasColumnType("date");
            Property(v => v.DernièreEchéance).HasColumnType("date");

            HasRequired(v => v.Client).WithMany(c => c.Ventes)
                .HasForeignKey(v => v.ClientId).WillCascadeOnDelete(true);
            
            ToTable("Ventes");
        }
    }
}