using Commercial.Model;
using System.Data.Entity.ModelConfiguration;

namespace Commercial.SqlServer
{
    internal class ArticleConfig : EntityTypeConfiguration<Article>
    {
        public ArticleConfig()
        {
            HasKey(a => a.Code);
            Property(a=>a.Designation).IsRequired().HasMaxLength(50);
            Property(a => a.Montant).IsRequired();

            HasRequired(a=>a.Vente).WithMany(v=>v.Articles)
                .HasForeignKey(a=>a.VenteId).WillCascadeOnDelete(true);

        ToTable("Articles");
        }
    }
}