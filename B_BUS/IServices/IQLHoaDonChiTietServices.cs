using B_BUS.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.IServices
{
    public interface IQLHoaDonChiTietServices
    {
        string Add(QLHoaDonChiTietView khv);
        string Update(QLHoaDonChiTietView khv);
        string Delete(QLHoaDonChiTietView khv);
        List<QLHoaDonChiTietView> Getall();
    }
}
