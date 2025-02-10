using BO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        public TblUser getAccountByID(string id) => UserRepo.Instance.getAccountByID(id);
        public List<TblUser> getAllUser() => UserRepo.Instance.getAllUser();
        public bool registerUser(TblUser user) => UserRepo.Instance.registerUser(user);
        public bool updateProfile(TblUser user) => UserRepo.Instance.updateProfile(user);
    }
}
