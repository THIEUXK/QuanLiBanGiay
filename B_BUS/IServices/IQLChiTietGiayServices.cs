using B_BUS.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.IServices
{
    public interface IQLChiTietGiayServices
    {
        string Add(QLChiTietGiayView khv);
        string Update(QLChiTietGiayView khv);
        string Delete(QLChiTietGiayView khv);
        List<QLChiTietGiayView> Getall();
    }
}
