using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreDemo.DatabaseFirst.DomainEntities
{
    public partial class Gender
    {
        public Gender()
        {
            Person = new HashSet<Person>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
