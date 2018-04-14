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
            using (EFContext context = new EFContext())
            {
                Console.WriteLine("Кількість назв фільтрів {0}", 
                    context.FilterNames.Count());
                Console.WriteLine("Кількість категорій {0}",
                    context.Categories.Count());
            }
        }
    }
}
