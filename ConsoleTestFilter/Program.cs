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
        static void Main(string [] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            using (EFContext context = new EFContext())
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
        }
    }
}
