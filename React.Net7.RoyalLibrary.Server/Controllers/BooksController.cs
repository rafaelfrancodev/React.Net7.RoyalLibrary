using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using React.Net7.RoyalLibrary.Server.Models;
using React.Net7.RoyalLibrary.Server.Repository;


namespace React.Net7.RoyalLibrary.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context; 

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.BookId)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBook), new { id = book.BookId }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Books/SearchByAuthor?firstName=Jane&lastName=Austen
        [HttpGet("SearchByAuthor")]
        public async Task<ActionResult<IEnumerable<Book>>> SearchByAuthor(string firstName, string lastName)
        {
            return await _context.Books.Where(b => b.FirstName == firstName && b.LastName == lastName).ToListAsync();
        }

        // GET: api/Books/SearchByISBN?isbn=1234567891
        [HttpGet("SearchByISBN")]
        public async Task<ActionResult<IEnumerable<Book>>> SearchByISBN(string isbn)
        {
            return await _context.Books.Where(b => b.Isbn == isbn).ToListAsync();
        }

        // GET: api/Books/SearchByCategory?category=Fiction
        [HttpGet("SearchByCategory")]
        public async Task<ActionResult<IEnumerable<Book>>> SearchByCategory(string category)
        {
            return await _context.Books.Where(b => b.Category == category).ToListAsync();
        }

        // Helper method to check if a book exists
        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }
    }
}
