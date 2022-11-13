using B_BUS.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_BUS.IServices
{
    public interface IQLChiTietTheLoaiServices
    {
        string Add(QLChiTietTheLoaiView khv);
        string Update(QLChiTietTheLoaiView khv);
        string Delete(QLChiTietTheLoaiView khv);
        List<QLChiTietTheLoaiView> Getall();
    }
}
