using RestApp.Model;
using RestApp.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApp.Business.Implementations
{
    public class PersonBusiness : IPersonBusiness
    {
        private readonly IPersonRepository _personrepository;
        public PersonBusiness(IPersonRepository personrepository)
        {
            _personrepository = personrepository;
        }
        public Person Create(Person person)
        {
            return _personrepository.Create(person);
        }

        public void Delete(long id)
        {
            _personrepository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _personrepository.FindAll();
        }

        public Person FindById(long id)
        {
            return _personrepository.FindById(id);
        }

        public Person Update(Person person)
        {
            return _personrepository.Update(person);
        }
    }
}
