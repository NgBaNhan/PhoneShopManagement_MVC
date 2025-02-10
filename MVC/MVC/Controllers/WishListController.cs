using BO;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MVC.Controllers
{
    public class WishListController : Controller
    {
        private readonly IWishlistService _wishlistService;
        private readonly ILogger<WishListController> _logger;
        private readonly IMobileService _mobileService;
        public WishListController(ILogger<WishListController> logger, IWishlistService wishlistService, IMobileService mobileService)
        {
            _logger = logger;
            _wishlistService = wishlistService;
            _mobileService = mobileService;
        }
        public IActionResult Index()
        {

            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            string userID = HttpContext.Session.GetString("User");
            var wishList = _wishlistService.GetWishlistsUser(userID);
            return View("Index", wishList);
        }

        public IActionResult AddToWishList(string mobileId ,string returnUrl)
        {

            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            string userId = HttpContext.Session.GetString("User");

            var phone = _mobileService.getMobileId(mobileId);


            TblWishlist newCartItem = new TblWishlist
            {
                UserId = userId,
                MobileId = phone.MobileId,
                YearOfProduction = phone.YearOfProduction,
                MobileName = phone.MobileName,
                Description = phone.Description,
                Discount = phone.Discount,
                Images = phone.Images,
                Quantity = phone.Quantity,
                Price = phone.Price
            };

            _wishlistService.addToWishList(newCartItem);

            return RedirectToAction("Phones", "Cart");
        }
        public IActionResult DeleteFromWishList(string mobileId,string returnUrl)
        {

            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            string userId = HttpContext.Session.GetString("User");

            var phone = _mobileService.getMobileId(mobileId);


            TblWishlist newCartItem = new TblWishlist
            {
                UserId = userId,
                MobileId = phone.MobileId,
                YearOfProduction = phone.YearOfProduction,
                MobileName = phone.MobileName,
                Description = phone.Description,
                Discount = phone.Discount,
                Images = phone.Images,
                Quantity = phone.Quantity,
                Price = phone.Price
            };

            _wishlistService.deteleFromWishList(newCartItem);
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl); // Quay lại trang trước
            }

            return RedirectToAction("Phones", "Cart");
        }
    }
}
