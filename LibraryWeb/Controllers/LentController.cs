using LibraryWeb.data;
using LibraryWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Security.AccessControl;

namespace LibraryWeb.Controllers
{
    public class LentController : Controller
    {
        private readonly  LentBooksContext _lb;

        
        
        public LentController(LentBooksContext lb)
        {
            _lb = lb;
        }
        
        public IActionResult Lent()
        {
            IEnumerable<LentBooks> objL = _lb.lent_books;
            
            return View(objL);
        }
        //GET 
        public IActionResult ReturnBook(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var CategoryFromLb = _lb.lent_books.Find(id);
            if(CategoryFromLb == null)
            {
                return NotFound();   
            }
            return View(CategoryFromLb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ReturnBookPOST(int? id)
        {
            var obj = _lb.lent_books.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _lb.lent_books.Remove(obj);
            _lb.SaveChanges();
            return RedirectToAction("Lent");
        }
       
       

    }
}
