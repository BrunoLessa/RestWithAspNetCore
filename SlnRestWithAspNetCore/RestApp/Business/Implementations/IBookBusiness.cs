using RestApp.Model;
using System.Collections.Generic;

namespace RestApp.Business.Implementations
{
    public interface IBookBusiness
    {
        Book Create(Book objeto);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book objeto);
        void Delete(long id);
    }
}
