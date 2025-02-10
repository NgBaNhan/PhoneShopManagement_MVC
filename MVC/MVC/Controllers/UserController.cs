using BO;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        private readonly IUserService userService;
        public UserController(ILogger<UserController> logger, IUserService user)
        {
            _logger = logger;
            userService = user;
        }
        public IActionResult Index()
        {

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {

                return RedirectToAction("Index", "Login"); // Chuyển hướng về trang đăng nhập nếu chưa đăng nhập
            }

            string userId = HttpContext.Session.GetString("User");
            var account = userService.getAccountByID(userId);

            return View("Index", account);
        }
        [HttpPost]
        public IActionResult UpdateProfile(TblUser model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            if (userService.updateProfile(model))
            {

                TempData["Success"] = "Đã cập nhật thông tin thành công!";
            }
            else
            {
                TempData["Success"] = "Đã cập nhật thông tin thất bại!";
            }
            return View("Index", model);
        }
    }
}
