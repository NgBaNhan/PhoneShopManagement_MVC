using BO;
using System.Reflection;

namespace MVC.Models
{
    public class WishListDTO
    {
        public List<TblMobile> Products { get; set; }
        public List<string> WishList { get; set; }
    }
}
