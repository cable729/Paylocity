using System.Collections.Generic;
using System.Linq;

namespace Paylocity.Models
{
    public class Employee : Person
    {
        public Employee(string firstName, string lastName, IEnumerable<Person> dependents) : base(firstName, lastName)
        {
            Dependents = dependents;
        }

        public Employee(string firstName, string lastName) : this(firstName, lastName, Enumerable.Empty<Person>())
        {
        }

        public IEnumerable<Person> Dependents { get; set; }
    }
}