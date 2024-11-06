using System;
using System.Collections.Generic;

namespace WpfApp3.Models;

public partial class TsinhVien
{
    public int MaSo { get; set; }

    public string HoTen { get; set; } = null!;

    public DateOnly? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public string? DiaChi { get; set; }

    public int? DienThoai { get; set; }
}
