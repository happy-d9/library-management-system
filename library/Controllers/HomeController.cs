using library.Models;
using Microsoft.AspNetCore.Mvc;
using p1.Models;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace library.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Service()
        {
            return View();
        }
        public IActionResult Book()
        {
            return View();
        }
        public IActionResult Book1(LoginModel lm)
        {
            DataSet dataset = lm.view_book();
            DataSet ds = dataset;
            ViewBag.add_book = ds.Tables[0];
            return View();
        }
        public IActionResult Book2()
        {
            return View();
        }
        public IActionResult Book3()
        {
            return View();
        }
        public IActionResult Book4()
        {
            return View();
        }
        public IActionResult Newslist() { 
            return View();
        }
        public IActionResult Newslist1()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Cart(LoginModel lm)
        {
            DataSet dataset = lm.view_book();
            DataSet ds = dataset;
            ViewBag.view_cart = ds.Tables[0];
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Signin()
        {
            if (TempData.Peek("user_id") != null)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpPost]
        public IActionResult Signin(UserModel um)
        {
            string barcode = um.barcode;
            string password = um.password;

            DataSet ds = um.login(barcode, password);
            ViewBag.data = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.data.Rows)
            {
                TempData["user_id"] = dr["id"].ToString();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Signin");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserModel um)
        {
            int n = um.register(um.barcode, um.password);
            if (n == 1)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Signin");

        }
        public IActionResult Error(int a=1)
        {
            return View();
        }
        public IActionResult BlogDetail()
        {
            return View();
        }
        [HttpGet]
        public IActionResult contact()
        {

            return View();
        }
        [HttpPost]
        public IActionResult contact(UserModel lm)
        {
            string first_name = lm.first_name;
            string last_name = lm.last_name;
            string email = lm.email;
            string phone_number = lm.phone_number;
            string message = lm.message;

            lm.contact(first_name,last_name, email, phone_number, message);

            return RedirectToAction("Index");
        }
        public IActionResult Bloggridview()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult order(ordermodel om,int id,UserModel um)
        {
            if (TempData.Peek("user_id") == null)
            {
                return RedirectToAction("signin");

            }
            else
            {
                int user_id = int.Parse(TempData["user_id"].ToString());

                om.order_book(user_id, id);

                return RedirectToAction("cart");
            }

        }

        public IActionResult Logout()
        {
            TempData.Remove("user_id");

            return RedirectToAction("Index");
        }

        public IActionResult view_order(ordermodel lm)
        {
            
                int user_id = int.Parse(TempData.Peek("user_id").ToString());
                DataSet ds = lm.show_order(user_id);
                ViewBag.show_order = ds.Tables[0];
                return View();
        }
        public IActionResult delete_order(ordermodel um, int id)
        {
            um.delete_order(id);
            return RedirectToAction("view_order");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}