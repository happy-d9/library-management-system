using library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;

namespace library.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (TempData.Peek("admin_id") != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginModel lm)
        {
            string email = lm.email;
            string password = lm.password;

            DataSet ds = lm.login(email, password);
            ViewBag.data = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.data.Rows)
            {
                TempData["admin_id"] = dr["id"].ToString();
                TempData["admin_email"] = dr["email"].ToString();

                return RedirectToAction("Dashboard");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            TempData.Remove("admin_email");
            TempData.Remove("admin_id");

            return RedirectToAction("Index");
        }
      
        public IActionResult Dashboard(LoginModel lm)
        {
            if (TempData.Peek("admin_id") != null)
            {
                DataSet dataset = lm.view_book();
                DataSet ds = dataset;
                ViewBag.add_book = ds.Tables[0];
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
       [HttpGet]
        public IActionResult Add_book()
        {
            if (TempData.Peek("admin_id") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

		[HttpPost]
		public async Task<IActionResult> Add_book(LoginModel ab, IFormFile image)
		{
            if (TempData.Peek("admin_id") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var photo = ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName.Trim('"');
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                using (System.IO.Stream s = new FileStream(Path.Combine(path, image.FileName), FileMode.Create))
                {
                    await image.CopyToAsync(s);
                }

                int record = ab.Add_book(ab.book_name, ab.author_name, ab.isbn, ab.description, photo, ab.price);
                return RedirectToAction("Add_book");
            }
        }

        [HttpGet]
        public  IActionResult  Issue_books()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Issue_books(LoginModel lm)
        {
            if (TempData.Peek("admin_id") == null)
            {
                return RedirectToAction("Index");
            }
            else {
                string student_name = lm.student_name;
                string book_name = lm.book_name;
                string author_name = lm.author_name;
                string date = lm.date;

                lm.issue_book(student_name, book_name, author_name, date);

                return RedirectToAction("Dashboard");
            }
        }

        [HttpGet]
        public IActionResult view_book(LoginModel lm)
        {
            if (TempData.Peek("admin_id") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                DataSet ds = lm.view_book();
                ViewBag.add_book = ds.Tables[0];
                return View();
            }
        }
        [HttpGet]
        public IActionResult Update_issue_book(int id, LoginModel lm)
        {
            if (TempData.Peek("admin_id") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                DataSet ds = lm.select_updateissue(id);
                ViewBag.update_issue_book = ds.Tables[0];
                return View();
            }
        }
        [HttpPost]
        public IActionResult update_issue_book(int id, LoginModel lm)
        {
            if (TempData.Peek("admin_id") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                lm.update_issue_book(lm.student_name, lm.book_name, lm.author_name, lm.date,id);
                return RedirectToAction("view_issue_book");
            }
        }
        public IActionResult view_issue_book(LoginModel lm)
        {
            if (TempData.Peek("admin_id") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                DataSet dataset = lm.view_issue_book();
                DataSet ds = dataset;
                ViewBag.issue_book = ds.Tables[0];
                return View();
            }
        }
        public IActionResult delete_issue_book(LoginModel um, int id)
        {
            um.delete_issue_book(id);
            return RedirectToAction("view_issue_book");
        }

        [HttpGet]
        public IActionResult update_book(int id, LoginModel lm)
        {
            if (TempData.Peek("admin_id") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                DataSet ds = lm.select_updatebook(id);
                ViewBag.update_book = ds.Tables[0];
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> update_book(int id, LoginModel lm, IFormFile image)
        {
            if (TempData.Peek("admin_id") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var photo = ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName.Trim('"');
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                using (System.IO.Stream s = new FileStream(Path.Combine(path, image.FileName), FileMode.Create))
                {
                    await image.CopyToAsync(s);
                }
                ViewBag.ImageName = photo;
                lm.update_book(lm.book_name, lm.author_name, lm.isbn, lm.description, photo, lm.price, id);
                return RedirectToAction("view_book");
            }
        }
        public IActionResult delete_book(LoginModel um, int id)
        {
            um.delete_book(id);
            return RedirectToAction("view_book");
        }
        [HttpGet]
        public IActionResult Members()
        {
            if (TempData.Peek("admin_id") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Members(LoginModel lm)
        {
            if (TempData.Peek("admin_id") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                string name = lm.name;
                string email = lm.email;
                string age = lm.age;
                string contact_number = lm.contact_number;
                string deposite = lm.deposite;

                lm.update_member(name, email, age, contact_number, deposite);

                return RedirectToAction("Dashboard");
            }
        }
        public IActionResult delete_member(LoginModel um, int id)
        {
            um.delete_member(id);
            return RedirectToAction("view_member");
        }
        [HttpGet]
        public IActionResult view_member(LoginModel lm)
        {
            if (TempData.Peek("admin_id") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                DataSet ds = lm.view_member();
                ViewBag.view_member = ds.Tables[0];
                return View();
            }
        }
        [HttpGet]
        public IActionResult Update_member(int id, LoginModel lm)
        {
            if (TempData.Peek("admin_id") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                DataSet ds = lm.select_updatemember(id);
                ViewBag.update_member = ds.Tables[0];
                return View();
            }
        }
        [HttpPost]
        public IActionResult update_member(int id, LoginModel lm)
        {
            if (TempData.Peek("admin_id") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                lm.update_member(lm.name, lm.email, lm.age, lm.contact_number, lm.deposite,id);
                return RedirectToAction("view_member");
            }
        }
       
    }

}