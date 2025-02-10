using BO;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Service;
using System.Numerics;
using System.Security.Claims;

namespace MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly IWishlistService _wishlistService;
        private readonly ICartService cartService;
        private readonly IMobileService mobileService;
        public CartController(ILogger<CartController> logger, IMobileService mobile, ICartService cart, IWishlistService wishlistService)
        {
            _logger = logger;
            mobileService = mobile;
            cartService = cart;
            _wishlistService = wishlistService;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            string userId = HttpContext.Session.GetString("User");
            var _cartService = cartService.getAllCartUser(userId);
            return View(_cartService);
        }
        public IActionResult Phones()
        {
            var listPhones = mobileService.getAllMobile();
            if (HttpContext.Session.GetString("User") == null)
            {
                return View(listPhones);
            }
            var userId = HttpContext.Session.GetString("User");
            var wishList = _wishlistService.GetWishlistsUser(userId);
            var model = new WishListDTO
            {
                Products = listPhones,
                WishList = wishList.Select(w => w.MobileId).ToList() // Lấy danh sách ID sản phẩm trong wishlist
            };

            return View(model);
        }
        public IActionResult AddToCart(string mobileId, string returnUrl,int quantity)
        {
            
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Index", "Login");
            }

           
            var phone = mobileService.getMobileId(mobileId);
          
  
            string userId = HttpContext.Session.GetString("User");

       
            var existingCartItem = cartService.CheckCartUser(userId,mobileId);

            if (existingCartItem != null)
            {
                
                existingCartItem.Quantity += quantity;
                cartService.updateCart(existingCartItem);
                TempData["Success"] = $"Đã thêm {quantity} {existingCartItem.MobileName} vào giỏ hàng!";
            }
            else
            {
                TblCart newCartItem = new TblCart
                {
                    UserId = userId,
                    MobileId = phone.MobileId,
                    YearOfProduction = phone.YearOfProduction,
                    MobileName = phone.MobileName,
                    Description = phone.Description,
                    Discount = phone.Discount,
                    Images = phone.Images,
                    Quantity = quantity, 
                    Price = phone.Price
                };

                cartService.addToCart(newCartItem);
                TempData["Success"] = $"Đã thêm {quantity} {newCartItem.MobileName} vào giỏ hàng!";
            }
           
            
      
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl); // Quay lại trang trước
            }
            var listPhones = mobileService.getAllMobile();
            return View("Phones", listPhones);
        }
        public IActionResult DeleteFromCart(string mobileId, string returnUrl,int quantity)
        {

            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            string userId = HttpContext.Session.GetString("User");

           
            // Tìm sản phẩm trong giỏ hàng
            var cartItem = cartService.CheckCartUser(userId, mobileId);

            if (cartItem != null)
            {
                if (quantity >= cartItem.Quantity)
                {
                    // Nếu số lượng muốn xóa >= số lượng có trong giỏ -> Xóa sản phẩm
                    TempData["Success"] = $"Đã xóa {cartItem.MobileName} khỏi giỏ hàng!";
                    cartService.removeCart(cartItem);
                   
                }
                else
                {
                    // Nếu số lượng muốn xóa < số lượng có trong giỏ -> Giảm số lượng
                    cartItem.Quantity -= quantity;
                    cartService.updateCart(cartItem);
                    TempData["Success"] = $"Đã giảm {quantity} {cartItem.MobileName} khỏi giỏ hàng!";
                }
            }
            else
            {
                TempData["Error"] = "Không tìm thấy sản phẩm trong giỏ hàng!";
            }
         
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl); // Quay lại trang trước
            }

            return RedirectToAction("Phones", "Cart");
        }
    }
}
