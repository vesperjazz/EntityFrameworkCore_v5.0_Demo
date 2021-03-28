using System;

namespace EntityFrameworkCoreDemo.CodeFirst.DomainEntities
{
    public class Person
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid? GenderID { get; set; }
        public Gender Gender { get; set; }
    }
}
