namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CateatetableforFilters : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        Price = c.Single(nullable: false),
                        Quantity = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.tblFilters",
                c => new
                    {
                        FilterNameId = c.Int(nullable: false),
                        FilterValueId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FilterNameId, t.FilterValueId, t.ProductId })
                .ForeignKey("dbo.tblFilterNames", t => t.FilterNameId, cascadeDelete: true)
                .ForeignKey("dbo.tblFilterValues", t => t.FilterValueId, cascadeDelete: true)
                .ForeignKey("dbo.tblProducts", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.FilterNameId)
                .Index(t => t.FilterValueId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.tblFilterNames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblFilterNameGroups",
                c => new
                    {
                        FilterNameId = c.Int(nullable: false),
                        FilterValueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FilterNameId, t.FilterValueId })
                .ForeignKey("dbo.tblFilterNames", t => t.FilterNameId, cascadeDelete: true)
                .ForeignKey("dbo.tblFilterValues", t => t.FilterValueId, cascadeDelete: true)
                .Index(t => t.FilterNameId)
                .Index(t => t.FilterValueId);
            
            CreateTable(
                "dbo.tblFilterValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblFilters", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.tblFilters", "FilterValueId", "dbo.tblFilterValues");
            DropForeignKey("dbo.tblFilters", "FilterNameId", "dbo.tblFilterNames");
            DropForeignKey("dbo.tblFilterNameGroups", "FilterValueId", "dbo.tblFilterValues");
            DropForeignKey("dbo.tblFilterNameGroups", "FilterNameId", "dbo.tblFilterNames");
            DropForeignKey("dbo.tblProducts", "CategoryId", "dbo.tblCategories");
            DropIndex("dbo.tblFilterNameGroups", new[] { "FilterValueId" });
            DropIndex("dbo.tblFilterNameGroups", new[] { "FilterNameId" });
            DropIndex("dbo.tblFilters", new[] { "ProductId" });
            DropIndex("dbo.tblFilters", new[] { "FilterValueId" });
            DropIndex("dbo.tblFilters", new[] { "FilterNameId" });
            DropIndex("dbo.tblProducts", new[] { "CategoryId" });
            DropTable("dbo.tblFilterValues");
            DropTable("dbo.tblFilterNameGroups");
            DropTable("dbo.tblFilterNames");
            DropTable("dbo.tblFilters");
            DropTable("dbo.tblProducts");
        }
    }
}
