﻿using System;
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
    public class QLChiTietGiayServices : IQLChiTietGiayServices
    {
        public IChiTietGiayRepositories _IChiTietGiayRepositories;
        public IMauSacRepositories _IMauSacRepositories;
        public INsxRepositories _INsxRepositories;
        public ISizeRepositories _ISizeRepositories;
        public IGiayRepositories _IGiayRepositories;
        public IHangGiayRepositories _IHangGiayRepositories;
        public IChieuCaoDeGiayRepositories _IChieuCaoDeGiayRepositories;
    
        public QLChiTietGiayServices()
        {
            _IChieuCaoDeGiayRepositories = new ChieuCaoDeGiayRepositories();
            _IMauSacRepositories = new MauSacrepositories();
            _IChiTietGiayRepositories = new ChiTietGiayRepositories();
            _IGiayRepositories =new GiayRepositories();
            _IHangGiayRepositories = new HangGiayrepositories();
            _ISizeRepositories = new SizeRepositories();
            _INsxRepositories = new NsxRepositories();
        }
        public string Add(QLChiTietGiayView khv)
        {
            if (khv == null) return "thêm không thành công";
            var b = new ChiTietGiay()
            {
                
                IdMauSac = khv.IdMauSac,
                IdNsx = khv.IdNsx,
                IdSize = khv.IdSize,
                IdHangGiay = khv.IdHangGiay,
                IdChieuCaoDeGiay = khv.IdChieuCaoDeGiay,
                IdGiay = khv.IdGiay,
                MoTa = khv.MoTa,
                GiaBan = khv.GiaBan,
                GiaNhap = khv.GiaNhap,
                SoLuongTon = khv.SoLuongTon,
                TrangThai = khv.TrangThaiCTG,

            };
            if (_IChiTietGiayRepositories.Add(b)) return "thêm thành công";
            return "thêm thành công";
        }

        public string Update(QLChiTietGiayView khv)
        {
            if (khv == null) return "sửa không thành công";
            var b = new ChiTietGiay()
            {
                Id = khv.IdCTG,
                IdMauSac = khv.IdMauSac,
                IdNsx = khv.IdNsx,
                IdSize = khv.IdSize,
                IdHangGiay = khv.IdHangGiay,
                IdChieuCaoDeGiay = khv.IdChieuCaoDeGiay,
                IdGiay = khv.IdGiay,
                MoTa = khv.MoTa,
                GiaBan = khv.GiaBan,
                GiaNhap = khv.GiaNhap,
                SoLuongTon = khv.SoLuongTon,
                TrangThai = khv.TrangThaiCTG,
        
    };
            if (_IChiTietGiayRepositories.Update(b)) return "sửa thành công";
            return "sửa thành công";
        }

        public string Delete(QLChiTietGiayView khv)
        {
            if (khv == null) return "xóa không thành công";
            var b = new ChiTietGiay()
            {
                Id = khv.IdCTG,
                IdMauSac = khv.IdMauSac,
                IdNsx = khv.IdNsx,
                IdSize = khv.IdSize,
                IdHangGiay = khv.IdHangGiay,
                IdChieuCaoDeGiay = khv.IdChieuCaoDeGiay,
                IdGiay = khv.IdGiay,
                MoTa = khv.MoTa,
                GiaBan = khv.GiaBan,
                GiaNhap = khv.GiaNhap,
                SoLuongTon = khv.SoLuongTon,
                TrangThai = khv.TrangThaiCTG,

            };
            if (_IChiTietGiayRepositories.Delete(b)) return "xóa thành công";
            return "xóa thành công";
        }

        public List<QLChiTietGiayView> Getall()
        {
            List<QLChiTietGiayView> lstChiTietGiayView = new List<QLChiTietGiayView>();
            lstChiTietGiayView = (from a in _IChiTietGiayRepositories.GetAll()
                join b in _IMauSacRepositories.GetAll() on a.IdMauSac equals b.Id
                join c in _INsxRepositories.GetAll() on a.IdNsx equals c.Id
                join d in _ISizeRepositories.GetAll() on a.IdSize equals d.Id
                join e in _IGiayRepositories.GetAll() on a.IdGiay equals e.Id
                join f in _IHangGiayRepositories.GetAll() on a.IdHangGiay equals f.Id
                join g in _IChieuCaoDeGiayRepositories.GetAll() on a.IdChieuCaoDeGiay equals g.Id
                select new QLChiTietGiayView()
                {

                }).ToList();
            return lstChiTietGiayView;
        }
    }
}
