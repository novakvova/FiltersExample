using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestFilter
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            using (EFContext context = new EFContext())
            {
                //TestWorkInitDatabasePrint(context);

                var listFilters = GetFilters(context);
                foreach(var fName in listFilters)
                {
                    Console.WriteLine("{0} - {1}",fName.Id,fName.Name);
                    foreach(var fValue in fName.Childrens)
                    {
                        Console.WriteLine("\t{0} - {1}", fValue.Id, fValue.Name);
                    }
                }

                //Масив фільтрів, які потрібно примінити до продуктів
                int[] filterValueList = { 6, 7, 2 };


            }
        }
        static void TestWorkInitDatabasePrint(EFContext context)
        {
            Console.WriteLine("Кількість назв фільтрів {0}",
                   context.FilterNames.Count());
            Console.WriteLine("Кількість значень фільрів {0}",
                context.FilterValues.Count());
            Console.WriteLine("Кількість категорій {0}",
                context.Categories.Count());
            Console.WriteLine("Кількість продуктів {0}",
                context.Categories.Count());
            Console.WriteLine("Кількість по групах фільрів назв {0}",
                context.FilterNameGroups.Count());
            Console.WriteLine("Кількість фільрів по продуктах {0}",
                context.Filters.Count());
        }
        static List<FNodeTreeView> GetFilters(EFContext context)
        {
            var query = from f in context.VFilterNameGroups.AsQueryable()
                        where f.FilterValueId != null
                        select new
                        {
                            FNameId = f.FilterNameId,
                            FName = f.FilterName,
                            FValueId = f.FilterValueId,
                            FValue = f.FilterValue
                        };
            var groupNames = from f in query
                             group f by new
                             {
                                 Id = f.FNameId,
                                 Name = f.FName
                             } into g
                             orderby g.Key.Name

                             select g;
            List<FNodeTreeView> listFilters = new List<FNodeTreeView>();
            foreach (var filterName in groupNames)
            {
                FNodeTreeView node = new FNodeTreeView
                {
                    Id = filterName.Key.Id,
                    Name = filterName.Key.Name,
                    Childrens = new List<FTreeViewItem>()
                };
                var fValues = from v in filterName
                              group v by new FTreeViewItem
                              {
                                  Id = v.FValueId,
                                  Name = v.FValue
                              } into g
                              select g.Key;

                foreach (var item in fValues)
                {
                    //if (string.IsNullOrEmpty(item.Name))
                    //    continue;
                    node.Childrens.Add(item);
                }
                listFilters.Add(node);
            }
            return listFilters;
        }

    }
}
