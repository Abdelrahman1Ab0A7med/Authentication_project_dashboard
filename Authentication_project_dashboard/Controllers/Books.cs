using Authentication_project_dashboard.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Authentication_project_dashboard.Models;

namespace Authentication_project_dashboard.Controllers
{
    public class Books : Controller
    {
        private readonly ApplicationDbContext? _context;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
         
        public Books(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager) { 
            _context = new ApplicationDbContext();
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return Redirect("/Identity/Account/Login");
            }
            string id = _userManager.GetUserId(User);
            var books = _context?._book?.Where(b=>b.UserId == id).ToList();
           // ViewBag.Book = book;
            return View(books);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Book newBook)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            newBook.UserId = _userManager.GetUserId(User);
			_context?.Add(newBook);
            _context?.SaveChanges();
            return RedirectToAction(nameof(Index));
        } 


        public IActionResult Delete(int id) {
            var book1 = _context?._book?.First(b => b.Id == id);
            if (book1?.UserId != _userManager.GetUserId(User))
            {
                return RedirectToAction(nameof(Error));
            }
            var book = _context?._book?.FirstOrDefault(b => b.Id == id);
            _context?._book?.Remove(book);
            _context?.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Show(int id)
        {
            var book = _context?._book?.FirstOrDefault(b=> b.Id == id  );
            if (book == null)
            {
                return RedirectToAction(nameof(Error));
            }
            if(book?.UserId != _userManager.GetUserId(User)){
                return RedirectToAction(nameof(Error));
            }
            
                return View(book);
            
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book1 = _context?._book?.First(b => b.Id == id);
            if (book1?.UserId != _userManager.GetUserId(User))
            {
                return RedirectToAction(nameof(Error));
            }
            var book = _context?._book?.First(b=>b.Id == id );
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(Book book ,int id)
        {

			var old_book = _context?._book?.First(b=> b.Id == id);
			if (!ModelState.IsValid)
			{
				return View(old_book);
			}
            old_book.Description = book.Description;
            old_book.Type = book.Type;
            old_book.Name = book.Name;
            _context?.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Error(int state)
        {
            return View(state);
        }
    }
}
