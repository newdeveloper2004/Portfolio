using LibraryWeb.data;

namespace LibraryWeb.Services
{
    public class BookService
    {
        private readonly BooksContext _context;
        public BookService(BooksContext context) 
        {
            _context = context;
        }
        public bool BookExists(int Id)
        {
            return _context.books.Any(b=>b.ID == Id);
        }
    }
}
