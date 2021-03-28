using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreDemo.CodeFirst.DomainEntities
{
    public class Gender
    {
        public Guid ID { get; set; }
        
        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}
