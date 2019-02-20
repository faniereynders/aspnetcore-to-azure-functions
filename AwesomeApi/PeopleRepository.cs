using System.Collections.Generic;
using System.Linq;

namespace AwesomeApi
{
    public interface IPeopleRepository
    {
        Person[] GetAll();
        Person GetById(int id);
    }
    public class PeopleRepository : IPeopleRepository
    {
        private static readonly IEnumerable<Person> names = new List<Person>
        {
            new Person { Id = 1, Name = "Fanie" },
            new Person { Id = 2, Name = "Steven" },
            new Person { Id = 3, Name = "Carlos" }
        };

        public Person[] GetAll() => names.ToArray();

        public Person GetById(int id) => names.SingleOrDefault(p => p.Id.Equals(id));
    }
}
