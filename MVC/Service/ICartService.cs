using BO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICartService
    {
        public List<TblCart> getAllCartUser(string userId);

        public bool addToCart(TblCart cart);
        public TblCart CheckCartUser(string userId, string mobileId);
        public bool updateCart(TblCart cart);
        public bool removeCart(TblCart cart);
    }
}

