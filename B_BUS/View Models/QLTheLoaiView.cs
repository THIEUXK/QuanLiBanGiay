﻿namespace B_BUS.View_Models
{
    public class QLTheLoaiView
    {
        public string MaTheLoai { get; set; } = null!;
        public string TenTheLoai { get; set; } = null!;
        public Guid IdPhanCap { get; set; }
        public int TrangThai { get; set; } = 0!;
    }
}
