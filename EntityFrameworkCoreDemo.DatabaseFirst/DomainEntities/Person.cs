using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreDemo.DatabaseFirst.DomainEntities
{
    public partial class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? GenderId { get; set; }

        public virtual Gender Gender { get; set; }
    }
}
