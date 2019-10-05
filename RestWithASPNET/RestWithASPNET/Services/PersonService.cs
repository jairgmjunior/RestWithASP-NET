using RestWithASPNET.Models;
using RestWithASPNET.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNET.Services
{
    public class PersonService : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
        }

        public List<Person> FindAll()
        {
            var persons = new List<Person>();

            for(var it = 1; it <= 10; it++)
            {
                persons.Add(MockPerson(it));
            }

            return persons;
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "nome1",
                LastName = "1",
                Address = "Campinas - SP",
                Gender = "M"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = $"Nome{i}",
                LastName = $"Sobrenome{i}",
                Address = $"Endereco - {i}",
                Gender = "M"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
