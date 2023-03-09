using Commercial.Model;
using System.Data.Entity;

namespace Commercial.SqlServer
{
    public class CommercialContext: DbContext
    {

        public CommercialContext(string connectionString="CommercialConnection")
            :base(connectionString)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CommercialContext>());
        }

        public DbSet<Société> Sociétés { get; set; }
        public DbSet<Responsable> Responsables { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Vente> Ventes { get; set; }
        public DbSet<Paiement> Paiements { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new SociétéConfig());
            modelBuilder.Configurations.Add(new ResponsableConfig());
            modelBuilder.Configurations.Add(new ClientConfig());
            modelBuilder.Configurations.Add(new ContactConfig());
            modelBuilder.Configurations.Add(new VenteConfig());
            modelBuilder.Configurations.Add(new PaiementConfig());
            modelBuilder.Configurations.Add(new ArticleConfig());
        }



    }
}
