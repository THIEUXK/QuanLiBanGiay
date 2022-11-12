﻿using A_DAL.Entities;

namespace A_DAL.IRepositories
{
    public interface IKhachHangRepsitories
    {
        bool Add(KhachHang obj);
        bool Update(KhachHang obj);
        bool Delete(KhachHang obj);
        KhachHang GetById(Guid id); //Phương thức này lấy theo id
        List<KhachHang> GetAll();
    }
}
