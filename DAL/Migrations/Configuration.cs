namespace DAL.Migrations
{
    using DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Entities.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Entities.EFContext context)
        {
            #region InitCategory
            context.Categories.AddOrUpdate(
                h => h.Id,
                new Category
                {
                    Id = 1,
                    Name = "Îäÿã",
                    ParentId = null
                });
            #endregion
        }
    }
}
