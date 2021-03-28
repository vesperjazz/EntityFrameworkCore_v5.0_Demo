using System.Linq;

namespace EntityFrameworkCoreDemo.CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new EFCoreDemoContext())
            {
                var genders = context.Genders.ToList();

                //var firstPerson = new Person
                //{
                //    FirstName = "Ivan",
                //    LastName = "Chin",
                //    Gender = genders.Single(g => g.Code == "M")
                //};

                //context.Persons.Add(firstPerson);
                //context.SaveChanges();

                var ivan = context.Persons
                    .Where(p => p.FirstName == "Ivan")
                    .FirstOrDefault();

                //ivan.LastName = "Elessar";
                //context.SaveChanges();

                context.Persons.Remove(ivan);
                context.SaveChanges();
            }
        }
    }
}
