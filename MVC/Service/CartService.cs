using BO;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CartService : ICartService
    {
        public List<TblCart> getAllCartUser(string userId)=> CartRepo.Instance.getAllCartUser(userId);

        public bool addToCart(TblCart cart) => CartRepo.Instance.addToCart(cart);
        public TblCart CheckCartUser(string userId, string mobileId) => CartRepo.Instance.CheckCartUser(userId, mobileId);
        public bool updateCart(TblCart cart)=>CartRepo.Instance.updateCart(cart);
        public bool removeCart(TblCart cart) => CartRepo.Instance.removeCart(cart);
    }
}
