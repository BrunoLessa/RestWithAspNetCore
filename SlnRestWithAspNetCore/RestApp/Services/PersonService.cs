using RestApp.Model;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RestApp.Services
{
    public class PersonService : IPersonService
    {
        private volatile int count = 0;
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 9; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);                
            }
            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Bruno " + i,
                LastName = "Ferreira " + i,
                Address = "São Gonçalo, Rio de Janeiro - Brasil " + i,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName ="Bruno",
                LastName ="Ferreira",
                Address ="São Gonçalo, Rio de Janeiro - Brasil",
                Gender ="Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
