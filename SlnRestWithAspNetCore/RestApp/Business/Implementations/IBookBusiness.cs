using RestApp.Data.VO;
using System.Collections.Generic;

namespace RestApp.Business.Implementations
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO objeto);
        BookVO FindById(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO objeto);
        void Delete(long id);
    }
}
