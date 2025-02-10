using BO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class WishListRepo
    {
        private PhonesManagementContext dBContext;
        private static WishListRepo instance = null;
        public static WishListRepo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WishListRepo();
                }
                return instance;
            }
        }
        public WishListRepo()
        {
            dBContext = new PhonesManagementContext();
        }
        public List<TblWishlist> GetWishlistsUser(string userId)
        {
            return dBContext.TblWishlists.Where(p=>p.UserId.Equals(userId)).ToList();
        }
        public bool addToWishList(TblWishlist wishlist)
        {
            bool result = false;


            try
            {
                dBContext.ChangeTracker.Clear();
                dBContext.TblWishlists.Add(wishlist);
                dBContext.SaveChanges();

                result = true;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return result;
        }
        public bool deteleFromWishList(TblWishlist wishlist)
        {
            bool result = false;


            try
            {
                dBContext.ChangeTracker.Clear();
                dBContext.TblWishlists.Remove(wishlist);
                dBContext.SaveChanges();

                result = true;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return result;
        }
    }
}
