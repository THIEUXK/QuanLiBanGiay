using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A_DAL.Entities;
using A_DAL.IRepositories;
using A_DAL.Repositories;
using B_BUS.IServices;
using B_BUS.View_Models;

namespace B_BUS.Services
{
    public class QLKhachHangServices:IQLKhachHangServices
    {
        private IKhachHangRepsitories _iKhachHangRepsitories;

        public QLKhachHangServices()
        {
            _iKhachHangRepsitories = new KhachHangRepositories();
        }
        public string Add(QLKhachHangView khv)
        {
            if (khv == null) return "thêm không thành công";
            var b = new KhachHang()
            {
                DiaChi = khv.DiaChi,
                Email = khv.Email,
                MaKhachHang = khv.MaKhachHang,
                TenKhachHang = khv.TenKhachHang,
                NgaySinh = khv.NgaySinh,
                Sdt = khv.Sdt,
                SoCCCD = khv.SoCCCD,
                TrangThai = khv.TrangThai,

            };
            if (_iKhachHangRepsitories.Add(b)) return "thêm thành công";
            return "thêm thành công";
        }

        public string Update(QLKhachHangView khv)
        {
            if (khv == null) return "sửa không thành công";
            var b = new KhachHang()
            {
                Id = khv.Id,
                DiaChi = khv.DiaChi,
                Email = khv.Email,
                MaKhachHang = khv.MaKhachHang,
                TenKhachHang = khv.TenKhachHang,
                NgaySinh = khv.NgaySinh,
                Sdt = khv.Sdt,
                SoCCCD = khv.SoCCCD,
                TrangThai = khv.TrangThai,

            };
            if (_iKhachHangRepsitories.Update(b)) return "sửa thành công";
            return "sửa thành công";
        }

        public string Delete(QLKhachHangView khv)
        {
            if (khv == null) return "xóa không thành công";
            var b = new KhachHang()
            {
                Id = khv.Id,
                DiaChi = khv.DiaChi,
                Email = khv.Email,
                MaKhachHang = khv.MaKhachHang,
                TenKhachHang = khv.TenKhachHang,
                NgaySinh = khv.NgaySinh,
                Sdt = khv.Sdt,
                SoCCCD = khv.SoCCCD,
                TrangThai = khv.TrangThai,

            };
            if (_iKhachHangRepsitories.Delete(b)) return "xóa thành công";
            return "xóa thành công";
        }

        public List<QLKhachHangView> Getall()
        {
            List<QLKhachHangView> lstKhachHangViews = new List<QLKhachHangView>();
            lstKhachHangViews = (from a in _iKhachHangRepsitories.GetAll()
                select new QLKhachHangView()
                {
                    Id = a.Id,
                    DiaChi = a.DiaChi,
                    Email = a.Email,
                    MaKhachHang = a.MaKhachHang,
                    TenKhachHang = a.TenKhachHang,
                    NgaySinh = a.NgaySinh,
                    Sdt = a.Sdt,
                    SoCCCD = a.SoCCCD,
                    TrangThai = a.TrangThai,
                }).ToList();
            return lstKhachHangViews;
        }
    }
}
