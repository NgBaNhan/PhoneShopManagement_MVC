using BO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IMobileService
    {
        public List<TblMobile> getAllMobile();
        public TblMobile getMobileId(string mobileID);
    }
}
