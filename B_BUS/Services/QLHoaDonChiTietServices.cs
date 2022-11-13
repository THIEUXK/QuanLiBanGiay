using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A_DAL.Entities;
using A_DAL.IRepositories;
using B_BUS.IServices;
using B_BUS.View_Models;

namespace B_BUS.Services
{
    public class QLHoaDonChiTietServices:IQLHoaDonChiTietServices
    {
        public IHoaDonChiTietrepositories _IHoaDonChiTietrepositories;
        public IHoaDonRepositories _IHoaDonRepositories;
        public IChiTietGiayRepositories _iChiTietGiayRepositories;
        public QLHoaDonChiTietServices()
        {
            
        }
        public string Add(QLHoaDonChiTietView khv)
        {
            if (khv == null) return "thêm không thành công";
            var b = new HoaDonChiTiet()
            {
                
                IdChiTietGiay = khv.IdChiTietGiay,
                IdHoaDon = khv.IdHoaDon,
                DonGia = khv.DonGia,
                TrangThai = khv.TrangThaiHDCT,

            };
            if (_IHoaDonChiTietrepositories.Add(b)) return "thêm thành công";
            return "thêm thành công";
        }

        public string Update(QLHoaDonChiTietView khv)
        {
            if (khv == null) return "sửa không thành công";
            var b = new HoaDonChiTiet()
            {
                Id = khv.IdHDCT,
                IdChiTietGiay = khv.IdChiTietGiay,
                IdHoaDon = khv.IdHoaDon,
                DonGia = khv.DonGia,
                TrangThai = khv.TrangThaiHDCT,

            };
            if (_IHoaDonChiTietrepositories.Update(b)) return "sửa thành công";
            return "sửa thành công";
        }

        public string Delete(QLHoaDonChiTietView khv)
        {
            if (khv == null) return "xóa không thành công";
            var b = new HoaDonChiTiet()
            {
                Id = khv.IdHDCT,
                IdChiTietGiay = khv.IdChiTietGiay,
                IdHoaDon = khv.IdHoaDon,
                DonGia = khv.DonGia,
                TrangThai = khv.TrangThaiHDCT,

            };
            if (_IHoaDonChiTietrepositories.Delete(b)) return "xóa thành công";
            return "xóa thành công";
        }

        public List<QLHoaDonChiTietView> Getall()
        {
            List<QLHoaDonChiTietView> lstHoaDonViews = new List<QLHoaDonChiTietView>();
            lstHoaDonViews = (from a in _IHoaDonChiTietrepositories.GetAll()
                join b in _IHoaDonRepositories.GetAll() on a.IdHoaDon equals b.Id
                join c in _iChiTietGiayRepositories.GetAll() on a.IdChiTietGiay equals c.Id
                select new QLHoaDonChiTietView()
                {

                }).ToList();
            return lstHoaDonViews;
        }
    }
}
