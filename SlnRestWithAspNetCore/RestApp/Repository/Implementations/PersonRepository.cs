using RestApp.Model;
using RestApp.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestApp.Repository.Implementations
{
    public class PersonRepository : IPersonRepository
    {
        private MySqlContext _context;
        public PersonRepository(MySqlContext context)
        {
            _context = context;
        }
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id == id);

            if (result == null)
                return;

            try
            {
                _context.Persons.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.FirstOrDefault(x => x.Id == id);
        }

        public Person Update(Person person)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id == person.Id);

            if (result == null)
                return null;

            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return person;
        }
    }
}
