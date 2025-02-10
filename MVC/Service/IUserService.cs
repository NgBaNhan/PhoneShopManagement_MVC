using BO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService
    {
        public TblUser getAccountByID(string id);
        public List<TblUser> getAllUser();
        public bool registerUser(TblUser user);
    }
}
