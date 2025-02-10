using BO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public partial class CartRepo
    {
        private PhonesManagementContext dBContext;
        private static CartRepo instance = null;
        public static CartRepo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CartRepo();
                }
                return instance;
            }
        }
        public CartRepo()
        {
            dBContext = new PhonesManagementContext();
        }
        public List<TblCart> getAllCartUser(string userId)
        {
            return dBContext.TblCarts.Where(p => p.UserId.Equals(userId)).ToList();
        }
        public TblCart CheckCartUser(string userId,string mobileId)
        {
            return dBContext.TblCarts.FirstOrDefault(p => p.UserId.Equals(userId) && p.MobileId.Equals(mobileId));
        }
        public bool updateCart(TblCart cart)
        {
            bool result = false;

            TblCart tblCart = this.CheckCartUser(cart.UserId,cart.MobileId);
            try
            {
                if (tblCart != null)
                {

                    dBContext.ChangeTracker.Clear();
                    dBContext.Entry(cart).State = EntityState.Modified;
                    dBContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return result;
        }
        public bool removeCart(TblCart cart)
        {
            bool result = false;

            TblCart tblCart = this.CheckCartUser(cart.UserId, cart.MobileId);
            try
            {
                if (tblCart != null)
                {

                    dBContext.ChangeTracker.Clear();
                    dBContext.TblCarts.Remove(cart);
                    dBContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return result;
        }
        public bool addToCart(TblCart cart)
        {
            bool result = false;


            try
            {
                dBContext.ChangeTracker.Clear();
                dBContext.TblCarts.Add(cart);
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
