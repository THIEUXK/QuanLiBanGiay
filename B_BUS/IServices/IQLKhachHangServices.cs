using B_BUS.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.IServices
{
    public interface IQLKhachHangServices
    {
        string Add(QLKhachHangView khv);
        string Update(QLKhachHangView khv);
        string Delete(QLKhachHangView khv);
        List<QLKhachHangView> Getall();
    }
}
