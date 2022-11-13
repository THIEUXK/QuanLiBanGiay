using B_BUS.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.IServices
{
    public interface IQLHoaDonServices
    {
        string Add(QLHoaDonView khv);
        string Update(QLHoaDonView khv);
        string Delete(QLHoaDonView khv);
        List<QLHoaDonView> Getall();
    }
}
