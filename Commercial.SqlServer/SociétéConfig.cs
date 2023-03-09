using Commercial.Model;
using System.Data.Entity.ModelConfiguration;
//using System.ComponentModel.DataAnnotations.Schema;

namespace Commercial.SqlServer
{
    internal class SociétéConfig : EntityTypeConfiguration<Société>
    {
        public SociétéConfig()
        {
            HasKey(s => s.Code);
            //Si on veut auto génerer les valeurs de la clé primaire IDENTITY(1,1)
            //Property(s => s.Code).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(s => s.Raison).IsRequired().HasMaxLength(50);

            ToTable("Sociétés");
        }
    }
}