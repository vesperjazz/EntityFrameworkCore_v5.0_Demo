using EntityFrameworkCoreDemo.DatabaseFirst.DomainEntities;
using System;
using System.Linq;

namespace EntityFrameworkCoreDemo.DatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EFCoreDemoContext())
            {
                var genders = context.Gender.ToList();
            }
        }
    }
}
