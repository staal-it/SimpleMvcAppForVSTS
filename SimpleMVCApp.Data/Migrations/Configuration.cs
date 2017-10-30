namespace SimpleMVCApp.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<FruitContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SimpleMVCApp.Data.FruitContext";
        }

        protected override void Seed(SimpleMVCApp.Data.FruitContext context)
        {
            context.Fruits.AddOrUpdate(f => f.Name,
                            new Fruit { Name = "Apple" },
                            new Fruit { Name = "Banana" },
                            new Fruit { Name = "Orange" }
                        );
        }
    }
}
