using Commercial.Model;
using System.Data.Entity.ModelConfiguration;

namespace Commercial.SqlServer
{
    /*
       ct: Contact
       c: Client
     */
    
    internal class ContactConfig : EntityTypeConfiguration<Contact>
    {
        public ContactConfig()
        {
            HasKey(ct => ct.Code);
            Property(ct => ct.Téléphone).IsRequired().HasMaxLength(50);
            Property(ct => ct.Relatif).IsRequired().HasMaxLength(50);
            Property(ct => ct.NomRelatif).IsRequired().HasMaxLength(50);

            HasRequired(ct => ct.Client)
                .WithMany(c => c.Contacts)
                .HasForeignKey(ct => ct.ClientId)
                .WillCascadeOnDelete(true);

            ToTable("Contacts");
        }
    }
}