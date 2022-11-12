﻿using A_DAL.Entities;

namespace A_DAL.IRepositories
{
    public interface IHoaDonRepositories
    {
        bool Add(HoaDon obj);
        bool Update(HoaDon obj);
        bool Delete(HoaDon obj);
        HoaDon GetById(Guid id);//Phương thức này lấy theo id
        List<HoaDon> GetAll();
    }
}
