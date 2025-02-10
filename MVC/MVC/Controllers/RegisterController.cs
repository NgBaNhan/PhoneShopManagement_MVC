using BO;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Service;

namespace MVC.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        private readonly IUserService userService;
        public RegisterController(ILogger<LoginController> logger, IUserService user)
        {
            _logger = logger;
            userService = user;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("User") != null)
            {
                return RedirectToAction("Index", "Home"); // Chuyển hướng về trang chủ
            }
           
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserDTO model)
        {

            if (!ModelState.IsValid)
            {

                return View("Index", model);
            }

            // Kiểm tra tài khoản đã tồn tại chưa
            var existingUser = userService.getAccountByID(model.UserId);
            if (existingUser != null)
            {
                ViewBag.Error = "Tên tài khoản đã có người đặt!";
                return View("Index", model);
            }

            // Lưu user vào database
            var newUser = new TblUser
            {
                UserId = model.UserId,
                Password = model.Password,
                FullName = model.FullName,
                Phone = model.Phone,
                Address = model.Address,
                Role = model.Role,
            };

            if (userService.registerUser(newUser))
            {

                ViewBag.Success = "Đăng ký thành công!";
                ModelState.Clear();
                return View("Index");
            }
            else
            {
                ViewBag.Error = "Đăng ký thất bại!";
                
                return View("Index");
            }
        }

    }
}
