using BO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public partial class UserRepo
    {
        private PhonesManagementContext dBContext;
        private static UserRepo instance = null;
        public static UserRepo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserRepo();
                }
                return instance;
            }
        }
        public UserRepo()
        {
            dBContext = new PhonesManagementContext();
        }
        public List<TblUser> getAllUser()
        {
            return dBContext.TblUsers.ToList();
        }
        public TblUser getAccountByID(string id)
        {
            return dBContext.TblUsers.FirstOrDefault(m => m.UserId.Equals(id));
        }
        public bool registerUser(TblUser user)
        {
            bool result = false;
            

            try
            {
                dBContext.ChangeTracker.Clear();

                dBContext.TblUsers.Add(user);
                dBContext.SaveChanges();
                
                result = true;
                  
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
            return result;
        }
        public bool updateProfile(TblUser user)
        {
            bool result = false;


            try
            {
                dBContext.ChangeTracker.Clear();

                dBContext.Entry(user).State = EntityState.Modified;
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
