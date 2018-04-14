using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class DatabaseInitializerIsExist : CreateDatabaseIfNotExists<EFContext>
    {
        protected override void Seed(EFContext context)
        {
            #region InitCategory
            context.Categories.AddOrUpdate(
                h => h.Id,
                new Category
                {
                    Id = 1,
                    Name = "Одяг",
                    ParentId = null
                });
            #endregion
            #region InitFilteName
            context.FilterNames.AddOrUpdate(
                h => h.Id,
                new FilterName
                {
                    Id = 1,
                    Name = "Колір"
                });
            context.FilterNames.AddOrUpdate(
                h => h.Id,
                new FilterName
                {
                    Id = 2,
                    Name = "Розмір"
                });
            #endregion
            base.Seed(context);
        }
    }
}
