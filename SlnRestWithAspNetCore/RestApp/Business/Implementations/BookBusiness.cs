using RestApp.Data.Converter;
using RestApp.Data.Converters;
using RestApp.Data.VO;
using RestApp.Model;
using RestApp.Repository.Generic;
using System.Collections.Generic;

namespace RestApp.Business.Implementations
{
    public class BookBusiness : IBookBusiness
    {
        private IGenericRepository<Book> _repository;
        private readonly IParser<BookVO, Book> _converter;
        private readonly IParser<Book, BookVO> _desconverter;

        public BookBusiness(IGenericRepository<Book> repository, IParser<BookVO, Book> converter, IParser<Book, BookVO> desconverter)
        {
            _repository = repository;
            _converter = converter;
            _desconverter = desconverter;
        }
        public BookVO Create(BookVO objeto)
        {
            var book = _converter.Parse(objeto);            
            return _desconverter.Parse(_repository.Create(book));
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BookVO> FindAll()
        {            
            var result = _desconverter.ParseList(_repository.FindAll());
            return result;
        }

        public BookVO FindById(long id)
        {
            return _desconverter.Parse(_repository.FindById(id));
        }

        public BookVO Update(BookVO objeto)
        {
            var book = _converter.Parse(objeto);
            return _desconverter.Parse(_repository.Update(book));
        }
    }
}
