using LibraryWeb.data;

namespace LibraryWeb.Services
{
    public class MemberService
    {
        private readonly MembersContext _context;
        public MemberService(MembersContext context)
        {
            _context = context;
        }
        public bool MemberExists(int Id)
        {
            return _context.Members.Any(b => b.Id == Id);
        }
    }
}
