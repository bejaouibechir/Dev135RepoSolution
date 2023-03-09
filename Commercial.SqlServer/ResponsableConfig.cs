using Commercial.Model;
using System.Data.Entity.ModelConfiguration;

namespace Commercial.SqlServer
{
    internal class ResponsableConfig : EntityTypeConfiguration<Responsable>
    {
        public ResponsableConfig()
        {
            HasKey(r => r.Code);
            Property(r=>r.Nom).IsRequired().HasMaxLength(50);
            Property(r => r.Contact).IsRequired().HasMaxLength(50);

            HasRequired(r => r.Société)
                .WithMany(s => s.Responsables)
                .HasForeignKey(r => r.SociétéId).WillCascadeOnDelete(true);

            ToTable("Responsables");
        }
    }
}