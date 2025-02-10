using BO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IWishlistService
    {
        public List<TblWishlist> GetWishlistsUser(string userId);
        public bool addToWishList(TblWishlist wishlist);
        public bool deteleFromWishList(TblWishlist wishlist);
    }
}
