using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Gazallion.MigraineManager.Data.SqlServer.Models.Mapping;
using Gazallion.MigraineManager.Data.Models;


namespace Gazallion.MigraineManager.Data.SqlServer.Models
{
    public class GazallionMigraineDataDbContext : DbContext
    {
        static GazallionMigraineDataDbContext()
        {
            Database.SetInitializer<GazallionMigraineDataDbContext>(null);
        }

		public GazallionMigraineDataDbContext()
			: base("Name=GazallionMigraineDataDbContext")
		{
            
		}

        public DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<MedHistory> MedHistories { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedType> MedTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCondition> UserConditions { get; set; }
        public DbSet<UserMed> UserMeds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new C__RefactorLogMap());
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new ConditionMap());
            modelBuilder.Configurations.Add(new DietMap());
            modelBuilder.Configurations.Add(new MedHistoryMap());
            modelBuilder.Configurations.Add(new MedicineMap());
            modelBuilder.Configurations.Add(new MedTypeMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserConditionMap());
            modelBuilder.Configurations.Add(new UserMedMap());
            
        }
    }
}
