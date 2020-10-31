namespace Edfa3lyTechInterview.Migrations
{
	using System;
	using System.Data.Entity.Migrations;

	public partial class InitialCreate : DbMigration
	{
		public override void Down()
		{
			DropForeignKey("dbo.Discount", "ProductID", "dbo.Product");
			DropForeignKey("dbo.Discount", "OnProductID", "dbo.Product");
			DropForeignKey("dbo.Cart", "ProductID", "dbo.Product");
			DropIndex("dbo.Discount", new[] { "ProductID" });
			DropIndex("dbo.Discount", new[] { "OnProductID" });
			DropIndex("dbo.Cart", new[] { "ProductID" });
			DropTable("dbo.Discount");
			DropTable("dbo.Product");
			DropTable("dbo.Cart");
		}

		public override void Up()
		{
			CreateTable(
				"dbo.Cart",
				c => new
				{
					ID = c.Guid(nullable: false),
					PriceOfCartItemAfterDiscount = c.Int(nullable: false),
					ProductID = c.Guid(nullable: false),
					Quantity = c.Int(nullable: false),
					TotalPriceOfCartItem = c.Int(nullable: false),
				})
				.PrimaryKey(t => t.ID)
				.ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
				.Index(t => t.ProductID);

			CreateTable(
				"dbo.Product",
				c => new
				{
					ID = c.Guid(nullable: false),
					Name = c.String(),
					Price = c.Double(nullable: false),
				})
				.PrimaryKey(t => t.ID);

			CreateTable(
				"dbo.Discount",
				c => new
				{
					ID = c.Guid(nullable: false),
					DiscountPercentage = c.Int(nullable: false),
					OnProductID = c.Guid(nullable: false),
					ProductID = c.Guid(nullable: false),
					QuantityRequiredForDiscount = c.Int(nullable: false),
				})
				.PrimaryKey(t => t.ID)
				.ForeignKey("dbo.Product", t => t.OnProductID, cascadeDelete: false)
				.ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
				.Index(t => t.OnProductID)
				.Index(t => t.ProductID);
		}
	}
}
