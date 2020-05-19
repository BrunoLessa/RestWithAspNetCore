using RestApp.Model;
using RestApp.Repository.Generic;
using System.Collections.Generic;

namespace RestApp.Business.Implementations
{
    public class BookBusiness : IBookBusiness
    {
        private IGenericRepository<Book> _repository;

        public BookBusiness(IGenericRepository<Book> repository)
        {
            _repository = repository;
        }
        public Book Create(Book objeto)
        {
            return _repository.Create(objeto);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Book> FindAll()
        {
            var result = _repository.FindAll();
            return result;
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Update(Book objeto)
        {
            return _repository.Update(objeto);
        }
    }
}
