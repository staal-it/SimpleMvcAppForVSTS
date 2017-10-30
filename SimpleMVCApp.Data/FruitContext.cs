using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SimpleMVCApp.Data
{
    public class FruitContext : DbContext
    {
        public FruitContext() : base("FruitContext")
        {

        }

        public DbSet<Fruit> Fruits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
