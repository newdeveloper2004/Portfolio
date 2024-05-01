using LibraryWeb.data;
using Microsoft.AspNetCore.Mvc;
using LibraryWeb.Models;
using Microsoft.EntityFrameworkCore;
using LibraryWeb.Services;


namespace LibraryWeb.Controllers
{
    public class BookController : Controller
    {
        private readonly BooksContext _db;
        private readonly LentBooksContext _lb;
        private readonly BookService _bookservice;
        private readonly MemberService _memberservice;
        private readonly MembersContext _members;
        private readonly IssueService _issueservice;
        public string date;
        public DateTime datetime;
        public DateOnly UserDate;
        public BookController(BooksContext db, LentBooksContext lb, BookService bookservice, MemberService memberservice, MembersContext members, IssueService issueservice)
        {
            _db = db;
            _bookservice = bookservice;
            _lb = lb;
            _memberservice = memberservice;
            _members = members;
            _issueservice = issueservice;
        }

        public IActionResult Books()
        {
            IEnumerable<Books> objBooks = _db.books;
            return View(objBooks);
        }
        public IActionResult Lent()
        {
            IEnumerable<LentBooks> objLent = _lb.lent_books;
            return View(objLent);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Books obj)
        {
            if(obj.Title == obj.Author)
            {
                ModelState.AddModelError("CustomError", "The Title and Author name cannot match");
            }
            if(obj.Title == obj.Price.ToString())
            {
                ModelState.AddModelError("CustomError2", "Title and price cannot be the same");
            }
            if(obj.Author == obj.Price.ToString())
            {
                ModelState.AddModelError("CustomError3", "Author name and price cannot match");
            }
            if (ModelState.IsValid)
            {
                _db.books.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Book added Successfully";
                return RedirectToAction("Books");
            }
            return View(obj);
        }
        //GET
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var CategoryFromDb = _db.books.Find(id);
            if(CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Books obj)
        {
            if (obj.Title == obj.Author)
            {
                ModelState.AddModelError("CustomError", "The Title and Author name cannot match");
            }
            if (obj.Title == obj.Price.ToString())
            {
                ModelState.AddModelError("CustomError2", "Title and price cannot be the same");
            }
            if (obj.Author == obj.Price.ToString())
            {
                ModelState.AddModelError("CustomError3", "Author name and price cannot match");
            }
            if (ModelState.IsValid)
            {
                _db.books.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Book Updated Successfully";
                return RedirectToAction("Books");
            }
            return View(obj);
        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CategoryFromDb = _db.books.Find(id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
           
            var obj = _db.books.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
                _db.books.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Book deleted Successfully";
            return RedirectToAction("Books");
            
        }
        //GET
        public IActionResult Issue()
        {
             return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Issue(LentBooks objL, int id, int Member_id, int Id)
        {
            Console.WriteLine($"Book ID: {id}, Member ID: {Member_id}, Issue ID: {Id}");

            if (!_bookservice.BookExists(id))
            {
                Console.WriteLine("Book Not Found");
                return NotFound("Book Not Found");
            }
            if (!_memberservice.MemberExists(Member_id))
            {
                Console.WriteLine("Member not found");
                return NotFound("Member not found");
            }
            if (_issueservice.IsIssued(Id))
            {
                Console.WriteLine("Book already issued");
                return NotFound("Book Already issued");
            }
            
            objL.Lent_Date = DateTime.Now;
            objL.Due_Date = DateTime.Now.AddDays(30);
            _lb.lent_books.Add(objL);
            _lb.SaveChanges();

            Console.WriteLine("Book issued successfully.");
            return RedirectToAction("Lent");
        }

        public IActionResult Members()
        {
            IEnumerable<Members> objMembers = _members.Members;
            return View(objMembers);
        }
        //GET
        public IActionResult Join()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Join(Members obj)
        {
            if (ModelState.IsValid)
            {
                _members.Members.Add(obj);
                _members.SaveChanges();
                return RedirectToAction("Members");
            }
            return View(obj);
        }

       
    }
}
