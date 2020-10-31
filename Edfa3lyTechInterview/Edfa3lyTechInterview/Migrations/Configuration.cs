namespace Edfa3lyTechInterview.Migrations
{
	using Edfa3lyTechInterview.DAL;
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<Edfa3lyTechInterview.DAL.Context>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(Edfa3lyTechInterview.DAL.Context context)
		{
			// This method will be called after migrating to the latest version.

			// You can use the DbSet<T>.AddOrUpdate() helper extension method to avoid creating
			// duplicate seed data.
			ContextSeedInitializer init = new ContextSeedInitializer();
			init.SeedCall(context);
		}
	}
}
