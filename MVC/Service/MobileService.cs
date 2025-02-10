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
    public class MobileService : IMobileService
    {
        public List<TblMobile> getAllMobile()
        {
           return MobileRepo.Instance.getAllMobile();
        }
        public TblMobile getMobileId(string mobileID)
        {
            return MobileRepo.Instance.getMobileId(mobileID);
        }
    }
}
