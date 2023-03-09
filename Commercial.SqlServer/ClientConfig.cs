using Commercial.Model;
using System.Data.Entity.ModelConfiguration;

namespace Commercial.SqlServer
{
    internal class ClientConfig : EntityTypeConfiguration<Client>
    {
        public ClientConfig()
        {
            HasKey(c => c.Code);
            Property(c => c.Nom).IsRequired().HasMaxLength(50);
            
            Property(c=>c.Naissance)
                .IsRequired()
                .HasColumnType("date");

            Property(c => c.CIN).IsRequired();
            Property(c=>c.DateCIN).IsRequired()
                .HasColumnType("date");

            Property(c => c.ParrainId).IsOptional();

            HasRequired(parrainé => parrainé.Parrain)
                .WithMany(parrain => parrain.Parrainés)
                .HasForeignKey(parrainé => parrainé.ParrainId)
                .WillCascadeOnDelete(false);

            HasRequired(c => c.Société).WithMany(s => s.Clients)
                .HasForeignKey(c => c.SociétéId);

            ToTable("Clients");

        }
    }
}