using BO;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        private readonly IUserService userService;
        public LoginController(ILogger<LoginController> logger, IUserService user)
        {
            _logger = logger;
            userService = user;
        }
        public IActionResult Index(string returnUrl)
        {

            if (HttpContext.Session.GetString("User") != null)
            {
                return RedirectToAction("Index", "Home"); // Chuyển hướng về trang chủ
            }
          

            return View();
        }
        [HttpPost]
        public IActionResult Login(TblUser model, string returnUrl)
        {
           
            var account = userService.getAccountByID(model.UserId);
            if (account != null)
            {   
                if (account.Password.Equals(model.Password))
                {
                    
                    HttpContext.Session.SetString("User", model.UserId);
                   
                    return RedirectToAction("Index", "Home");
                }
            }
          
            ViewBag.Error = "Sai tài khoản hoặc mật khẩu!";

            return View("Index", model); // Trả về View Index khi đăng nhập thất bại
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Index");
        }
    }

}
