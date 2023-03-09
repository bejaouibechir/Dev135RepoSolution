using Commercial.Model;
using System.Data.Entity.ModelConfiguration;

namespace Commercial.SqlServer
{
    internal class PaiementConfig : EntityTypeConfiguration<Paiement>
    {
        public PaiementConfig()
        {
            HasKey(p => p.Code);
            Property(p=>p.CodeClient).IsRequired().HasMaxLength(50);

            Property(p => p.DateEffective).HasColumnType("date");
            Property(p => p.Echéance).HasColumnType("date");

            HasRequired(p=>p.Vente).WithMany(v=>v.Paiements)
                .HasForeignKey(p=>p.VenteId).WillCascadeOnDelete(true);

            ToTable("Paiements");
        }
    }
}