using BO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public partial class MobileRepo 
    {
        private PhonesManagementContext dBContext;
        private static MobileRepo instance = null;
        public static MobileRepo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MobileRepo();
                }
                return instance;
            }
        }
        public MobileRepo()
        {
            dBContext = new PhonesManagementContext();
        }
        public List<TblMobile> getAllMobile()
        {
            return dBContext.TblMobiles.ToList();
        }
        public TblMobile getMobileId(string mobileID)
        {
            return dBContext.TblMobiles.FirstOrDefault(p => p.MobileId.Equals(mobileID));
        }
    }
}
