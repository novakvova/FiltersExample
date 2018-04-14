namespace DAL.Migrations
{
    using DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Entities.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Entities.EFContext context)
        {
            //string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            //UriBuilder uri = new UriBuilder(codeBase);
            //string path = Uri.UnescapeDataString(uri.Path);

            //string baseDir = Path.GetDirectoryName(path) + "\\Migrations\\ViewFilters\\vFilterNameGroups.sql";
            //context.Database.ExecuteSqlCommand(File.ReadAllText(baseDir));
            //#region InitCategory
            //context.Categories.AddOrUpdate(
            //    h => h.Id,
            //    new Category
            //    {
            //        Id = 1,
            //        Name = "����",
            //        ParentId = null
            //    });
            //#endregion

        }
    }
}
