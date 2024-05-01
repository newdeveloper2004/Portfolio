using LibraryWeb.data;

namespace LibraryWeb.Services
{
    public class IssueService
    {
        private readonly LentBooksContext _context;
        public IssueService(LentBooksContext context)
        {
            _context = context;
        }
        public bool IsIssued(int Id)
        {
            return _context.lent_books.Any(b => b.Id == Id);
        }
    }
}
