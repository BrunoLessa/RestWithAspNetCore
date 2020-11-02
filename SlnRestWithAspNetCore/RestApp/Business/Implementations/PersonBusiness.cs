using RestApp.Data.Converters;
using RestApp.Data.VO;
using RestApp.Model;
using RestApp.Repository.Generic;
using System.Collections.Generic;

namespace RestApp.Business.Implementations
{
    public class PersonBusiness : IPersonBusiness
    {
        private IGenericRepository<Person> _repository;
        private readonly PersonConverter _converter;
        public PersonBusiness(IGenericRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }
        public PersonVO Create(PersonVO person)
        {            
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<PersonVO> FindAll()
        {
            var retorno = _repository.FindAll();
            return _converter.ParseList(retorno);
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }
    }
}
