using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterWc.Business.Abstract
{
    public interface IDbService
    {
        void GetNewDay();
        bool CheckDbExist();
    }
}
