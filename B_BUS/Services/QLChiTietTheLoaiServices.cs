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
    public class QLChiTietTheLoaiServices:IQLChiTietTheLoaiServices
    {
        public IChiTietTheLoai _IChiTietTheLoai;
        public ITheLoaiRepositories _ITheLoaiRepositories;
        public IChiTietGiayRepositories _IChiTietGiayRepositories;
        public QLChiTietTheLoaiServices()
        {
            _IChiTietTheLoai = new ChiTietTheLoaiRepositories();
            _ITheLoaiRepositories = new TheLoaiRepositories();
            _IChiTietGiayRepositories =new ChiTietGiayRepositories();
        }
        public string Add(QLChiTietTheLoaiView khv)
        {
            if (khv == null) return "thêm không thành công";
            var b = new ChiTietTheLoai()
            {
                IdTheLoai = khv.IdTheLoai,
                IdChiTietGiay = khv.IdChiTietGiay,
                TrangThai = khv.TrangThaiCTTL,
            };
            if (_IChiTietTheLoai.Add(b)) return "thêm thành công";
            return "thêm thành công";
        }

        public string Update(QLChiTietTheLoaiView khv)
        {
            if (khv == null) return "sửa không thành công";
            var b = new ChiTietTheLoai()
            {
                Id = khv.IdCTTL,
                IdTheLoai = khv.IdTheLoai,
                IdChiTietGiay = khv.IdChiTietGiay,
                TrangThai = khv.TrangThaiCTTL,
            };
            if (_IChiTietTheLoai.Update(b)) return "sửa thành công";
            return "sửa thành công";
        }

        public string Delete(QLChiTietTheLoaiView khv)
        {
            if (khv == null) return "xóa không thành công";
            var b = new ChiTietTheLoai()
            {
                Id = khv.IdCTTL,
                IdTheLoai = khv.IdTheLoai,
                IdChiTietGiay = khv.IdChiTietGiay,
                TrangThai = khv.TrangThaiCTTL,
            };
            if (_IChiTietTheLoai.Delete(b)) return "xóa thành công";
            return "xóa thành công";
        }

        public List<QLChiTietTheLoaiView> Getall()
        {
            List<QLChiTietTheLoaiView> lstHoaDonViews = new List<QLChiTietTheLoaiView>();
            lstHoaDonViews = (from a in _IChiTietTheLoai.GetAll()
                join b in _ITheLoaiRepositories.GetAll() on a.IdTheLoai equals b.Id
                join c in _IChiTietGiayRepositories.GetAll() on a.IdChiTietGiay equals c.Id
                select new QLChiTietTheLoaiView()
                {

                }).ToList();
            return lstHoaDonViews;
        }
    }
}
