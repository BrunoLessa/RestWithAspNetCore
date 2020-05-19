using Microsoft.AspNetCore.Mvc;
using RestApp.Business.Implementations;
using RestApp.Model;

namespace RestApp.Controllers
{
    [Route("api/[controller]")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookBusiness _bookBusiness;
        public BooksController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            var resultado = _bookBusiness.FindById(id);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null)
                return BadRequest();
            return new ObjectResult(_bookBusiness.Create(book));
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            if (book == null)
                return BadRequest();
            var retorno = _bookBusiness.Update(book);
            if (retorno == null)
                return BadRequest();
            return new ObjectResult(_bookBusiness.Update(book));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _bookBusiness.FindById(id);
            if (result == null) return BadRequest();

            _bookBusiness.Delete(id);

            return NoContent();
        }
    }
}
