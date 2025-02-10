using BO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public  class WishlistService : IWishlistService
    {
        public List<TblWishlist> GetWishlistsUser(string userId)=> WishListRepo.Instance.GetWishlistsUser(userId);
        public bool addToWishList(TblWishlist wishlist) => WishListRepo.Instance.addToWishList(wishlist);
        public bool deteleFromWishList(TblWishlist wishlist) => WishListRepo.Instance.deteleFromWishList(wishlist);
    }
}
